using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Binance.NetCore;
using BNTrader.Core;
using Newtonsoft.Json;
using System.IO;
namespace BNTrader
{
    

    public partial class MainForm : Form
    {
        
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        public static BinanceApiClient binance;
        public static MainForm form;

        //variables
        public static int RequestPerMinuteCount = 0;
        int timerCounter = 0;
        
        
        List<Binance.NetCore.Entities.OrderResponse> globalOpenorders;
        string dataLocalOrderProperty = "symbol", dataAccountProperty = "symbol";
        int dataLocalOrderCounter = 0, dataAccountCounter = 0, logLineCount = 0, remoteCounter =0;
        


        public MainForm()
        {
            InitializeComponent();
            form = this;
            
            Settings readcfg = JsonConvert.DeserializeObject<Settings>(FilePath.readSettings());

            binance = new BinanceApiClient(readcfg.apiKey, readcfg.secretKey);

            //chkTradeStatus.Checked = readcfg.tradeStatus;

            //exChangeInfo();
            checkLatency();
            checkBalances();   
            
            //to get all open orders send empty, if you wanna check with symbol, you can  write as string
            getOpenOrders();
            loadTrades();

            //***for test purpose**
            //postSELLOrder("XLMUSDT",10.5,2.5323);

            //run after loading getOpenOrders();
            //deleteOrderWithSymbol("XLMUSDT");
        }

