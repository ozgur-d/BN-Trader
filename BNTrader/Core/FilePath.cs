using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BNTrader.Core
{
    class FilePath
    {
        public static string cfgFile = "config.json";
        public static string tradeFile = "trades.json";
        public static string logFile = "consolelog.txt";
        public static string idHolder = "idHolder.txt";
        public static string futureTrades = "futureTrades.json";

        public static string readSettings()
        {           
            if (!File.Exists(cfgFile))
            {
                Logger.Log("Cannot Found Config.json");

                Settings newSetting = new Settings{
                    apiKey = "",
                    secretKey = "",
                    tradeStatus = false,
                };

                string jsonString = JsonConvert.SerializeObject(newSetting);
                File.WriteAllText(cfgFile, jsonString);

                Logger.Log("Created config file but you must edit.");
                MessageBox.Show("You must edit config file");
                throw new Exception("You must edit config file");
                return "";
            }
            
            var cfgJson = System.IO.File.ReadAllText(cfgFile);
            Settings readcfg = JsonConvert.DeserializeObject<Settings>(cfgJson);
            if(string.IsNullOrEmpty(readcfg.apiKey) || string.IsNullOrEmpty(readcfg.secretKey))
            {
                Logger.Log("Api key cannot be empty. Edit config file.");
                MessageBox.Show("You must edit config file");
                throw new Exception("You must edit config file");
            }
            
            return cfgJson;
        }

        public static string readTrades()
        {
            
            if (!File.Exists(tradeFile))
            {
                List<Trades> readTrade = new List<Trades>();
                string jsonString = JsonConvert.SerializeObject(readTrade);
                File.WriteAllText(tradeFile, jsonString);
                Logger.Log("Trades cannot find, it's created.");
            }

            var tradeJson = File.ReadAllText(tradeFile);

            if (string.IsNullOrEmpty(tradeJson))
            {
                return "[]";
            }

            return tradeJson;
        }

        public static string readfutureTrades()
        {
            if (!File.Exists(futureTrades))
            {    
                File.WriteAllText(futureTrades, "[]");
                Logger.Log("Future Trades cannot find, it's created.");
            }

            var getFutureTradesJson = File.ReadAllText(futureTrades);

            if (!string.IsNullOrEmpty(getFutureTradesJson))
            {
                return getFutureTradesJson;
            }
            else
            {
                return "[]";
            }
        }
    }
}
