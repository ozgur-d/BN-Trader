using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Linq;

namespace BNTrader.Core
{
    public enum TransactionType
    {
        TAKE_PROFIT,
        STOPLOSSLOCAL,
        BUY,
        STOPLOSSREMOTE,
    }

    public class Trades
    {
        public int id { get; set; }
        public string symbol { get; set; }
        public TransactionType transaction { get; set; }
        public decimal quantity { get; set; }
        public decimal stoplimit { get; set; }
        public decimal limit { get; set; }

        public string currentTransaction { get; set; }
        public bool hasOrder { get; set; }

        public long orderId { get; set; }
        public string origClientOrderId { get; set; }

        public int relId { get; set; }
        public int parentId { get; set; }

        public long updateTimestamp { get; set; }
        

        public Trades(string symbol, TransactionType transaction, decimal stoplimit, decimal limit, decimal quantity, string currentTransaction = "", bool hasOrder = false, long orderId = 0, string origClientOrderId = "", int relId = 0, int parentId = 0)
        {
            int id = Convert.ToInt32(File.ReadAllText(FilePath.idHolder));
            id++;
            File.WriteAllText(FilePath.idHolder, id.ToString());

            this.id = id;
            this.symbol = symbol;
            this.transaction = transaction;
            this.stoplimit = stoplimit;
            this.limit = limit;
            this.quantity = quantity;
            this.currentTransaction = currentTransaction;
            this.hasOrder = hasOrder;
            this.orderId = orderId;
            this.origClientOrderId = origClientOrderId;
            this.relId = relId;
            this.parentId = parentId;
            //this.updateTimestamp = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
        }

        public async Task<Binance.NetCore.Entities.TradeResponse> postSELLOrder()
        {
            var tradeParams = new Binance.NetCore.Entities.TradeParams
            {
                price = Convert.ToDecimal(this.limit),
                quantity = Convert.ToDecimal(this.quantity),
                side = Binance.NetCore.Entities.Side.SELL.ToString(),
                symbol = this.symbol,
                type = Binance.NetCore.Entities.OrderType.LIMIT.ToString()
            };


            try
            {
                MainForm.RequestPerMinuteCount++;
                var order = await MainForm.binance.PostTradeAsync(tradeParams);

                Logger.Log("postSellOrder: " + this.symbol + " amount: " + this.quantity + " price: " + this.limit);
                return order;
            }
            catch (Exception ex)
            {
                Logger.Log("postSellOrder: " + ex.Message);
                return null;
            }
        }

        public async Task<Binance.NetCore.Entities.TradeResponse> postBUYOrder()
        {
            var tradeParams = new Binance.NetCore.Entities.TradeParams
            {
                price = Convert.ToDecimal(this.limit),
                quantity = Convert.ToDecimal(this.quantity),
                side = Binance.NetCore.Entities.Side.BUY.ToString(),
                symbol = this.symbol,
                type = Binance.NetCore.Entities.OrderType.LIMIT.ToString()
            };

            try
            {
                MainForm.RequestPerMinuteCount++;
                var order = await MainForm.binance.PostTradeAsync(tradeParams);
                Logger.Log("postBUYOrder: " + this.symbol + " amount: " + this.quantity + " price: " + this.limit);
                return order;
            }
            catch (Exception ex)
            {
                Logger.Log("postBUYOrder: " + ex.Message);
                return null;
            }
        }

        public async Task<Binance.NetCore.Entities.TradeResponse> postSTOPLOSSREMOTEOrder()
        {
            var tradeParams = new Binance.NetCore.Entities.TradeParams
            {
                price = Convert.ToDecimal(this.limit),
                stopPrice = Convert.ToDecimal(this.stoplimit),
                quantity = Convert.ToDecimal(this.quantity),
                side = Binance.NetCore.Entities.Side.SELL.ToString(),
                symbol = this.symbol,
                type = Binance.NetCore.Entities.OrderType.STOP_LOSS_LIMIT.ToString()
            };

            try
            {
                MainForm.RequestPerMinuteCount++;
                var order = await MainForm.binance.PostTradeAsync(tradeParams);
                Logger.Log("postSTOPLOSSREMOTEOrder: " + this.symbol + " amount: " + this.quantity + " price: " + this.limit + "stop price: " + this.stoplimit);
                return order;
            }
            catch (Exception ex)
            {
                Logger.Log("postSTOPLOSSREMOTEOrder: " + ex.Message);
                return null;
            }
        }

        public async Task deleteLocalOrder()
        {
            
            List<Trades> readTrade = new List<Trades>();
            readTrade = JsonConvert.DeserializeObject<List<Trades>>(FilePath.readTrades());
            

            string symbol = readTrade.First(x => x.id == this.id).symbol;
            TransactionType transaction = readTrade.First(x => x.id == this.id).transaction;

            readTrade.RemoveAll(x => x.id == this.id);
            //save
            string jsonString = JsonConvert.SerializeObject(readTrade);
            File.WriteAllText(FilePath.tradeFile, jsonString);

            Logger.Log("Auto Trade: DELETELOCALORDER" + " symbol: " + symbol + " transaction: " + transaction);
        }

        public async Task<Binance.NetCore.Entities.OrderResponse[]> getSingleOrder(string pair = "")
        {

            var orders = await MainForm.binance.GetOpenOrdersAsync(pair);


            MainForm.RequestPerMinuteCount++;
            return orders;

        }

        public async Task checkIsOrderFilled(int stoplossid)
        {
            //wait for 30seconds
            if(updateTimestamp != null)
            {
                long currentTimeSec = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
                if ((currentTimeSec - updateTimestamp) < 30)
                    return;
            }

            var getOrder = await getSingleOrder(this.symbol);          

            if (!getOrder.Any(g => g.orderId == this.orderId && g.clientOrderId == this.origClientOrderId) && this.hasOrder)
            {
                Logger.Log("FILLED - " + " symbol: " + this.symbol + " quantity: " + this.quantity + " limit: " + this.limit);
                this.deleteLocalOrder();

                if (this.transaction == TransactionType.TAKE_PROFIT)
                {
                    getTradeWithId(stoplossid).deleteLocalOrder();
                }
                else if (this.transaction == TransactionType.STOPLOSSREMOTE)
                {
                    getTradeWithId(this.parentId).deleteLocalOrder();
                }

                return;
            }
        }

        public static Trades getTradeWithId(int tradeId)
        {
            //read old values
           
            List<Trades> readTrade = new List<Trades>();
            readTrade = JsonConvert.DeserializeObject<List<Trades>>(FilePath.readTrades());
            

            return readTrade.FirstOrDefault(x => x.id == tradeId);
        }

        public async Task deleteOrderWithSymbol()
        {
            try
            {
                var tradeParams = new Binance.NetCore.Entities.CancelTradeParams
                {
                    symbol = this.symbol,
                    origClientOrderId = this.origClientOrderId,
                    orderId = this.orderId,
                };

                MainForm.RequestPerMinuteCount++;
                var order = await MainForm.binance.DeleteTradeAsync(tradeParams);
                Logger.Log("DeleteOrder: " + this.symbol + " amount: " + this.quantity + " price: " + this.limit);
            }
            catch (Exception ex)
            {
                Logger.Log("DeleteOrder: " + ex.Message);
            }
        }


    }
}
