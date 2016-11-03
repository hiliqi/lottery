using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lottery
{
    public partial class Settle : Form
    {
        private int playerID { get; set; }
        private PlayDetail model;
        private LotteryDbContext db;

        public Settle(int playerID)
        {
            db = DBSession.GetDbContext();
            this.playerID = playerID;
            InitializeComponent();
            var model = db.PlayDetail.Where(p => p.PlayerID == playerID).OrderByDescending(p => p.PlayDetailID).FirstOrDefault();
            lbPlayer.Text = model.Player.Name;
            txtBalance.Text = model.Balance.ToString();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            double money = 0;
            if (!string.IsNullOrEmpty(txtSettle.Text))
            {
                if (!double.TryParse(txtSettle.Text,out money))
                {
                    MessageBox.Show("请输入正确的金额");
                    return;
                }
            }
            model.Balance += money; //追加金额
            Close();
        }
    }
}