        public void updateLogText(string msg)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<string>(updateLogText), new object[] { msg });
                return;
            }
            this.txtConsole.Text += msg;
        }

        private async Task checkLatency()
        {
            //currrent
            long timestamp = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeMilliseconds();

            var getBinanceTime = await binance.GetBinanceTimeAsync();

            lblDelay.Text = (getBinanceTime.serverTime - timestamp) + "ms";
            RequestPerMinuteCount++;

        }

        private async Task loadTrades()
        {
            //read old values
           
            List<Trades> readTrade = await Task.Run(() => JsonConvert.DeserializeObject<List<Trades>>(FilePath.readTrades()));
            
            dataLocalOrders.AutoGenerateColumns = true;
            if(dataLocalOrderCounter % 2 == 0)
            dataLocalOrders.DataSource = readTrade.OrderBy(s => s.GetType().GetProperty(dataLocalOrderProperty).GetValue(s, null)).ToList();
            else
            dataLocalOrders.DataSource = readTrade.OrderByDescending(s => s.GetType().GetProperty(dataLocalOrderProperty).GetValue(s, null)).ToList();

            dataLocalOrders.Columns.Remove("currentTransaction");
            dataLocalOrders.Columns.Remove("hasOrder");
            dataLocalOrders.Columns.Remove("relId");
            dataLocalOrders.Columns.Remove("parentId");
            dataLocalOrders.Columns.Remove("origClientOrderId");
            dataLocalOrders.Columns.Remove("orderId");


            dataLocalOrders.Columns["symbol"].HeaderText = "Symbol";
            dataLocalOrders.Columns["transaction"].HeaderText = "Transaction";
            dataLocalOrders.Columns["quantity"].HeaderText = "Quantity";
            dataLocalOrders.Columns["stoplimit"].HeaderText = "Stoplimit";
            dataLocalOrders.Columns["limit"].HeaderText = "Limit";

            DataGridViewButtonColumn uninstallButtonColumn = new DataGridViewButtonColumn();
            uninstallButtonColumn.Name = "delete_order";
            uninstallButtonColumn.Text = "Delete Order";
            uninstallButtonColumn.HeaderText = "Delete Order";
            uninstallButtonColumn.UseColumnTextForButtonValue = true;


            int columnIndex = dataLocalOrders.ColumnCount;
            if (dataLocalOrders.Columns["delete_order"] == null)
            {
                dataLocalOrders.Columns.Insert(columnIndex, uninstallButtonColumn);
            }

            dataLocalOrders.Refresh();

        }

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        
        private async Task checkBalances()
        {
            try { 
            var databag = new ConcurrentBag<Account>();
            var bal = await binance.GetBalanceAsync();
                if (bal == null)
                {
                    Logger.Log("Config file is missing. Or IP Limit Restriction. Or Unknown Error. CHECK BALANCE FAILED");
                    return;
                }

                var tasks = bal.balances.Select(async x =>
            {
                if (x.free > 0 || x.locked > 0)
                {
                    var value = await Account.checkPrice(x.asset+ Account.convertToCurrencyStr);
                    var totalvalue = x.free + x.locked;
                    //MessageBox.Show(totalvalue.ToString());
                    Account yeni = new Account ( x.asset.ToString(), Convert.ToDecimal(totalvalue), value, value * Convert.ToDecimal(totalvalue) );
                    databag.Add(yeni);
                }
            });

            await Task.WhenAll(tasks);

            dataAccount.AutoGenerateColumns = true;
            if (dataAccountCounter % 2 == 0)
                dataAccount.DataSource = databag.OrderBy(s => s.GetType().GetProperty(dataAccountProperty).GetValue(s, null)).ToList();
            else
                dataAccount.DataSource = databag.OrderByDescending(s => s.GetType().GetProperty(dataAccountProperty).GetValue(s, null)).ToList();


            dataAccount.Columns["symbol"].HeaderText = "Symbol";
            dataAccount.Columns["amount"].HeaderText = "Amount";
            dataAccount.Columns["value"].HeaderText = "Value";
            dataAccount.Columns["totalvalue"].HeaderText = "Total";
            dataAccount.Refresh();

            RequestPerMinuteCount++;
            }
            catch (Exception e)
            {
                Logger.Log(e.Message);
                Logger.Log("Config file is missing. Or IP Limit Restriction. Or Unknown Error. CHECK BALANCE FAILED");
            }
        }

        private async Task getOpenOrders(string pair = "")
        {

            var orders = await binance.GetOpenOrdersAsync(pair);
            dataOpenOrder.AutoGenerateColumns = true;
            dataOpenOrder.DataSource = orders.ToList();
            dataOpenOrder.Columns.Remove("orderId");
            dataOpenOrder.Columns.Remove("clientOrderId");
            dataOpenOrder.Columns.Remove("executedQty");
            dataOpenOrder.Columns.Remove("icebergQty");
            dataOpenOrder.Columns.Remove("status");
            dataOpenOrder.Columns.Remove("time");
            dataOpenOrder.Columns.Remove("isWorking");
            dataOpenOrder.Columns.Remove("timeInForce");
            

            dataOpenOrder.Columns["symbol"].HeaderText = "Symbol";
            dataOpenOrder.Columns["price"].HeaderText = "Price";
            dataOpenOrder.Columns["origQty"].HeaderText = "Quantity";
            dataOpenOrder.Columns["type"].HeaderText = "Type";
            dataOpenOrder.Columns["side"].HeaderText = "Side";
            dataOpenOrder.Columns["stopPrice"].HeaderText = "Stop Price";
            dataOpenOrder.Refresh();


            globalOpenorders = orders.ToList();
            RequestPerMinuteCount++;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnClose_mouseenter(object sender, EventArgs e)
        {
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
        }

        private void btnClose_mouseLeave(object sender, EventArgs e)
        {
            this.btnClose.BackColor = System.Drawing.Color.Red;
        }

        private void btnAddOrder_Click(object sender, EventArgs e)
        {
            // Create a new instance of the Form2 class
            AddOrder orderForm = new AddOrder();

            // Show the settings form
            orderForm.Show();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            //run after loading getOpenOrders();
            //deleteOrderWithSymbol("XLMUSDT", "SELL");
            //deleteOrderWithSymbol("XLMUSDT", "BUY");
            //postBUYOrder("XLMUSDT",100,0.145);
        }

        private void tradeMaker()
        {
            List<Trades> readTrade = JsonConvert.DeserializeObject<List<Trades>>(FilePath.readTrades());

            var tasks = readTrade.Select(async x =>
            {

                var currentPrice = await Account.checkPrice(x.symbol);

                if (currentPrice == (decimal)0.0)
                    return;

                if (x.transaction == TransactionType.STOPLOSSLOCAL && currentPrice <= x.stoplimit)
                {
                    if (await x.postSELLOrder() != null)
                        x.deleteLocalOrder();

                    Logger.Log("Auto Trade: STOPLOSSLOCAL" + " symbol: " + x.symbol + " quantity: " + x.quantity + " limit: " + x.limit + " stop limit: " + x.stoplimit);
                }
                else if (x.transaction == TransactionType.TAKE_PROFIT)
                {
                    //check at 30seconds
                    if (remoteCounter % 6 != 0)
                        return;

                    //**üstteki current price sil
                    //stoplossremote olmayan versiyonu da olmalı, eski tarz.
                    if (readTrade.Any(y => y.transaction == TransactionType.STOPLOSSREMOTE && y.parentId == x.id))
                    {

                        int stoplossid = readTrade.FirstOrDefault(f => f.parentId == x.id) != null ? readTrade.First(f => f.parentId == x.id).id : 0;

                        //check is order filled
                        await x.checkIsOrderFilled(stoplossid);

                        var stopTrade = readTrade.First(y => y.transaction == TransactionType.STOPLOSSREMOTE && y.parentId == x.id);
                        var average = (x.limit + stopTrade.limit) / 2;
                        long currentTimeSec = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
                        //eğer zaten ccurrent işlem önceki gibiyse işlem yapmasın.
                        //eğer remote işlem filled olduysa localde hem stoplossremote hem take_profit silsin.
                        //eğer current işlem önceki gibi değilse remote order da silecek.
                        //txtConsole.Text += Environment.NewLine + "DEĞERLERİ" + " CUR: " + currentPrice + " AVG: " + average+ " time:" + "limit: " + x.limit + " stopLimit: " + stopTrade.limit + DateTime.Now.ToString("f");
                        if (currentPrice >= average)
                        {
                            if (x.currentTransaction != "TAKE_PROFIT")
                            {
                                if (x.hasOrder)
                                {
                                    //remove old order
                                    await x.deleteOrderWithSymbol();
                                    Logger.Log("OLD ORDER REMOVE" + " symbol: " + x.symbol + " quantity: " + x.quantity + " limit: " + x.limit);
                                }

                                var postedOrder = await x.postSELLOrder();


                                readTrade.Where(z => z.id == x.id).ToList().ForEach(k => { k.currentTransaction = "TAKE_PROFIT"; k.hasOrder = true; k.origClientOrderId = postedOrder.clientOrderId; k.orderId = postedOrder.orderId; k.updateTimestamp = currentTimeSec; });
                                string jsonString = JsonConvert.SerializeObject(readTrade);
                                File.WriteAllText(FilePath.tradeFile, jsonString);
                            }
                        }
                        else
                        {
                            if (x.currentTransaction != "STOPLOSS_REMOTE")
                            {
                                if (x.hasOrder)
                                {
                                    //remove old order
                                    await x.deleteOrderWithSymbol();
                                    Logger.Log("OLD ORDER REMOVE" + " symbol: " + x.symbol + " quantity: " + x.quantity + " limit: " + x.limit);
                                }
                                var postedOrder = await stopTrade.postSTOPLOSSREMOTEOrder();
                                

                                readTrade.Where(z => z.id == x.id).ToList().ForEach(k => { k.currentTransaction = "STOPLOSS_REMOTE"; k.hasOrder = true; k.origClientOrderId = postedOrder.clientOrderId; k.orderId = postedOrder.orderId; k.updateTimestamp = currentTimeSec; });
                                string jsonString = JsonConvert.SerializeObject(readTrade);
                                File.WriteAllText(FilePath.tradeFile, jsonString);

                            }
                        }
                    }
                    else if (currentPrice <= x.limit)
                    {
                        if (await x.postSELLOrder() != null)
                            x.deleteLocalOrder();

                        Logger.Log("Auto Trade: SELL" + " symbol: " + x.symbol + " quantity: " + x.quantity + " limit: " + x.limit);
                    }
                }
                else if (x.transaction == TransactionType.BUY && currentPrice <= x.limit)
                {
                    if (await x.postBUYOrder() != null)
                    {
                        await releaseFutureTrades(x.id);
                        x.deleteLocalOrder();

                    }

                    Logger.Log("Auto Trade: BUY" + " symbol: " + x.symbol + " quantity: " + x.quantity + " limit: " + x.limit);
                }

            });

            Task.WhenAll(tasks);
        }
        private void timerTrade_Tick(object sender, EventArgs e)
        {          
            try
            {
                remoteCounter++;
                timerTrade.Enabled = false;
                checkLimits("tradeMaker");
                timerTrade.Enabled = true;
                tradeMaker();
               
            }
            catch(Exception ex)
            {
                Logger.Log("Auto Trade: " + ex.Message);
            }
        }

        private async Task releaseFutureTrades(int relId)
        {
            
            List<Trades> readFutureTrade = new List<Trades>();           
            readFutureTrade = JsonConvert.DeserializeObject<List<Trades>>(FilePath.readfutureTrades());         

            List<Trades> readTrade = new List<Trades>();
           
            readTrade = JsonConvert.DeserializeObject<List<Trades>>(FilePath.readTrades());
              

            if (!readFutureTrade.Any(x => x.relId == relId))
                return;

            foreach (var y in readFutureTrade.Where(x => x.relId == relId))
            {
                var newTrade = new Trades(y.symbol, (TransactionType)y.transaction, Convert.ToDecimal(y.stoplimit), Convert.ToDecimal(y.limit), Convert.ToDecimal(y.quantity));
                readTrade.Add(newTrade);
            }

            readFutureTrade.RemoveAll(x => x.relId == relId);

            string FuturejsonString = JsonConvert.SerializeObject(readFutureTrade);
            File.WriteAllText(FilePath.futureTrades, FuturejsonString);
            string jsonString = JsonConvert.SerializeObject(readTrade);
            File.WriteAllText(FilePath.tradeFile, jsonString);

        }
        private void dataLocalOrder_cellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataLocalOrders.Columns["delete_order"].Index)
            {
                string warningtext = "Are u sure?";
               
                DialogResult dialogResult = MessageBox.Show(warningtext, "Please Check", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.No)
                {
                    return;
                }
                
                Enum.TryParse(dataLocalOrders.Rows[e.RowIndex].Cells["transaction"].Value.ToString(), out TransactionType myTrans);

                Trades.getTradeWithId(Convert.ToInt32(dataLocalOrders.Rows[e.RowIndex].Cells["id"].Value)).deleteLocalOrder();

                loadTrades();
            }
        }

        private void chkTradeStatus_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTradeStatus.Checked)
            {
                chkTradeStatus.Text = "Trading Active";
                chkTradeStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(187)))), ((int)(((byte)(124)))));
                timerTrade.Enabled = true;
            }
            else
            {
                chkTradeStatus.Text = "Trading Off";
                chkTradeStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(71)))), ((int)(((byte)(86)))));
                timerTrade.Enabled = false;
            }
        }


        private void dataLocalOrder_headerClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
            if (dataLocalOrderProperty == dataLocalOrders.Columns[e.ColumnIndex].Name)
            dataLocalOrderCounter++;

            dataLocalOrderProperty = dataLocalOrders.Columns[e.ColumnIndex].Name;
            loadTrades();
        }

        private void dataAccount_HeaderClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataAccountProperty == dataAccount.Columns[e.ColumnIndex].Name)
                dataAccountCounter++;

            dataAccountProperty = dataAccount.Columns[e.ColumnIndex].Name;

            checkBalances();
        }

        

        public void checkLimits(string funcName)
        {
            int currentSecond = Convert.ToInt32(DateTime.Now.ToString("ss"));
            int waittime = 65 - currentSecond;
            if (RequestPerMinuteCount > 1000 && currentSecond < 59)
            {
                //wait for 60 seconds. Maybe make beautiful later.
                int i = 0;
                
                while (i < waittime)
                {
                    i++;
                    System.Threading.Thread.Sleep(1000);
                }
                
                //reset variables.
                RequestPerMinuteCount = 0;
            }
            else if (currentSecond == 59)
            {
                if(funcName == "priceChecker") { 
                lblLastMinReq.Text = RequestPerMinuteCount.ToString();
                RequestPerMinuteCount = 0;
                }
            }
            else
            {
                lblrequestscount.Text = RequestPerMinuteCount.ToString();
            }
        }
        private void timerPriceChecker_Tick(object sender, EventArgs e)
        {         
            //saniyede 10 request. dakika da 1200 request, saniye de 50 orders, günde 150.000 orders.
            timerCounter++;
            //long currentTimestamp = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeMilliseconds();
            timerPriceChecker.Enabled = false;
            checkLimits("priceChecker");
            timerPriceChecker.Enabled = true;
            //5 saniyede 1
            if (timerCounter % 5 == 0) {
                //checklatency. 1 request
                checkLatency();

                //kayıtlı tradeleri göster
                loadTrades();
            }

            //10 saniyede 1
            if (timerCounter % 10 == 0)
            {
                //getOpenOrders. 1 request
                getOpenOrders();

                //checkBalances. many request
                checkBalances();

            }

            //updatePrices();

            //checkbalance. 1 request
            //checkBalances();
        }
    }
}
