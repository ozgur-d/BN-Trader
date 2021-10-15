using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BNTrader.Core
{
    class Logger
    {
        
        public static async Task Log(string msg)
        {
            msg = Environment.NewLine + msg + " Time: "+ DateTime.Now.ToString("G");
         
            MainForm.form.updateLogText(msg);
            

            File.AppendAllText(FilePath.logFile, msg);
        }
    }
}
