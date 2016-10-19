namespace lottery
{
    partial class Result
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
            this.PlayerID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlayerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalBetMoney = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Profit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlayRounds = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbDealerName = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.lbGameOrder = new System.Windows.Forms.Label();
            this.lbBetMoney = new System.Windows.Forms.Label();
            this.lbFee = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.resultView)).BeginInit();
            this.SuspendLayout();
            // 
            // resultView
            // 
            this.resultView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.resultView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PlayerID,
            this.PlayerName,
            this.TotalBetMoney,
            this.Profit,
            this.PlayRounds});
            this.resultView.Location = new System.Drawing.Point(62, 52);
            this.resultView.Name = "resultView";
            this.resultView.RowTemplate.Height = 23;
            this.resultView.Size = new System.Drawing.Size(770, 392);
            this.resultView.TabIndex = 0;
            // 
            // PlayerID
            // 
            this.PlayerID.HeaderText = "闲家ID";
            this.PlayerID.Name = "PlayerID";
            this.PlayerID.ReadOnly = true;
            // 
            // PlayerName
            // 
            this.PlayerName.HeaderText = "闲家名称";
            this.PlayerName.Name = "PlayerName";
            this.PlayerName.ReadOnly = true;
            // 
            // TotalBetMoney
            // 
            this.TotalBetMoney.HeaderText = "总投注";
            this.TotalBetMoney.Name = "TotalBetMoney";
            this.TotalBetMoney.ReadOnly = true;
            // 
            // Profit
            // 
            this.Profit.HeaderText = "总盈亏";
            this.Profit.Name = "Profit";
            this.Profit.ReadOnly = true;
            // 
            // PlayRounds
            // 
            this.PlayRounds.HeaderText = "参与轮数";
            this.PlayRounds.Name = "PlayRounds";
            this.PlayRounds.ReadOnly = true;
            // 
            // lbDealerName
            // 
            this.lbDealerName.AutoSize = true;
            this.lbDealerName.Location = new System.Drawing.Point(60, 28);
            this.lbDealerName.Name = "lbDealerName";
            this.lbDealerName.Size = new System.Drawing.Size(41, 12);
            this.lbDealerName.TabIndex = 1;
            this.lbDealerName.Text = "庄家：";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(757, 23);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lbGameOrder
            // 
            this.lbGameOrder.AutoSize = true;
            this.lbGameOrder.Location = new System.Drawing.Point(62, 465);
            this.lbGameOrder.Name = "lbGameOrder";
            this.lbGameOrder.Size = new System.Drawing.Size(41, 12);
            this.lbGameOrder.TabIndex = 3;
            this.lbGameOrder.Text = "label1";
            // 
            // lbBetMoney
            // 
            this.lbBetMoney.AutoSize = true;
            this.lbBetMoney.Location = new System.Drawing.Point(242, 28);
            this.lbBetMoney.Name = "lbBetMoney";
            this.lbBetMoney.Size = new System.Drawing.Size(65, 12);
            this.lbBetMoney.TabIndex = 4;
            this.lbBetMoney.Text = "庄家投注：";
            // 
            // lbFee
            // 
            this.lbFee.AutoSize = true;
            this.lbFee.Location = new System.Drawing.Point(458, 28);
            this.lbFee.Name = "lbFee";
            this.lbFee.Size = new System.Drawing.Size(65, 12);
            this.lbFee.TabIndex = 5;
            this.lbFee.Text = "平台抽成：";
            // 
            // Result
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 489);
            this.Controls.Add(this.lbFee);
            this.Controls.Add(this.lbBetMoney);
            this.Controls.Add(this.lbGameOrder);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lbDealerName);
            this.Controls.Add(this.resultView);
            this.Name = "Result";
            this.Text = "结果预览";
            ((System.ComponentModel.ISupportInitialize)(this.resultView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView resultView;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlayerID;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlayerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalBetMoney;
        private System.Windows.Forms.DataGridViewTextBoxColumn Profit;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlayRounds;
        private System.Windows.Forms.Label lbDealerName;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lbGameOrder;
        private System.Windows.Forms.Label lbBetMoney;
        private System.Windows.Forms.Label lbFee;
    }
}