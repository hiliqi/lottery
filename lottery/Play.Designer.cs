namespace lottery
{
    partial class Play
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
            this.lotteryView = new System.Windows.Forms.DataGridView();
            this.PlayDetailID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlayerID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Player = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Money = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OriginNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Multiple = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlayerProfit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DealerProfit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastSurplus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Surplus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbTime = new System.Windows.Forms.Label();
            this.txtDealerBalance = new System.Windows.Forms.TextBox();
            this.lbRoundCount = new System.Windows.Forms.Label();
            this.lb5 = new System.Windows.Forms.Label();
            this.txtDealerProfit = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDealerPoint = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBetMoney = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDealer = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnEdit = new System.Windows.Forms.Button();
            this.txtAddDeal = new System.Windows.Forms.TextBox();
            this.btnAddDealMoney = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnCal = new System.Windows.Forms.Button();
            this.btnChangeDealer = new System.Windows.Forms.Button();
            this.btnRemovePlayer = new System.Windows.Forms.Button();
            this.btnAddPlayer = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDealerMultiple = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.lotteryView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lotteryView
            // 
            this.lotteryView.AllowDrop = true;
            this.lotteryView.AllowUserToAddRows = false;
            this.lotteryView.AllowUserToOrderColumns = true;
            this.lotteryView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.lotteryView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PlayDetailID,
            this.PlayerID,
            this.Player,
            this.Money,
            this.OriginNumber,
            this.Multiple,
            this.PlayerProfit,
            this.DealerProfit,
            this.LastSurplus,
            this.Surplus});
            this.lotteryView.Location = new System.Drawing.Point(30, 50);
            this.lotteryView.Name = "lotteryView";
            this.lotteryView.RowTemplate.Height = 23;
            this.lotteryView.Size = new System.Drawing.Size(954, 466);
            this.lotteryView.TabIndex = 1;
            this.lotteryView.DragDrop += new System.Windows.Forms.DragEventHandler(this.lotteryView_DragDrop);
            this.lotteryView.DragOver += new System.Windows.Forms.DragEventHandler(this.lotteryView_DragOver);
            this.lotteryView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lotteryView_MouseDown);
            this.lotteryView.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lotteryView_MouseMove);
            // 
            // PlayDetailID
            // 
            this.PlayDetailID.HeaderText = "ID";
            this.PlayDetailID.Name = "PlayDetailID";
            this.PlayDetailID.ReadOnly = true;
            this.PlayDetailID.Visible = false;
            // 
            // PlayerID
            // 
            this.PlayerID.HeaderText = "闲家ID";
            this.PlayerID.Name = "PlayerID";
            this.PlayerID.ReadOnly = true;
            this.PlayerID.Visible = false;
            // 
            // Player
            // 
            this.Player.HeaderText = "闲家";
            this.Player.Name = "Player";
            this.Player.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Money
            // 
            this.Money.HeaderText = "投注金额";
            this.Money.Name = "Money";
            this.Money.ToolTipText = "输入金额";
            // 
            // OriginNumber
            // 
            this.OriginNumber.HeaderText = "点数";
            this.OriginNumber.Name = "OriginNumber";
            // 
            // Multiple
            // 
            this.Multiple.HeaderText = "盈亏倍数";
            this.Multiple.Name = "Multiple";
            this.Multiple.ReadOnly = true;
            this.Multiple.ToolTipText = "输入倍数";
            // 
            // PlayerProfit
            // 
            this.PlayerProfit.HeaderText = "闲家盈亏";
            this.PlayerProfit.Name = "PlayerProfit";
            this.PlayerProfit.ReadOnly = true;
            // 
            // DealerProfit
            // 
            this.DealerProfit.HeaderText = "庄家盈亏";
            this.DealerProfit.Name = "DealerProfit";
            this.DealerProfit.ReadOnly = true;
            // 
            // LastSurplus
            // 
            this.LastSurplus.HeaderText = "上把结余";
            this.LastSurplus.Name = "LastSurplus";
            this.LastSurplus.ReadOnly = true;
            // 
            // Surplus
            // 
            this.Surplus.HeaderText = "本庄结余";
            this.Surplus.Name = "Surplus";
            this.Surplus.ReadOnly = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtDealerMultiple);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lbTime);
            this.groupBox1.Controls.Add(this.txtDealerBalance);
            this.groupBox1.Controls.Add(this.lbRoundCount);
            this.groupBox1.Controls.Add(this.lb5);
            this.groupBox1.Controls.Add(this.txtDealerProfit);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtDealerPoint);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtBetMoney);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtDealer);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(28, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1016, 67);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "庄家";
            // 
            // lbTime
            // 
            this.lbTime.AutoSize = true;
            this.lbTime.Location = new System.Drawing.Point(859, 41);
            this.lbTime.Name = "lbTime";
            this.lbTime.Size = new System.Drawing.Size(41, 12);
            this.lbTime.TabIndex = 6;
            this.lbTime.Text = "label5";
            // 
            // txtDealerBalance
            // 
            this.txtDealerBalance.Location = new System.Drawing.Point(168, 29);
            this.txtDealerBalance.Name = "txtDealerBalance";
            this.txtDealerBalance.ReadOnly = true;
            this.txtDealerBalance.Size = new System.Drawing.Size(89, 21);
            this.txtDealerBalance.TabIndex = 10;
            // 
            // lbRoundCount
            // 
            this.lbRoundCount.AutoSize = true;
            this.lbRoundCount.Location = new System.Drawing.Point(859, 20);
            this.lbRoundCount.Name = "lbRoundCount";
            this.lbRoundCount.Size = new System.Drawing.Size(59, 12);
            this.lbRoundCount.TabIndex = 5;
            this.lbRoundCount.Text = "当前第 轮";
            // 
            // lb5
            // 
            this.lb5.AutoSize = true;
            this.lb5.Location = new System.Drawing.Point(139, 33);
            this.lb5.Name = "lb5";
            this.lb5.Size = new System.Drawing.Size(29, 12);
            this.lb5.TabIndex = 9;
            this.lb5.Text = "总计";
            // 
            // txtDealerProfit
            // 
            this.txtDealerProfit.Location = new System.Drawing.Point(537, 29);
            this.txtDealerProfit.Name = "txtDealerProfit";
            this.txtDealerProfit.ReadOnly = true;
            this.txtDealerProfit.Size = new System.Drawing.Size(109, 21);
            this.txtDealerProfit.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(482, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "本轮盈亏";
            // 
            // txtDealerPoint
            // 
            this.txtDealerPoint.Location = new System.Drawing.Point(302, 29);
            this.txtDealerPoint.Name = "txtDealerPoint";
            this.txtDealerPoint.Size = new System.Drawing.Size(51, 21);
            this.txtDealerPoint.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(273, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "点数";
            // 
            // txtBetMoney
            // 
            this.txtBetMoney.Location = new System.Drawing.Point(712, 29);
            this.txtBetMoney.Name = "txtBetMoney";
            this.txtBetMoney.ReadOnly = true;
            this.txtBetMoney.Size = new System.Drawing.Size(125, 21);
            this.txtBetMoney.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(659, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "开庄金额";
            // 
            // txtDealer
            // 
            this.txtDealer.Location = new System.Drawing.Point(45, 29);
            this.txtDealer.Name = "txtDealer";
            this.txtDealer.ReadOnly = true;
            this.txtDealer.Size = new System.Drawing.Size(81, 21);
            this.txtDealer.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "庄家";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnEdit);
            this.groupBox2.Controls.Add(this.txtAddDeal);
            this.groupBox2.Controls.Add(this.btnAddDealMoney);
            this.groupBox2.Controls.Add(this.btnNew);
            this.groupBox2.Controls.Add(this.btnCal);
            this.groupBox2.Controls.Add(this.lotteryView);
            this.groupBox2.Controls.Add(this.btnChangeDealer);
            this.groupBox2.Controls.Add(this.btnRemovePlayer);
            this.groupBox2.Controls.Add(this.btnAddPlayer);
            this.groupBox2.Location = new System.Drawing.Point(28, 85);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1016, 522);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "结果";
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(561, 21);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 11;
            this.btnEdit.Text = "修改";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // txtAddDeal
            // 
            this.txtAddDeal.Location = new System.Drawing.Point(31, 23);
            this.txtAddDeal.Name = "txtAddDeal";
            this.txtAddDeal.Size = new System.Drawing.Size(177, 21);
            this.txtAddDeal.TabIndex = 10;
            // 
            // btnAddDealMoney
            // 
            this.btnAddDealMoney.Location = new System.Drawing.Point(214, 21);
            this.btnAddDealMoney.Name = "btnAddDealMoney";
            this.btnAddDealMoney.Size = new System.Drawing.Size(75, 23);
            this.btnAddDealMoney.TabIndex = 9;
            this.btnAddDealMoney.Text = "追庄";
            this.btnAddDealMoney.UseVisualStyleBackColor = true;
            this.btnAddDealMoney.Click += new System.EventHandler(this.btnAddDealMoney_Click);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(648, 21);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 7;
            this.btnNew.Text = "新的一轮";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnCal
            // 
            this.btnCal.Location = new System.Drawing.Point(474, 21);
            this.btnCal.Name = "btnCal";
            this.btnCal.Size = new System.Drawing.Size(75, 23);
            this.btnCal.TabIndex = 4;
            this.btnCal.Text = "开始计算";
            this.btnCal.UseVisualStyleBackColor = true;
            this.btnCal.Click += new System.EventHandler(this.btnCal_Click);
            // 
            // btnChangeDealer
            // 
            this.btnChangeDealer.Location = new System.Drawing.Point(909, 21);
            this.btnChangeDealer.Name = "btnChangeDealer";
            this.btnChangeDealer.Size = new System.Drawing.Size(75, 23);
            this.btnChangeDealer.TabIndex = 8;
            this.btnChangeDealer.Text = "换庄";
            this.btnChangeDealer.UseVisualStyleBackColor = true;
            this.btnChangeDealer.Click += new System.EventHandler(this.btnChangeDealer_Click);
            // 
            // btnRemovePlayer
            // 
            this.btnRemovePlayer.Location = new System.Drawing.Point(822, 21);
            this.btnRemovePlayer.Name = "btnRemovePlayer";
            this.btnRemovePlayer.Size = new System.Drawing.Size(75, 23);
            this.btnRemovePlayer.TabIndex = 6;
            this.btnRemovePlayer.Text = "移除投注";
            this.btnRemovePlayer.UseVisualStyleBackColor = true;
            this.btnRemovePlayer.Click += new System.EventHandler(this.btnRemovePlayer_Click);
            // 
            // btnAddPlayer
            // 
            this.btnAddPlayer.Location = new System.Drawing.Point(735, 21);
            this.btnAddPlayer.Name = "btnAddPlayer";
            this.btnAddPlayer.Size = new System.Drawing.Size(75, 23);
            this.btnAddPlayer.TabIndex = 5;
            this.btnAddPlayer.Text = "增加投注";
            this.btnAddPlayer.UseVisualStyleBackColor = true;
            this.btnAddPlayer.Click += new System.EventHandler(this.btnAddPlayer_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(371, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 11;
            this.label5.Text = "倍数";
            // 
            // txtDealerMultiple
            // 
            this.txtDealerMultiple.Location = new System.Drawing.Point(406, 30);
            this.txtDealerMultiple.Name = "txtDealerMultiple";
            this.txtDealerMultiple.Size = new System.Drawing.Size(55, 21);
            this.txtDealerMultiple.TabIndex = 12;
            // 
            // Play
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1076, 627);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "Play";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "计算";
            ((System.ComponentModel.ISupportInitialize)(this.lotteryView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView lotteryView;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtDealerPoint;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBetMoney;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDealer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDealerBalance;
        private System.Windows.Forms.Label lb5;
        private System.Windows.Forms.TextBox txtDealerProfit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnCal;
        private System.Windows.Forms.Button btnAddPlayer;
        private System.Windows.Forms.Button btnRemovePlayer;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnChangeDealer;
        private System.Windows.Forms.Label lbRoundCount;
        private System.Windows.Forms.Button btnAddDealMoney;
        private System.Windows.Forms.TextBox txtAddDeal;
        private System.Windows.Forms.Label lbTime;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlayDetailID;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlayerID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Player;
        private System.Windows.Forms.DataGridViewTextBoxColumn Money;
        private System.Windows.Forms.DataGridViewTextBoxColumn OriginNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn Multiple;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlayerProfit;
        private System.Windows.Forms.DataGridViewTextBoxColumn DealerProfit;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastSurplus;
        private System.Windows.Forms.DataGridViewTextBoxColumn Surplus;
        private System.Windows.Forms.TextBox txtDealerMultiple;
        private System.Windows.Forms.Label label5;
    }
}