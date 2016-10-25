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
        public UserManage()
        {
            InitializeComponent();
            TextBox.CheckForIllegalCrossThreadCalls = false;
            ListBox.CheckForIllegalCrossThreadCalls = false;
            Thread t = new Thread(() =>
              {
                  UserListInit();
              });
            t.Start();
        }

        private void UserListInit()
        {
            lbMsg.Text = "正在加载玩家名单";
            lbPlayer.DataSource = db.Player.Where(d => d.IsDel == false).ToList();
            lbPlayer.DisplayMember = "Name";
            lbPlayer.ValueMember = "PlayerID";
            lbMsg.Text = string.Empty;
        }

        private void btnAddPlayer_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(() =>
              {
                  string[] list = txtName.Text.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                  foreach (var item in list)
                  {
                      if (Helper.ExistUser(item.Trim()))
                      {
                          MessageBox.Show($"已经存在和{item.Trim()}重名的玩家，不能重复添加");
                          return;
                      }
                      db.Player.Add(new Player() { Name = item.Trim(), IsDel = false });
                  }
                  db.SaveChanges();
                  txtName.Clear();
                  UserListInit();
              });
            t.Start();
        }


        private void btnDelPlayer_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(() =>
              {
                  if (lbPlayer.SelectedValue==null)
                  {
                      MessageBox.Show("没有用户了");
                      return;
                  }
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
            Close();
        }
    }
}
