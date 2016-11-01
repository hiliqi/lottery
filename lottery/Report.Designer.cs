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
            this.lbMsg = new System.Windows.Forms.Label();
            this.GameID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GameOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dealer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BetMoney = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Balance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlayTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Export = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.btnReloadView = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.resultView)).BeginInit();
            this.SuspendLayout();
            // 
            // resultView
            // 
            this.resultView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.resultView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.GameID,
            this.GameOrder,
            this.Dealer,
            this.BetMoney,
            this.Balance,
            this.Fee,
            this.PlayTime,
            this.Export});
            this.resultView.Location = new System.Drawing.Point(44, 47);
            this.resultView.Name = "resultView";
            this.resultView.RowTemplate.Height = 23;
            this.resultView.Size = new System.Drawing.Size(645, 380);
            this.resultView.TabIndex = 0;
            // 
            // lbMsg
            // 
            this.lbMsg.AutoSize = true;
            this.lbMsg.Location = new System.Drawing.Point(42, 25);
            this.lbMsg.Name = "lbMsg";
            this.lbMsg.Size = new System.Drawing.Size(41, 12);
            this.lbMsg.TabIndex = 1;
            this.lbMsg.Text = "label1";
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
            // Balance
            // 
            this.Balance.HeaderText = "庄家结余";
            this.Balance.Name = "Balance";
            this.Balance.ReadOnly = true;
            // 
            // Fee
            // 
            this.Fee.HeaderText = "平台抽成";
            this.Fee.Name = "Fee";
            this.Fee.ReadOnly = true;
            // 
            // PlayTime
            // 
            this.PlayTime.HeaderText = "开庄时间";
            this.PlayTime.Name = "PlayTime";
            this.PlayTime.ReadOnly = true;
            // 
            // Export
            // 
            this.Export.HeaderText = "导出";
            this.Export.Name = "Export";
            this.Export.ReadOnly = true;
            this.Export.Text = "导出本局";
            this.Export.UseColumnTextForButtonValue = true;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(229, 16);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(122, 21);
            this.dateTimePicker1.TabIndex = 2;
            // 
            // btnReloadView
            // 
            this.btnReloadView.Location = new System.Drawing.Point(366, 14);
            this.btnReloadView.Name = "btnReloadView";
            this.btnReloadView.Size = new System.Drawing.Size(75, 23);
            this.btnReloadView.TabIndex = 3;
            this.btnReloadView.Text = "刷新报表";
            this.btnReloadView.UseVisualStyleBackColor = true;
            this.btnReloadView.Click += new System.EventHandler(this.btnReloadView_Click);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(447, 14);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 4;
            this.btnExport.Text = "导出";
            this.btnExport.UseVisualStyleBackColor = true;
            // 
            // Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 462);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnReloadView);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.lbMsg);
            this.Controls.Add(this.resultView);
            this.Name = "Report";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "报表查看";
            ((System.ComponentModel.ISupportInitialize)(this.resultView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView resultView;
        private System.Windows.Forms.Label lbMsg;
        private System.Windows.Forms.DataGridViewTextBoxColumn GameID;
        private System.Windows.Forms.DataGridViewTextBoxColumn GameOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dealer;
        private System.Windows.Forms.DataGridViewTextBoxColumn BetMoney;
        private System.Windows.Forms.DataGridViewTextBoxColumn Balance;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fee;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlayTime;
        private System.Windows.Forms.DataGridViewButtonColumn Export;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button btnReloadView;
        private System.Windows.Forms.Button btnExport;
    }
}