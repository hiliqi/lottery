namespace lottery
{
    partial class Detail
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
            this.detailView = new System.Windows.Forms.DataGridView();
            this.lbName = new System.Windows.Forms.Label();
            this.BetMoney = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Multiple = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DealerPoint = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Profit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Balance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RoundOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.detailView)).BeginInit();
            this.SuspendLayout();
            // 
            // detailView
            // 
            this.detailView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.detailView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BetMoney,
            this.Multiple,
            this.DealerPoint,
            this.Profit,
            this.Balance,
            this.RoundOrder});
            this.detailView.Location = new System.Drawing.Point(46, 75);
            this.detailView.Name = "detailView";
            this.detailView.RowTemplate.Height = 23;
            this.detailView.Size = new System.Drawing.Size(692, 455);
            this.detailView.TabIndex = 0;
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Location = new System.Drawing.Point(44, 29);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(41, 12);
            this.lbName.TabIndex = 1;
            this.lbName.Text = "label1";
            // 
            // BetMoney
            // 
            this.BetMoney.HeaderText = "投注金额";
            this.BetMoney.Name = "BetMoney";
            this.BetMoney.ReadOnly = true;
            // 
            // Multiple
            // 
            this.Multiple.HeaderText = "倍数";
            this.Multiple.Name = "Multiple";
            this.Multiple.ReadOnly = true;
            // 
            // DealerPoint
            // 
            this.DealerPoint.HeaderText = "庄家点数";
            this.DealerPoint.Name = "DealerPoint";
            this.DealerPoint.ReadOnly = true;
            // 
            // Profit
            // 
            this.Profit.HeaderText = "盈亏";
            this.Profit.Name = "Profit";
            this.Profit.ReadOnly = true;
            // 
            // Balance
            // 
            this.Balance.HeaderText = "结算";
            this.Balance.Name = "Balance";
            this.Balance.ReadOnly = true;
            // 
            // RoundOrder
            // 
            this.RoundOrder.HeaderText = "轮数";
            this.RoundOrder.Name = "RoundOrder";
            this.RoundOrder.ReadOnly = true;
            // 
            // Detail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 566);
            this.Controls.Add(this.lbName);
            this.Controls.Add(this.detailView);
            this.Name = "Detail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "详情";
            ((System.ComponentModel.ISupportInitialize)(this.detailView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView detailView;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.DataGridViewTextBoxColumn BetMoney;
        private System.Windows.Forms.DataGridViewTextBoxColumn Multiple;
        private System.Windows.Forms.DataGridViewTextBoxColumn DealerPoint;
        private System.Windows.Forms.DataGridViewTextBoxColumn Profit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Balance;
        private System.Windows.Forms.DataGridViewTextBoxColumn RoundOrder;
    }
}