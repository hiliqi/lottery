﻿namespace lottery
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
            this.txtPlayer = new System.Windows.Forms.TextBox();
            this.btnAddPlayer = new System.Windows.Forms.Button();
            this.userView = new System.Windows.Forms.DataGridView();
            this.PlayerID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlayerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Money = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.GoBet = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnLoadView = new System.Windows.Forms.Button();
            this.lbMsg = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.userView)).BeginInit();
            this.SuspendLayout();
            // 
            // txtPlayer
            // 
            this.txtPlayer.Location = new System.Drawing.Point(36, 30);
            this.txtPlayer.Name = "txtPlayer";
            this.txtPlayer.Size = new System.Drawing.Size(100, 21);
            this.txtPlayer.TabIndex = 0;
            // 
            // btnAddPlayer
            // 
            this.btnAddPlayer.Location = new System.Drawing.Point(142, 28);
            this.btnAddPlayer.Name = "btnAddPlayer";
            this.btnAddPlayer.Size = new System.Drawing.Size(75, 23);
            this.btnAddPlayer.TabIndex = 1;
            this.btnAddPlayer.Text = "添加玩家";
            this.btnAddPlayer.UseVisualStyleBackColor = true;
            this.btnAddPlayer.Click += new System.EventHandler(this.btnAddPlayer_Click);
            // 
            // userView
            // 
            this.userView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.userView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PlayerID,
            this.PlayerName,
            this.Money,
            this.Delete,
            this.GoBet});
            this.userView.Location = new System.Drawing.Point(36, 73);
            this.userView.Name = "userView";
            this.userView.RowTemplate.Height = 23;
            this.userView.Size = new System.Drawing.Size(547, 473);
            this.userView.TabIndex = 2;
            this.userView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.userView_CellContentClick);
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
            this.Money.HeaderText = "开庄金额";
            this.Money.Name = "Money";
            // 
            // Delete
            // 
            this.Delete.HeaderText = "删除玩家";
            this.Delete.Name = "Delete";
            this.Delete.ReadOnly = true;
            this.Delete.Text = "删除玩家";
            this.Delete.UseColumnTextForButtonValue = true;
            // 
            // GoBet
            // 
            this.GoBet.HeaderText = "开庄";
            this.GoBet.Name = "GoBet";
            this.GoBet.ReadOnly = true;
            this.GoBet.Text = "开庄";
            this.GoBet.UseColumnTextForButtonValue = true;
            // 
            // btnLoadView
            // 
            this.btnLoadView.Location = new System.Drawing.Point(223, 28);
            this.btnLoadView.Name = "btnLoadView";
            this.btnLoadView.Size = new System.Drawing.Size(75, 23);
            this.btnLoadView.TabIndex = 3;
            this.btnLoadView.Text = "加载玩家";
            this.btnLoadView.UseVisualStyleBackColor = true;
            this.btnLoadView.Click += new System.EventHandler(this.btnLoadView_Click);
            // 
            // lbMsg
            // 
            this.lbMsg.AutoSize = true;
            this.lbMsg.Location = new System.Drawing.Point(319, 33);
            this.lbMsg.Name = "lbMsg";
            this.lbMsg.Size = new System.Drawing.Size(41, 12);
            this.lbMsg.TabIndex = 5;
            this.lbMsg.Text = "label1";
            // 
            // UserManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 578);
            this.Controls.Add(this.lbMsg);
            this.Controls.Add(this.btnLoadView);
            this.Controls.Add(this.userView);
            this.Controls.Add(this.btnAddPlayer);
            this.Controls.Add(this.txtPlayer);
            this.Name = "UserManage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "用户管理";
            ((System.ComponentModel.ISupportInitialize)(this.userView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPlayer;
        private System.Windows.Forms.Button btnAddPlayer;
        private System.Windows.Forms.DataGridView userView;
        private System.Windows.Forms.Button btnLoadView;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlayerID;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlayerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Money;
        private System.Windows.Forms.DataGridViewButtonColumn Delete;
        private System.Windows.Forms.DataGridViewButtonColumn GoBet;
        private System.Windows.Forms.Label lbMsg;
    }
}