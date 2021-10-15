
namespace BNTrader
{
    partial class AddOrder
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtSymbol = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtStopPrice = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboTransTypes = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtLimitPrice = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.pnlRemoteStopLoss = new System.Windows.Forms.Panel();
            this.txtRemoteLimitPrice = new System.Windows.Forms.TextBox();
            this.txtRemoteStopPrice = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.chkRemoteStopLoss = new System.Windows.Forms.CheckBox();
            this.pnlAfterBuy = new System.Windows.Forms.Panel();
            this.txtTakeProfit = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.chkTakeProfit = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.pnlRemoteStopLoss.SuspendLayout();
            this.pnlAfterBuy.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtSymbol
            // 
            this.txtSymbol.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSymbol.Location = new System.Drawing.Point(12, 43);
            this.txtSymbol.Name = "txtSymbol";
            this.txtSymbol.Size = new System.Drawing.Size(143, 23);
            this.txtSymbol.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "SYMBOL";
            // 
            // txtStopPrice
            // 
            this.txtStopPrice.Enabled = false;
            this.txtStopPrice.Location = new System.Drawing.Point(12, 260);
            this.txtStopPrice.Name = "txtStopPrice";
            this.txtStopPrice.Size = new System.Drawing.Size(143, 23);
            this.txtStopPrice.TabIndex = 2;
            this.txtStopPrice.Text = "0";
            this.txtStopPrice.TextChanged += new System.EventHandler(this.txtStopPrice_changed);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Transaction Type";
            // 
            // comboTransTypes
            // 
            this.comboTransTypes.FormattingEnabled = true;
            this.comboTransTypes.Location = new System.Drawing.Point(12, 103);
            this.comboTransTypes.Name = "comboTransTypes";
            this.comboTransTypes.Size = new System.Drawing.Size(143, 23);
            this.comboTransTypes.TabIndex = 4;
            this.comboTransTypes.SelectedIndexChanged += new System.EventHandler(this.comboTransTypes_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 236);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Stop Price";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 192);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Limit Price";
            // 
            // txtLimitPrice
            // 
            this.txtLimitPrice.Location = new System.Drawing.Point(12, 210);
            this.txtLimitPrice.Name = "txtLimitPrice";
            this.txtLimitPrice.Size = new System.Drawing.Size(143, 23);
            this.txtLimitPrice.TabIndex = 7;
            this.txtLimitPrice.TextChanged += new System.EventHandler(this.txtLimitPrice_changed);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(211, 247);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(237, 36);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "Add An Order";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 137);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "Quantity";
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(12, 163);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(143, 23);
            this.txtQuantity.TabIndex = 10;
            this.txtQuantity.TextChanged += new System.EventHandler(this.txtQuantity_TextChanged);
            // 
            // pnlRemoteStopLoss
            // 
            this.pnlRemoteStopLoss.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlRemoteStopLoss.Controls.Add(this.txtRemoteLimitPrice);
            this.pnlRemoteStopLoss.Controls.Add(this.txtRemoteStopPrice);
            this.pnlRemoteStopLoss.Controls.Add(this.label8);
            this.pnlRemoteStopLoss.Controls.Add(this.label7);
            this.pnlRemoteStopLoss.Controls.Add(this.label6);
            this.pnlRemoteStopLoss.Controls.Add(this.chkRemoteStopLoss);
            this.pnlRemoteStopLoss.Enabled = false;
            this.pnlRemoteStopLoss.Location = new System.Drawing.Point(211, 22);
            this.pnlRemoteStopLoss.Name = "pnlRemoteStopLoss";
            this.pnlRemoteStopLoss.Size = new System.Drawing.Size(237, 193);
            this.pnlRemoteStopLoss.TabIndex = 11;
            // 
            // txtRemoteLimitPrice
            // 
            this.txtRemoteLimitPrice.Location = new System.Drawing.Point(9, 141);
            this.txtRemoteLimitPrice.Name = "txtRemoteLimitPrice";
            this.txtRemoteLimitPrice.Size = new System.Drawing.Size(115, 23);
            this.txtRemoteLimitPrice.TabIndex = 5;
            this.txtRemoteLimitPrice.TextChanged += new System.EventHandler(this.txtRemoteLimitPrice_TextChanged);
            // 
            // txtRemoteStopPrice
            // 
            this.txtRemoteStopPrice.Location = new System.Drawing.Point(9, 81);
            this.txtRemoteStopPrice.Name = "txtRemoteStopPrice";
            this.txtRemoteStopPrice.Size = new System.Drawing.Size(115, 23);
            this.txtRemoteStopPrice.TabIndex = 4;
            this.txtRemoteStopPrice.TextChanged += new System.EventHandler(this.txtRemoteStopPrice_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 115);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 15);
            this.label8.TabIndex = 3;
            this.label8.Text = "Limit Price";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 56);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 15);
            this.label7.TabIndex = 2;
            this.label7.Text = "Stop Limit Price";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(159, 15);
            this.label6.TabIndex = 1;
            this.label6.Text = "Take Profit Stop Loss Remote";
            // 
            // chkRemoteStopLoss
            // 
            this.chkRemoteStopLoss.AutoSize = true;
            this.chkRemoteStopLoss.Location = new System.Drawing.Point(9, 30);
            this.chkRemoteStopLoss.Name = "chkRemoteStopLoss";
            this.chkRemoteStopLoss.Size = new System.Drawing.Size(147, 19);
            this.chkRemoteStopLoss.TabIndex = 0;
            this.chkRemoteStopLoss.Text = "Do you want stop loss?";
            this.chkRemoteStopLoss.UseVisualStyleBackColor = true;
            // 
            // pnlAfterBuy
            // 
            this.pnlAfterBuy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAfterBuy.Controls.Add(this.txtTakeProfit);
            this.pnlAfterBuy.Controls.Add(this.label10);
            this.pnlAfterBuy.Controls.Add(this.chkTakeProfit);
            this.pnlAfterBuy.Controls.Add(this.label9);
            this.pnlAfterBuy.Enabled = false;
            this.pnlAfterBuy.Location = new System.Drawing.Point(464, 22);
            this.pnlAfterBuy.Name = "pnlAfterBuy";
            this.pnlAfterBuy.Size = new System.Drawing.Size(234, 193);
            this.pnlAfterBuy.TabIndex = 12;
            // 
            // txtTakeProfit
            // 
            this.txtTakeProfit.Location = new System.Drawing.Point(12, 81);
            this.txtTakeProfit.Name = "txtTakeProfit";
            this.txtTakeProfit.Size = new System.Drawing.Size(114, 23);
            this.txtTakeProfit.TabIndex = 3;
            this.txtTakeProfit.TextChanged += new System.EventHandler(this.txtTakeProfit_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 56);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(92, 15);
            this.label10.TabIndex = 2;
            this.label10.Text = "Take Profit Limit";
            // 
            // chkTakeProfit
            // 
            this.chkTakeProfit.AutoSize = true;
            this.chkTakeProfit.Location = new System.Drawing.Point(12, 30);
            this.chkTakeProfit.Name = "chkTakeProfit";
            this.chkTakeProfit.Size = new System.Drawing.Size(155, 19);
            this.chkTakeProfit.TabIndex = 1;
            this.chkTakeProfit.Text = "Do you want take profit?";
            this.chkTakeProfit.UseVisualStyleBackColor = true;
            this.chkTakeProfit.CheckedChanged += new System.EventHandler(this.chkTakeProfit_CheckedChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 7);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(114, 15);
            this.label9.TabIndex = 0;
            this.label9.Text = "Take Profit After Buy";
            // 
            // AddOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 295);
            this.Controls.Add(this.pnlAfterBuy);
            this.Controls.Add(this.pnlRemoteStopLoss);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtLimitPrice);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboTransTypes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtStopPrice);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSymbol);
            this.Name = "AddOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddOrder";
            this.pnlRemoteStopLoss.ResumeLayout(false);
            this.pnlRemoteStopLoss.PerformLayout();
            this.pnlAfterBuy.ResumeLayout(false);
            this.pnlAfterBuy.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSymbol;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtStopPrice;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboTransTypes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtLimitPrice;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Panel pnlRemoteStopLoss;
        private System.Windows.Forms.CheckBox chkRemoteStopLoss;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtRemoteLimitPrice;
        private System.Windows.Forms.TextBox txtRemoteStopPrice;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel pnlAfterBuy;
        private System.Windows.Forms.TextBox txtTakeProfit;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox chkTakeProfit;
        private System.Windows.Forms.Label label9;
    }
}