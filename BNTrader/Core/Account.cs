using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BNTrader.Core
{
    class Account
    {
        public string symbol { get; set; }
        public decimal amount { get; set; }
        public decimal value { get; set; }
        public decimal totalvalue { get; set; }

        public static string convertToCurrencyStr = "USDT";

        public Account(string symbol, decimal amount, decimal value, decimal totalvalue)
        {
            this.symbol = symbol;
            this.amount = amount;
            this.value = value;
            this.totalvalue = totalvalue;
        }
        
        public static async Task<decimal> checkPrice(string symbol)
        {
            try
            {
                var cryptos = await MainForm.binance.Get24HourStatsAsync(symbol);
                //txtConsole.Text += Environment.NewLine + symbol + " " + cryptos[0].lastPrice;

                MainForm.RequestPerMinuteCount++;
                if (cryptos != null)
                {
                    return Convert.ToDecimal(cryptos[0].lastPrice, new System.Globalization.CultureInfo("en-US"));
                }
                else if (symbol != (convertToCurrencyStr + convertToCurrencyStr))
                {
                    Logger.Log("checkPrice - No Internet. Waiting.");
                }
                else if (symbol == (convertToCurrencyStr + convertToCurrencyStr))
                {
                    return (decimal)1.0;
                }

                return (decimal)0.0;
            }
            catch (Exception ex)
            {

                Logger.Log("checkPrice: " + ex.Message);
                return (decimal)0.0;
            }
        }


        public async Task exChangeInfo()
        {

            var exchangeInfo = await MainForm.binance.GetExchangeInfoAsync();
            foreach (var x in exchangeInfo.rateLimits)
            {

                Logger.Log(x.rateLimitType + " " + x.limit + " interval " + x.interval);
            }
            MainForm.RequestPerMinuteCount++;
        }



    }
}
