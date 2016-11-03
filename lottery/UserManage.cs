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
        LotteryDbContext db;
        private double money;
        private int playerId;
        private string name;
        public UserManage()
        {
            db = DBSession.GetDbContext();
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
            var list = db.Player.Where(d => d.IsDel == false).ToList();
            foreach (var player in list)
            {
                int index = userView.Rows.Add();
                playerId = player.PlayerID;
                userView.Rows[index].Cells["PlayerID"].Value = playerId;
                name = player.Name;
                userView.Rows[index].Cells["PlayerName"].Value = name;
                var playerDetail = db.PlayDetail.Where(p => p.PlayerID == player.PlayerID).OrderByDescending(p => p.PlayDetailID).FirstOrDefault();
                if (playerDetail != null)
                {
                    money = playerDetail.Balance;
                    userView.Rows[index].Cells["Money"].Value = money;
                }               
            }
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

        private void userView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            int playerId = -1;
            if (!int.TryParse(senderGrid.Rows[e.RowIndex].Cells["PlayerID"].Value.ToString(), out playerId))
            {
                MessageBox.Show("选择正确的玩家");
            }
            if (senderGrid.Columns[e.ColumnIndex].Name== "Settle" && e.RowIndex >= 0)
            {              
                new Settle(playerId).ShowDialog();
            }
            else if(senderGrid.Columns[e.ColumnIndex].Name == "GoBet" && e.RowIndex >= 0)
            {
                int gameOrder = 1; //保存局数
                var game = db.Game.OrderByDescending(g => g.GameID).FirstOrDefault();
                if (game != null)
                {
                    gameOrder = game.GameOrder + 1; //查出最近一局的局数
                }
                Game model = new Game()
                {
                    GameOrder = gameOrder,
                    BetMoney = money, //玩家结余加上追加金额
                    PlayerID = playerId,
                    PlayTime = DateTime.Now,
                    Year = DateTime.Now.Year,
                    Month = DateTime.Now.Month,
                    Day = DateTime.Now.Day,
                    Fee = money * 0.02
                };
                db.Game.Add(model);
                db.SaveChanges();
                Play play = new Play(name, money * 0.98, model.GameID, playerId);
                play.Show();
                Close();
            }
        }
    }
}
