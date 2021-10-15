using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BNTrader.Core;
using System.IO;
using Newtonsoft.Json;

namespace BNTrader
{
    public partial class AddOrder : Form
    {
        decimal commissionRate = (decimal)0.999;
        public AddOrder()
        {
            InitializeComponent();
            comboTransTypes.DataSource = Enum.GetValues(typeof(TransactionType));
            
        }

        private void comboTransTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if((TransactionType)comboTransTypes.SelectedItem == TransactionType.STOPLOSSLOCAL)
            {
                txtStopPrice.Enabled = true;
            }
            else
            {
                txtStopPrice.Text = "0";
                txtStopPrice.Enabled = false;
               
            }

            if ((TransactionType)comboTransTypes.SelectedItem == TransactionType.TAKE_PROFIT || (TransactionType)comboTransTypes.SelectedItem == TransactionType.BUY)
            {
                pnlRemoteStopLoss.Enabled = true;
            }
            else
            {
                pnlRemoteStopLoss.Enabled = false;
            }

            if ((TransactionType)comboTransTypes.SelectedItem == TransactionType.BUY)
            {
                pnlAfterBuy.Enabled = true;
            }
            else
            {
                pnlAfterBuy.Enabled = false;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string warningtext = "If price reach the "+ txtLimitPrice.Text + " you will place an order for this price.";
            if ((TransactionType)comboTransTypes.SelectedItem == TransactionType.STOPLOSSLOCAL)
            {
                warningtext = "If price reach the " + txtStopPrice.Text + " you will place an order for " + txtLimitPrice.Text;
            }

            DialogResult dialogResult = MessageBox.Show(warningtext, "Please Check", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.No)
            {
                return;
            }

            List<Trades> readTrade = new List<Trades>();
            List<Trades> readFutureTrade = new List<Trades>();
            
            readTrade = JsonConvert.DeserializeObject<List<Trades>>(FilePath.readTrades());
           
           
            //add new
            var newTrade = new Trades(txtSymbol.Text, (TransactionType)comboTransTypes.SelectedItem, Convert.ToDecimal(txtStopPrice.Text), Convert.ToDecimal(txtLimitPrice.Text), Convert.ToDecimal(txtQuantity.Text));
            readTrade.Add(newTrade);

            if((TransactionType)comboTransTypes.SelectedItem == TransactionType.TAKE_PROFIT && chkRemoteStopLoss.Checked)
            {
                var stopLossTrade = new Trades(txtSymbol.Text, TransactionType.STOPLOSSREMOTE, Convert.ToDecimal(txtRemoteStopPrice.Text), Convert.ToDecimal(txtRemoteLimitPrice.Text), Convert.ToDecimal(txtQuantity.Text));
                stopLossTrade.parentId = newTrade.id;
                readTrade.Add(stopLossTrade);
            }

            if ((TransactionType)comboTransTypes.SelectedItem == TransactionType.BUY)
            {
                //read old values
                 
                readFutureTrade = JsonConvert.DeserializeObject<List<Trades>>(FilePath.readfutureTrades());
                

                var takeprofitId = 0;
                if (chkTakeProfit.Checked) {
                    var takeProfit = new Trades(txtSymbol.Text, TransactionType.TAKE_PROFIT, Convert.ToDecimal(txtRemoteStopPrice.Text), Convert.ToDecimal(txtTakeProfit.Text), (Convert.ToDecimal(txtQuantity.Text)*commissionRate));
                    takeProfit.relId = newTrade.id;
                    readFutureTrade.Add(takeProfit);
                    takeprofitId = takeProfit.id;
                }
                if (chkRemoteStopLoss.Checked)
                {
                    var stopLossTrade = new Trades(txtSymbol.Text, TransactionType.STOPLOSSREMOTE, Convert.ToDecimal(txtRemoteStopPrice.Text), Convert.ToDecimal(txtRemoteLimitPrice.Text), (Convert.ToDecimal(txtQuantity.Text)*commissionRate));
                    stopLossTrade.relId = newTrade.id;
                    stopLossTrade.parentId = takeprofitId;
                    readFutureTrade.Add(stopLossTrade);
                }
                if(chkTakeProfit.Checked || chkRemoteStopLoss.Checked)
                {
                    string FuturejsonString = JsonConvert.SerializeObject(readFutureTrade);
                    File.WriteAllText(FilePath.futureTrades, FuturejsonString);
                }
                
            }
            //save
            string jsonString = JsonConvert.SerializeObject(readTrade);
            File.WriteAllText(FilePath.tradeFile, jsonString);
        }

        private void txtStopPrice_changed(object sender, EventArgs e)
        {
            txtStopPrice.Text = txtStopPrice.Text.Replace('.', ',');
            txtStopPrice.SelectionStart = txtStopPrice.Text.Length;
            txtStopPrice.SelectionLength = 0;
        }

        private void txtLimitPrice_changed(object sender, EventArgs e)
        {
            txtLimitPrice.Text = txtLimitPrice.Text.Replace('.', ',');
            txtLimitPrice.SelectionStart = txtLimitPrice.Text.Length;
            txtLimitPrice.SelectionLength = 0;
        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            txtQuantity.Text = txtQuantity.Text.Replace('.', ',');
            txtQuantity.SelectionStart = txtQuantity.Text.Length;
            txtQuantity.SelectionLength = 0;
        }

        private void txtTakeProfit_TextChanged(object sender, EventArgs e)
        {
            txtTakeProfit.Text = txtTakeProfit.Text.Replace('.', ',');
            txtTakeProfit.SelectionStart = txtTakeProfit.Text.Length;
            txtTakeProfit.SelectionLength = 0;
        }

        private void txtRemoteStopPrice_TextChanged(object sender, EventArgs e)
        {
            txtRemoteStopPrice.Text = txtRemoteStopPrice.Text.Replace('.', ',');
            txtRemoteStopPrice.SelectionStart = txtRemoteStopPrice.Text.Length;
            txtRemoteStopPrice.SelectionLength = 0;
        }

        private void txtRemoteLimitPrice_TextChanged(object sender, EventArgs e)
        {
            txtRemoteLimitPrice.Text = txtRemoteLimitPrice.Text.Replace('.', ',');
            txtRemoteLimitPrice.SelectionStart = txtRemoteLimitPrice.Text.Length;
            txtRemoteLimitPrice.SelectionLength = 0;
        }

        private void chkTakeProfit_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTakeProfit.Checked)
            {
                chkRemoteStopLoss.Checked = true;
                //stop loss mecburi
                chkRemoteStopLoss.Text += " Necessary!!";
            }
        }
    }
}
