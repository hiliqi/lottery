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
            this.Balance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbDealerName = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.lbBetMoney = new System.Windows.Forms.Label();
            this.lbDealerBalance = new System.Windows.Forms.Label();
            this.lbStartFee = new System.Windows.Forms.Label();
            this.lbPlayTime = new System.Windows.Forms.Label();
            this.lbEndTime = new System.Windows.Forms.Label();
            this.lbAddFee = new System.Windows.Forms.Label();
            this.lbEndFee = new System.Windows.Forms.Label();
            this.lbTotalFee = new System.Windows.Forms.Label();
            this.lbDealerProfit = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.resultView)).BeginInit();
            this.SuspendLayout();
            // 
            // resultView
            // 
            this.resultView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.resultView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PlayerID,
            this.PlayerName,
            this.Balance});
            this.resultView.Location = new System.Drawing.Point(247, 64);
            this.resultView.Name = "resultView";
            this.resultView.RowTemplate.Height = 23;
            this.resultView.Size = new System.Drawing.Size(583, 392);
            this.resultView.TabIndex = 0;
            this.resultView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.resultView_CellDoubleClick);
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
            // Balance
            // 
            this.Balance.HeaderText = "总盈亏";
            this.Balance.Name = "Balance";
            this.Balance.ReadOnly = true;
            // 
            // lbDealerName
            // 
            this.lbDealerName.AutoSize = true;
            this.lbDealerName.Location = new System.Drawing.Point(60, 64);
            this.lbDealerName.Name = "lbDealerName";
            this.lbDealerName.Size = new System.Drawing.Size(41, 12);
            this.lbDealerName.TabIndex = 1;
            this.lbDealerName.Text = "庄家：";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(755, 35);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lbBetMoney
            // 
            this.lbBetMoney.AutoSize = true;
            this.lbBetMoney.Location = new System.Drawing.Point(60, 99);
            this.lbBetMoney.Name = "lbBetMoney";
            this.lbBetMoney.Size = new System.Drawing.Size(65, 12);
            this.lbBetMoney.TabIndex = 4;
            this.lbBetMoney.Text = "庄家投注：";
            // 
            // lbDealerBalance
            // 
            this.lbDealerBalance.AutoSize = true;
            this.lbDealerBalance.Location = new System.Drawing.Point(60, 134);
            this.lbDealerBalance.Name = "lbDealerBalance";
            this.lbDealerBalance.Size = new System.Drawing.Size(65, 12);
            this.lbDealerBalance.TabIndex = 6;
            this.lbDealerBalance.Text = "庄家结余：";
            // 
            // lbStartFee
            // 
            this.lbStartFee.AutoSize = true;
            this.lbStartFee.Location = new System.Drawing.Point(36, 491);
            this.lbStartFee.Name = "lbStartFee";
            this.lbStartFee.Size = new System.Drawing.Size(65, 12);
            this.lbStartFee.TabIndex = 8;
            this.lbStartFee.Text = "开庄抽成：";
            // 
            // lbPlayTime
            // 
            this.lbPlayTime.AutoSize = true;
            this.lbPlayTime.Location = new System.Drawing.Point(60, 26);
            this.lbPlayTime.Name = "lbPlayTime";
            this.lbPlayTime.Size = new System.Drawing.Size(65, 12);
            this.lbPlayTime.TabIndex = 9;
            this.lbPlayTime.Text = "开局时间：";
            // 
            // lbEndTime
            // 
            this.lbEndTime.AutoSize = true;
            this.lbEndTime.Location = new System.Drawing.Point(386, 26);
            this.lbEndTime.Name = "lbEndTime";
            this.lbEndTime.Size = new System.Drawing.Size(65, 12);
            this.lbEndTime.TabIndex = 10;
            this.lbEndTime.Text = "结局时间：";
            // 
            // lbAddFee
            // 
            this.lbAddFee.AutoSize = true;
            this.lbAddFee.Location = new System.Drawing.Point(227, 491);
            this.lbAddFee.Name = "lbAddFee";
            this.lbAddFee.Size = new System.Drawing.Size(65, 12);
            this.lbAddFee.TabIndex = 11;
            this.lbAddFee.Text = "追庄抽成：";
            // 
            // lbEndFee
            // 
            this.lbEndFee.AutoSize = true;
            this.lbEndFee.Location = new System.Drawing.Point(418, 491);
            this.lbEndFee.Name = "lbEndFee";
            this.lbEndFee.Size = new System.Drawing.Size(65, 12);
            this.lbEndFee.TabIndex = 12;
            this.lbEndFee.Text = "下庄抽成：";
            // 
            // lbTotalFee
            // 
            this.lbTotalFee.AutoSize = true;
            this.lbTotalFee.Location = new System.Drawing.Point(609, 491);
            this.lbTotalFee.Name = "lbTotalFee";
            this.lbTotalFee.Size = new System.Drawing.Size(53, 12);
            this.lbTotalFee.TabIndex = 13;
            this.lbTotalFee.Text = "总抽成：";
            // 
            // lbDealerProfit
            // 
            this.lbDealerProfit.AutoSize = true;
            this.lbDealerProfit.Location = new System.Drawing.Point(62, 169);
            this.lbDealerProfit.Name = "lbDealerProfit";
            this.lbDealerProfit.Size = new System.Drawing.Size(65, 12);
            this.lbDealerProfit.TabIndex = 14;
            this.lbDealerProfit.Text = "庄家盈利：";
            // 
            // Result
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 530);
            this.Controls.Add(this.lbDealerProfit);
            this.Controls.Add(this.lbTotalFee);
            this.Controls.Add(this.lbEndFee);
            this.Controls.Add(this.lbAddFee);
            this.Controls.Add(this.lbEndTime);
            this.Controls.Add(this.lbPlayTime);
            this.Controls.Add(this.lbStartFee);
            this.Controls.Add(this.lbDealerBalance);
            this.Controls.Add(this.lbBetMoney);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lbDealerName);
            this.Controls.Add(this.resultView);
            this.Name = "Result";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "结果预览";
            ((System.ComponentModel.ISupportInitialize)(this.resultView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView resultView;
        private System.Windows.Forms.Label lbDealerName;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lbBetMoney;
        private System.Windows.Forms.Label lbDealerBalance;
        private System.Windows.Forms.Label lbStartFee;
        private System.Windows.Forms.Label lbPlayTime;
        private System.Windows.Forms.Label lbEndTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlayerID;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlayerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Balance;
        private System.Windows.Forms.Label lbAddFee;
        private System.Windows.Forms.Label lbEndFee;
        private System.Windows.Forms.Label lbTotalFee;
        private System.Windows.Forms.Label lbDealerProfit;
    }
}