using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace lottery
{
    public partial class Main : Form
    {
        LotteryDbContext db;

        public Main()
        {
            db = DBSession.GetDbContext();
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.lbName = new System.Windows.Forms.Label();
            this.cmbDealer = new System.Windows.Forms.ComboBox();
            this.lbMoney = new System.Windows.Forms.Label();
            this.txtMoney = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnReport = new System.Windows.Forms.Button();
            this.lbMsg = new System.Windows.Forms.Label();
            this.btnUserManager = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Location = new System.Drawing.Point(111, 90);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(29, 12);
            this.lbName.TabIndex = 0;
            this.lbName.Text = "庄家";
            // 
            // cmbDealer
            // 
            this.cmbDealer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDealer.FormattingEnabled = true;
            this.cmbDealer.Location = new System.Drawing.Point(159, 87);
            this.cmbDealer.Name = "cmbDealer";
            this.cmbDealer.Size = new System.Drawing.Size(197, 20);
            this.cmbDealer.TabIndex = 1;
            this.cmbDealer.Click += new System.EventHandler(this.cmbDealer_Click);
            // 
            // lbMoney
            // 
            this.lbMoney.AutoSize = true;
            this.lbMoney.Location = new System.Drawing.Point(87, 135);
            this.lbMoney.Name = "lbMoney";
            this.lbMoney.Size = new System.Drawing.Size(53, 12);
            this.lbMoney.TabIndex = 2;
            this.lbMoney.Text = "开庄金额";
            // 
            // txtMoney
            // 
            this.txtMoney.Location = new System.Drawing.Point(159, 132);
            this.txtMoney.Name = "txtMoney";
            this.txtMoney.Size = new System.Drawing.Size(197, 21);
            this.txtMoney.TabIndex = 3;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(252, 159);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "开局";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnReport);
            this.groupBox1.Controls.Add(this.btnOK);
            this.groupBox1.Controls.Add(this.lbMsg);
            this.groupBox1.Controls.Add(this.btnUserManager);
            this.groupBox1.Location = new System.Drawing.Point(29, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(379, 263);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "开庄";
            // 
            // btnReport
            // 
            this.btnReport.Location = new System.Drawing.Point(156, 159);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(75, 23);
            this.btnReport.TabIndex = 5;
            this.btnReport.Text = "报表查看";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // lbMsg
            // 
            this.lbMsg.AutoSize = true;
            this.lbMsg.Location = new System.Drawing.Point(35, 44);
            this.lbMsg.Name = "lbMsg";
            this.lbMsg.Size = new System.Drawing.Size(0, 12);
            this.lbMsg.TabIndex = 1;
            // 
            // btnUserManager
            // 
            this.btnUserManager.Location = new System.Drawing.Point(60, 159);
            this.btnUserManager.Name = "btnUserManager";
            this.btnUserManager.Size = new System.Drawing.Size(75, 23);
            this.btnUserManager.TabIndex = 0;
            this.btnUserManager.Text = "管理玩家";
            this.btnUserManager.UseVisualStyleBackColor = true;
            this.btnUserManager.Click += new System.EventHandler(this.btnUserManager_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 301);
            this.Controls.Add(this.txtMoney);
            this.Controls.Add(this.lbMoney);
            this.Controls.Add(this.cmbDealer);
            this.Controls.Add(this.lbName);
            this.Controls.Add(this.groupBox1);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "牛牛计算器";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            int money = 0;
            int gameOrder = 1; //保存局数
            bool b = int.TryParse(txtMoney.Text, out money);
            if (!b)
            {
                MessageBox.Show("请输入正确的金额");
                return;
            }          
            if (cmbDealer.SelectedValue == null)
            {
                MessageBox.Show("请选择庄家");
                return;
            }
            int cmbDealerID = -1;
            bool c = int.TryParse(cmbDealer.SelectedValue.ToString(), out cmbDealerID);
            if (!c)
            {
                MessageBox.Show("选择庄家出错");
                return;
            }
            var game = db.Game.OrderByDescending(g => g.GameID).FirstOrDefault();
            if (game != null)
            {
                gameOrder = game.GameOrder + 1; //查出最近一局的局数
            }
            Game model = new Game()
            {
                GameOrder = gameOrder,
                BetMoney = money,
                PlayerID = cmbDealerID,
                PlayTime = DateTime.Now,
                Year = DateTime.Now.Year,
                Month = DateTime.Now.Month,
                Day = DateTime.Now.Day,
                Fee=money*0.02
            };
            db.Game.Add(model);
            db.SaveChanges();
            Play play = new Play(cmbDealer.Text, money*0.98, model.GameID,cmbDealerID);
            play.ShowDialog();
            txtMoney.Clear();
        }

        private void btnUserManager_Click(object sender, EventArgs e)
        {
            new UserManage().ShowDialog();
        }

        private void cmbDealer_Click(object sender, EventArgs e)
        {
            InitCmb();
        }

        private void InitCmb()
        {
            lbMsg.Text = "正在加载庄家名单";
            cmbDealer.DataSource = db.Player.Where(d => d.IsDel == false).ToList();
            cmbDealer.DisplayMember = "Name";
            cmbDealer.ValueMember = "PlayerID";
            lbMsg.Text = string.Empty;
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            new Report().ShowDialog();
        }
    }
}
