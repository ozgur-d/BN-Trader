
namespace BNTrader
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.txtConsole = new System.Windows.Forms.TextBox();
            this.lblTxt1 = new System.Windows.Forms.Label();
            this.timerPriceChecker = new System.Windows.Forms.Timer(this.components);
            this.lblTxt2 = new System.Windows.Forms.Label();
            this.lblDelay = new System.Windows.Forms.Label();
            this.lblTxt3 = new System.Windows.Forms.Label();
            this.lblrequestscount = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.dataAccount = new System.Windows.Forms.DataGridView();
            this.dataOpenOrder = new System.Windows.Forms.DataGridView();
            this.dataLocalOrders = new System.Windows.Forms.DataGridView();
            this.btnAddOrder = new System.Windows.Forms.Button();
            this.btnTest = new System.Windows.Forms.Button();
            this.timerTrade = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.chkTradeStatus = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblLastMinReq = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataAccount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataOpenOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLocalOrders)).BeginInit();
            this.SuspendLayout();
            // 
            // txtConsole
            // 
            this.txtConsole.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.txtConsole.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(157)))), ((int)(((byte)(143)))));
            this.txtConsole.Location = new System.Drawing.Point(12, 916);
            this.txtConsole.Multiline = true;
            this.txtConsole.Name = "txtConsole";
            this.txtConsole.ReadOnly = true;
            this.txtConsole.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtConsole.Size = new System.Drawing.Size(1896, 121);
            this.txtConsole.TabIndex = 0;
            
            // 
            // lblTxt1
            // 
            this.lblTxt1.AutoSize = true;
            this.lblTxt1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTxt1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(157)))), ((int)(((byte)(143)))));
            this.lblTxt1.Location = new System.Drawing.Point(12, 883);
            this.lblTxt1.Name = "lblTxt1";
            this.lblTxt1.Size = new System.Drawing.Size(57, 17);
            this.lblTxt1.TabIndex = 1;
            this.lblTxt1.Text = "Console";
            // 
            // timerPriceChecker
            // 
            this.timerPriceChecker.Enabled = true;
            this.timerPriceChecker.Interval = 1000;
            this.timerPriceChecker.Tick += new System.EventHandler(this.timerPriceChecker_Tick);
            // 
            // lblTxt2
            // 
            this.lblTxt2.AutoSize = true;
            this.lblTxt2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTxt2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(157)))), ((int)(((byte)(143)))));
            this.lblTxt2.Location = new System.Drawing.Point(1791, 1054);
            this.lblTxt2.Name = "lblTxt2";
            this.lblTxt2.Size = new System.Drawing.Size(59, 17);
            this.lblTxt2.TabIndex = 2;
            this.lblTxt2.Text = "Latency:";
            // 
            // lblDelay
            // 
            this.lblDelay.AutoSize = true;
            this.lblDelay.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblDelay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(157)))), ((int)(((byte)(143)))));
            this.lblDelay.Location = new System.Drawing.Point(1856, 1054);
            this.lblDelay.Name = "lblDelay";
            this.lblDelay.Size = new System.Drawing.Size(47, 17);
            this.lblDelay.TabIndex = 3;
            this.lblDelay.Text = "100ms";
            // 
            // lblTxt3
            // 
            this.lblTxt3.AutoSize = true;
            this.lblTxt3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTxt3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(157)))), ((int)(((byte)(143)))));
            this.lblTxt3.Location = new System.Drawing.Point(12, 1054);
            this.lblTxt3.Name = "lblTxt3";
            this.lblTxt3.Size = new System.Drawing.Size(139, 17);
            this.lblTxt3.TabIndex = 4;
            this.lblTxt3.Text = "Requests Per Minute:";
            // 
            // lblrequestscount
            // 
            this.lblrequestscount.AutoSize = true;
            this.lblrequestscount.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblrequestscount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(157)))), ((int)(((byte)(143)))));
            this.lblrequestscount.Location = new System.Drawing.Point(157, 1054);
            this.lblrequestscount.Name = "lblrequestscount";
            this.lblrequestscount.Size = new System.Drawing.Size(15, 17);
            this.lblrequestscount.TabIndex = 5;
            this.lblrequestscount.Text = "0";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Red;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(1867, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(53, 35);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            this.btnClose.Enter += new System.EventHandler(this.btnClose_mouseenter);
            this.btnClose.Leave += new System.EventHandler(this.btnClose_mouseLeave);
            // 
            // dataAccount
            // 
            this.dataAccount.AllowUserToAddRows = false;
            this.dataAccount.AllowUserToDeleteRows = false;
            this.dataAccount.AllowUserToOrderColumns = true;
            this.dataAccount.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataAccount.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataAccount.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataAccount.Location = new System.Drawing.Point(923, 53);
            this.dataAccount.Name = "dataAccount";
            this.dataAccount.RowTemplate.Height = 25;
            this.dataAccount.Size = new System.Drawing.Size(985, 473);
            this.dataAccount.TabIndex = 7;
            this.dataAccount.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataAccount_HeaderClick);
            // 
            // dataOpenOrder
            // 
            this.dataOpenOrder.AllowUserToAddRows = false;
            this.dataOpenOrder.AllowUserToDeleteRows = false;
            this.dataOpenOrder.AllowUserToOrderColumns = true;
            this.dataOpenOrder.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataOpenOrder.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dataOpenOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataOpenOrder.Location = new System.Drawing.Point(923, 562);
            this.dataOpenOrder.Name = "dataOpenOrder";
            this.dataOpenOrder.RowTemplate.Height = 25;
            this.dataOpenOrder.Size = new System.Drawing.Size(985, 325);
            this.dataOpenOrder.TabIndex = 8;
            // 
            // dataLocalOrders
            // 
            this.dataLocalOrders.AllowUserToAddRows = false;
            this.dataLocalOrders.AllowUserToDeleteRows = false;
            this.dataLocalOrders.AllowUserToOrderColumns = true;
            this.dataLocalOrders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataLocalOrders.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dataLocalOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataLocalOrders.Location = new System.Drawing.Point(27, 53);
            this.dataLocalOrders.Name = "dataLocalOrders";
            this.dataLocalOrders.ReadOnly = true;
            this.dataLocalOrders.RowTemplate.Height = 25;
            this.dataLocalOrders.Size = new System.Drawing.Size(869, 713);
            this.dataLocalOrders.TabIndex = 9;
            this.dataLocalOrders.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataLocalOrder_cellClick);
            this.dataLocalOrders.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataLocalOrder_headerClick);
            // 
            // btnAddOrder
            // 
            this.btnAddOrder.Location = new System.Drawing.Point(27, 812);
            this.btnAddOrder.Name = "btnAddOrder";
            this.btnAddOrder.Size = new System.Drawing.Size(124, 41);
            this.btnAddOrder.TabIndex = 10;
            this.btnAddOrder.Text = "Add an  Order";
            this.btnAddOrder.UseVisualStyleBackColor = true;
            this.btnAddOrder.Click += new System.EventHandler(this.btnAddOrder_Click);
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(808, 812);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(88, 40);
            this.btnTest.TabIndex = 11;
            this.btnTest.Text = "Test Func";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Visible = false;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // timerTrade
            // 
            this.timerTrade.Interval = 5000;
            this.timerTrade.Tick += new System.EventHandler(this.timerTrade_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(157)))), ((int)(((byte)(143)))));
            this.label1.Location = new System.Drawing.Point(923, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 17);
            this.label1.TabIndex = 12;
            this.label1.Text = "Account Details";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(157)))), ((int)(((byte)(143)))));
            this.label2.Location = new System.Drawing.Point(923, 541);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 17);
            this.label2.TabIndex = 13;
            this.label2.Text = "Remote Orders";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(157)))), ((int)(((byte)(143)))));
            this.label3.Location = new System.Drawing.Point(31, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 17);
            this.label3.TabIndex = 14;
            this.label3.Text = "Local Orders";
            // 
            // chkTradeStatus
            // 
            this.chkTradeStatus.AutoSize = true;
            this.chkTradeStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(71)))), ((int)(((byte)(86)))));
            this.chkTradeStatus.Location = new System.Drawing.Point(31, 781);
            this.chkTradeStatus.Name = "chkTradeStatus";
            this.chkTradeStatus.Size = new System.Drawing.Size(85, 19);
            this.chkTradeStatus.TabIndex = 15;
            this.chkTradeStatus.Text = "Trading Off";
            this.chkTradeStatus.UseVisualStyleBackColor = true;
            this.chkTradeStatus.CheckedChanged += new System.EventHandler(this.chkTradeStatus_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(157)))), ((int)(((byte)(143)))));
            this.label4.Location = new System.Drawing.Point(195, 1056);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(152, 17);
            this.label4.TabIndex = 16;
            this.label4.Text = "/ Last Minute Request: ";
            // 
            // lblLastMinReq
            // 
            this.lblLastMinReq.AutoSize = true;
            this.lblLastMinReq.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblLastMinReq.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(157)))), ((int)(((byte)(143)))));
            this.lblLastMinReq.Location = new System.Drawing.Point(353, 1056);
            this.lblLastMinReq.Name = "lblLastMinReq";
            this.lblLastMinReq.Size = new System.Drawing.Size(15, 17);
            this.lblLastMinReq.TabIndex = 17;
            this.lblLastMinReq.Text = "0";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.lblLastMinReq);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.chkTradeStatus);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.btnAddOrder);
            this.Controls.Add(this.dataLocalOrders);
            this.Controls.Add(this.dataOpenOrder);
            this.Controls.Add(this.dataAccount);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblrequestscount);
            this.Controls.Add(this.lblTxt3);
            this.Controls.Add(this.lblDelay);
            this.Controls.Add(this.lblTxt2);
            this.Controls.Add(this.lblTxt1);
            this.Controls.Add(this.txtConsole);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BNTrader";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataAccount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataOpenOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLocalOrders)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtConsole;
        private System.Windows.Forms.Label lblTxt1;
        private System.Windows.Forms.Timer timerPriceChecker;
        private System.Windows.Forms.Label lblTxt2;
        private System.Windows.Forms.Label lblDelay;
        private System.Windows.Forms.Label lblTxt3;
        private System.Windows.Forms.Label lblrequestscount;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView dataAccount;
        private System.Windows.Forms.DataGridView dataOpenOrder;
        private System.Windows.Forms.DataGridView dataLocalOrders;
        private System.Windows.Forms.Button btnAddOrder;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Timer timerTrade;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkTradeStatus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblLastMinReq;
    }
}

