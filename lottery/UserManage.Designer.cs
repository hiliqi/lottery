namespace lottery
{
    partial class UserManage
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAddPlayer = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.userView = new System.Windows.Forms.DataGridView();
            this.lbMsg = new System.Windows.Forms.Label();
            this.PlayerID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlayerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Money = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Settle = new System.Windows.Forms.DataGridViewButtonColumn();
            this.SettleLog = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.GoBet = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userView)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAddPlayer);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Location = new System.Drawing.Point(25, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(272, 576);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "用户添加";
            // 
            // btnAddPlayer
            // 
            this.btnAddPlayer.Location = new System.Drawing.Point(163, 55);
            this.btnAddPlayer.Name = "btnAddPlayer";
            this.btnAddPlayer.Size = new System.Drawing.Size(75, 23);
            this.btnAddPlayer.TabIndex = 4;
            this.btnAddPlayer.Text = "添加玩家";
            this.btnAddPlayer.UseVisualStyleBackColor = true;
            this.btnAddPlayer.Click += new System.EventHandler(this.btnAddPlayer_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(37, 55);
            this.txtName.Multiline = true;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(120, 486);
            this.txtName.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.userView);
            this.groupBox2.Controls.Add(this.lbMsg);
            this.groupBox2.Location = new System.Drawing.Point(320, 27);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(772, 576);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "用户删除";
            // 
            // userView
            // 
            this.userView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.userView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PlayerID,
            this.PlayerName,
            this.Money,
            this.Settle,
            this.SettleLog,
            this.Delete,
            this.GoBet});
            this.userView.Location = new System.Drawing.Point(17, 55);
            this.userView.Name = "userView";
            this.userView.RowTemplate.Height = 23;
            this.userView.Size = new System.Drawing.Size(737, 486);
            this.userView.TabIndex = 5;
            this.userView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.userView_CellContentClick);
            // 
            // lbMsg
            // 
            this.lbMsg.AutoSize = true;
            this.lbMsg.Location = new System.Drawing.Point(31, 30);
            this.lbMsg.Name = "lbMsg";
            this.lbMsg.Size = new System.Drawing.Size(53, 12);
            this.lbMsg.TabIndex = 4;
            this.lbMsg.Text = "正在加载";
            // 
            // PlayerID
            // 
            this.PlayerID.HeaderText = "玩家ID";
            this.PlayerID.Name = "PlayerID";
            this.PlayerID.ReadOnly = true;
            // 
            // PlayerName
            // 
            this.PlayerName.HeaderText = "玩家名";
            this.PlayerName.Name = "PlayerName";
            this.PlayerName.ReadOnly = true;
            // 
            // Money
            // 
            this.Money.HeaderText = "剩余金额";
            this.Money.Name = "Money";
            this.Money.ReadOnly = true;
            // 
            // Settle
            // 
            this.Settle.HeaderText = "清账";
            this.Settle.Name = "Settle";
            this.Settle.ReadOnly = true;
            this.Settle.Text = "清账";
            this.Settle.UseColumnTextForButtonValue = true;
            // 
            // SettleLog
            // 
            this.SettleLog.HeaderText = "结算记录";
            this.SettleLog.Name = "SettleLog";
            this.SettleLog.ReadOnly = true;
            this.SettleLog.Text = "结算记录";
            this.SettleLog.UseColumnTextForButtonValue = true;
            // 
            // Delete
            // 
            this.Delete.HeaderText = "删除";
            this.Delete.Name = "Delete";
            this.Delete.ReadOnly = true;
            this.Delete.Text = "删除";
            this.Delete.UseColumnTextForButtonValue = true;
            // 
            // GoBet
            // 
            this.GoBet.HeaderText = "开庄";
            this.GoBet.Name = "GoBet";
            this.GoBet.ReadOnly = true;
            // 
            // UserManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1112, 623);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "UserManage";
            this.Text = "玩家管理";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lbMsg;
        private System.Windows.Forms.Button btnAddPlayer;
        private System.Windows.Forms.DataGridView userView;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlayerID;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlayerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Money;
        private System.Windows.Forms.DataGridViewButtonColumn Settle;
        private System.Windows.Forms.DataGridViewButtonColumn SettleLog;
        private System.Windows.Forms.DataGridViewButtonColumn Delete;
        private System.Windows.Forms.DataGridViewButtonColumn GoBet;
    }
}