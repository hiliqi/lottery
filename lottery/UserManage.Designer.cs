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
            this.txtName = new System.Windows.Forms.TextBox();
            this.btnAddDealer = new System.Windows.Forms.Button();
            this.btnAddPlayer = new System.Windows.Forms.Button();
            this.btnPlay = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbDealer = new System.Windows.Forms.ListBox();
            this.btnDelDealer = new System.Windows.Forms.Button();
            this.lbPlayer = new System.Windows.Forms.ListBox();
            this.btnDelPlayer = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnPlay);
            this.groupBox1.Controls.Add(this.btnAddPlayer);
            this.groupBox1.Controls.Add(this.btnAddDealer);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Location = new System.Drawing.Point(42, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(384, 425);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "用户添加";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(27, 46);
            this.txtName.Multiline = true;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(158, 324);
            this.txtName.TabIndex = 0;
            // 
            // btnAddDealer
            // 
            this.btnAddDealer.Location = new System.Drawing.Point(214, 46);
            this.btnAddDealer.Name = "btnAddDealer";
            this.btnAddDealer.Size = new System.Drawing.Size(75, 23);
            this.btnAddDealer.TabIndex = 1;
            this.btnAddDealer.Text = "添加庄家";
            this.btnAddDealer.UseVisualStyleBackColor = true;
            this.btnAddDealer.Click += new System.EventHandler(this.btnAddDealer_Click);
            // 
            // btnAddPlayer
            // 
            this.btnAddPlayer.Location = new System.Drawing.Point(214, 75);
            this.btnAddPlayer.Name = "btnAddPlayer";
            this.btnAddPlayer.Size = new System.Drawing.Size(75, 23);
            this.btnAddPlayer.TabIndex = 2;
            this.btnAddPlayer.Text = "添加闲家";
            this.btnAddPlayer.UseVisualStyleBackColor = true;
            this.btnAddPlayer.Click += new System.EventHandler(this.btnAddPlayer_Click);
            // 
            // btnPlay
            // 
            this.btnPlay.Location = new System.Drawing.Point(214, 104);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(75, 23);
            this.btnPlay.TabIndex = 3;
            this.btnPlay.Text = "开庄";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnDelPlayer);
            this.groupBox2.Controls.Add(this.lbPlayer);
            this.groupBox2.Controls.Add(this.btnDelDealer);
            this.groupBox2.Controls.Add(this.lbDealer);
            this.groupBox2.Location = new System.Drawing.Point(456, 35);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(589, 425);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // lbDealer
            // 
            this.lbDealer.FormattingEnabled = true;
            this.lbDealer.ItemHeight = 12;
            this.lbDealer.Location = new System.Drawing.Point(24, 46);
            this.lbDealer.Name = "lbDealer";
            this.lbDealer.Size = new System.Drawing.Size(120, 340);
            this.lbDealer.TabIndex = 0;
            // 
            // btnDelDealer
            // 
            this.btnDelDealer.Location = new System.Drawing.Point(150, 46);
            this.btnDelDealer.Name = "btnDelDealer";
            this.btnDelDealer.Size = new System.Drawing.Size(75, 23);
            this.btnDelDealer.TabIndex = 1;
            this.btnDelDealer.Text = "删除庄家";
            this.btnDelDealer.UseVisualStyleBackColor = true;
            this.btnDelDealer.Click += new System.EventHandler(this.btnDelDealer_Click);
            // 
            // lbPlayer
            // 
            this.lbPlayer.FormattingEnabled = true;
            this.lbPlayer.ItemHeight = 12;
            this.lbPlayer.Location = new System.Drawing.Point(266, 46);
            this.lbPlayer.Name = "lbPlayer";
            this.lbPlayer.Size = new System.Drawing.Size(120, 340);
            this.lbPlayer.TabIndex = 2;
            // 
            // btnDelPlayer
            // 
            this.btnDelPlayer.Location = new System.Drawing.Point(392, 46);
            this.btnDelPlayer.Name = "btnDelPlayer";
            this.btnDelPlayer.Size = new System.Drawing.Size(75, 23);
            this.btnDelPlayer.TabIndex = 3;
            this.btnDelPlayer.Text = "删除闲家";
            this.btnDelPlayer.UseVisualStyleBackColor = true;
            this.btnDelPlayer.Click += new System.EventHandler(this.btnDelPlayer_Click);
            // 
            // UserManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1077, 488);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "UserManage";
            this.Text = "UserManage";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnAddPlayer;
        private System.Windows.Forms.Button btnAddDealer;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox lbPlayer;
        private System.Windows.Forms.Button btnDelDealer;
        private System.Windows.Forms.ListBox lbDealer;
        private System.Windows.Forms.Button btnDelPlayer;
    }
}