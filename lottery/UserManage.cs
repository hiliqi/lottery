using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using System.Threading;

namespace lottery
{
    public partial class UserManage : Form
    {
        LotteryDbContext db = new LotteryDbContext();
        Main main;
        public UserManage(Main main)
        {
            InitializeComponent();
            TextBox.CheckForIllegalCrossThreadCalls = false;
            ListBox.CheckForIllegalCrossThreadCalls = false;
            this.main = main;
            UserListInit();
        }

        private void UserListInit()
        {
            lbDealer.DataSource = db.Dealer.Where(d => d.IsDel == false).ToList();
            lbDealer.DisplayMember = "Name";
            lbDealer.ValueMember = "DealerID";
            lbPlayer.DataSource = db.Player.Where(d => d.IsDel == false).ToList();
            lbPlayer.DisplayMember = "Name";
            lbPlayer.ValueMember = "PlayerID";
        }

        private void btnAddDealer_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(()=> {
                string[] list = txtName.Text.Split(new string[] { "\r\n" }, StringSplitOptions.None);
                foreach (var item in list)
                {
                    db.Dealer.Add(new Dealer() { Name = item.Trim(), IsDel = false });
                }
                db.SaveChanges();
                txtName.Clear();
            });
            t.Start();
        }

        private void btnAddPlayer_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(() =>
              {
                  string[] list = txtName.Text.Split(new string[] { "\r\n" }, StringSplitOptions.None);
                  foreach (var item in list)
                  {
                      db.Player.Add(new Player() { Name = item.Trim(), IsDel = false });
                  }
                  db.SaveChanges();
                  txtName.Clear();
              });
            t.Start();
        }

        private void btnDelDealer_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(() =>
              {
                  int id = 0;
                  bool b = int.TryParse(lbDealer.SelectedValue.ToString(), out id);
                  if (!b)
                  {
                      MessageBox.Show("删除用户出错");
                      return;
                  }
                  var model = db.Dealer.SingleOrDefault(d => d.DealerID == id);
                  model.IsDel = true;
                  db.Entry(model).State = EntityState.Modified;
                  db.SaveChanges();
                  UserListInit();
              });
            t.Start();
        }

        private void btnDelPlayer_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(() =>
              {
                  int id = 0;
                  bool b = int.TryParse(lbPlayer.SelectedValue.ToString(), out id);
                  if (!b)
                  {
                      MessageBox.Show("删除用户出错");
                      return;
                  }
                  var model = db.Player.SingleOrDefault(d => d.PlayerID == id);
                  model.IsDel = true;
                  db.Entry(model).State = EntityState.Modified;
                  db.SaveChanges();
                  UserListInit();
              });
            t.Start();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            main.Show();
            Close();
        }
    }
}
