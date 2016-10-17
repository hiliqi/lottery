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
    public partial class UserManage : Form
    {
        LotteryDbContext db = new LotteryDbContext();
        Main main;
        public UserManage(Main main)
        {
            InitializeComponent();
            this.main = main;
            lbDealer.DataSource = db.Dealer.ToList();
            lbDealer.DisplayMember = "Name";
            lbDealer.ValueMember = "DealerID";
            lbPlayer.DataSource = db.Player.ToList();
            lbPlayer.DisplayMember = "Name";
            lbPlayer.ValueMember = "PlayerID";
        }

        private void btnAddDealer_Click(object sender, EventArgs e)
        {
            string[] list = txtName.Text.Split(new string[] { "\r\n" }, StringSplitOptions.None);
            foreach (var item in list)
            {
                db.Dealer.Add(new Dealer() { Name = item.Trim() });
            }
            db.SaveChanges();
            txtName.Clear();
        }

        private void btnAddPlayer_Click(object sender, EventArgs e)
        {
            string[] list = txtName.Text.Split(new string[] { "\r\n" }, StringSplitOptions.None);
            foreach (var item in list)
            {
                db.Player.Add(new Player() { Name = item.Trim() });
            }
            db.SaveChanges();
            txtName.Clear();
        }

        private void btnDelDealer_Click(object sender, EventArgs e)
        {

        }

        private void btnDelPlayer_Click(object sender, EventArgs e)
        {

        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            main.Show();
            Close();
        }
    }
}
