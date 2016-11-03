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
            this.lbDealerName = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.lbBetMoney = new System.Windows.Forms.Label();
            this.lbDealerBalance = new System.Windows.Forms.Label();
            this.lbFee = new System.Windows.Forms.Label();
            this.lbPlayTime = new System.Windows.Forms.Label();
            this.lbEndTime = new System.Windows.Forms.Label();
            this.PlayerID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlayerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Balance = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.lbBetMoney.Location = new System.Drawing.Point(60, 98);
            this.lbBetMoney.Name = "lbBetMoney";
            this.lbBetMoney.Size = new System.Drawing.Size(65, 12);
            this.lbBetMoney.TabIndex = 4;
            this.lbBetMoney.Text = "庄家投注：";
            // 
            // lbDealerBalance
            // 
            this.lbDealerBalance.AutoSize = true;
            this.lbDealerBalance.Location = new System.Drawing.Point(60, 132);
            this.lbDealerBalance.Name = "lbDealerBalance";
            this.lbDealerBalance.Size = new System.Drawing.Size(65, 12);
            this.lbDealerBalance.TabIndex = 6;
            this.lbDealerBalance.Text = "庄家结余：";
            // 
            // lbFee
            // 
            this.lbFee.AutoSize = true;
            this.lbFee.Location = new System.Drawing.Point(60, 491);
            this.lbFee.Name = "lbFee";
            this.lbFee.Size = new System.Drawing.Size(65, 12);
            this.lbFee.TabIndex = 8;
            this.lbFee.Text = "本局抽成：";
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
            // Result
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 530);
            this.Controls.Add(this.lbEndTime);
            this.Controls.Add(this.lbPlayTime);
            this.Controls.Add(this.lbFee);
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
        private System.Windows.Forms.Label lbFee;
        private System.Windows.Forms.Label lbPlayTime;
        private System.Windows.Forms.Label lbEndTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlayerID;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlayerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Balance;
    }
}