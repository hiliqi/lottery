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
            this.GameID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GameOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dealer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BetMoney = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Balance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlayTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.Dealer,
            this.BetMoney,
            this.Balance,
            this.Fee,
            this.PlayTime,
            this.Export});
            this.resultView.Location = new System.Drawing.Point(44, 45);
            this.resultView.Name = "resultView";
            this.resultView.RowTemplate.Height = 23;
            this.resultView.Size = new System.Drawing.Size(645, 380);
            this.resultView.TabIndex = 0;
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
            // 
            // Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 462);
            this.Controls.Add(this.resultView);
            this.Name = "Report";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "报表查看";
            ((System.ComponentModel.ISupportInitialize)(this.resultView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView resultView;
        private System.Windows.Forms.DataGridViewTextBoxColumn GameID;
        private System.Windows.Forms.DataGridViewTextBoxColumn GameOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dealer;
        private System.Windows.Forms.DataGridViewTextBoxColumn BetMoney;
        private System.Windows.Forms.DataGridViewTextBoxColumn Balance;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fee;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlayTime;
        private System.Windows.Forms.DataGridViewButtonColumn Export;
    }
}