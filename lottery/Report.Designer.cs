namespace lottery
{
    partial class Report
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
            this.resultView = new System.Windows.Forms.DataGridView();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.btnReloadView = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.cmbPlayer = new System.Windows.Forms.ComboBox();
            this.GameID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GameOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Profit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Balance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dealer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BetMoney = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DealerBalance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlayTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EndTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Export = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.resultView)).BeginInit();
            this.SuspendLayout();
            // 
            // resultView
            // 
            this.resultView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.resultView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.GameID,
            this.GameOrder,
            this.Profit,
            this.Balance,
            this.Dealer,
            this.BetMoney,
            this.DealerBalance,
            this.PlayTime,
            this.EndTime,
            this.Export});
            this.resultView.Location = new System.Drawing.Point(44, 47);
            this.resultView.Name = "resultView";
            this.resultView.RowTemplate.Height = 23;
            this.resultView.Size = new System.Drawing.Size(844, 403);
            this.resultView.TabIndex = 0;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(190, 16);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(122, 21);
            this.dateTimePicker1.TabIndex = 2;
            // 
            // btnReloadView
            // 
            this.btnReloadView.Location = new System.Drawing.Point(330, 14);
            this.btnReloadView.Name = "btnReloadView";
            this.btnReloadView.Size = new System.Drawing.Size(75, 23);
            this.btnReloadView.TabIndex = 3;
            this.btnReloadView.Text = "刷新报表";
            this.btnReloadView.UseVisualStyleBackColor = true;
            this.btnReloadView.Click += new System.EventHandler(this.btnReloadView_Click);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(411, 14);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 4;
            this.btnExport.Text = "导出";
            this.btnExport.UseVisualStyleBackColor = true;
            // 
            // cmbPlayer
            // 
            this.cmbPlayer.FormattingEnabled = true;
            this.cmbPlayer.Location = new System.Drawing.Point(44, 17);
            this.cmbPlayer.Name = "cmbPlayer";
            this.cmbPlayer.Size = new System.Drawing.Size(121, 20);
            this.cmbPlayer.TabIndex = 5;
            // 
            // GameID
            // 
            this.GameID.HeaderText = "gameid";
            this.GameID.Name = "GameID";
            this.GameID.ReadOnly = true;
            this.GameID.Visible = false;
            // 
            // GameOrder
            // 
            this.GameOrder.HeaderText = "局数";
            this.GameOrder.Name = "GameOrder";
            this.GameOrder.ReadOnly = true;
            // 
            // Profit
            // 
            this.Profit.HeaderText = "盈亏";
            this.Profit.Name = "Profit";
            this.Profit.ReadOnly = true;
            // 
            // Balance
            // 
            this.Balance.HeaderText = "结余";
            this.Balance.Name = "Balance";
            this.Balance.ReadOnly = true;
            // 
            // Dealer
            // 
            this.Dealer.HeaderText = "庄家";
            this.Dealer.Name = "Dealer";
            this.Dealer.ReadOnly = true;
            this.Dealer.Visible = false;
            // 
            // BetMoney
            // 
            this.BetMoney.HeaderText = "开庄金额";
            this.BetMoney.Name = "BetMoney";
            this.BetMoney.ReadOnly = true;
            // 
            // DealerBalance
            // 
            this.DealerBalance.HeaderText = "庄家结余";
            this.DealerBalance.Name = "DealerBalance";
            this.DealerBalance.ReadOnly = true;
            // 
            // PlayTime
            // 
            this.PlayTime.HeaderText = "开庄时间";
            this.PlayTime.Name = "PlayTime";
            this.PlayTime.ReadOnly = true;
            // 
            // EndTime
            // 
            this.EndTime.HeaderText = "下庄时间";
            this.EndTime.Name = "EndTime";
            this.EndTime.ReadOnly = true;
            // 
            // Export
            // 
            this.Export.HeaderText = "导出";
            this.Export.Name = "Export";
            this.Export.ReadOnly = true;
            this.Export.Text = "导出本局";
            this.Export.UseColumnTextForButtonValue = true;
            // 
            // Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 462);
            this.Controls.Add(this.cmbPlayer);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnReloadView);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.resultView);
            this.Name = "Report";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "报表查看";
            ((System.ComponentModel.ISupportInitialize)(this.resultView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView resultView;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button btnReloadView;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.ComboBox cmbPlayer;
        private System.Windows.Forms.DataGridViewTextBoxColumn GameID;
        private System.Windows.Forms.DataGridViewTextBoxColumn GameOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn Profit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Balance;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dealer;
        private System.Windows.Forms.DataGridViewTextBoxColumn BetMoney;
        private System.Windows.Forms.DataGridViewTextBoxColumn DealerBalance;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlayTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn EndTime;
        private System.Windows.Forms.DataGridViewButtonColumn Export;
    }
}