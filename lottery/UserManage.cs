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
        public UserManage()
        {
            db = DBSession.GetDbContext();
            InitializeComponent();
            TextBox.CheckForIllegalCrossThreadCalls = false;
            ListBox.CheckForIllegalCrossThreadCalls = false;
        }

        private void UserListInit()
        {
            double money;
            int playerId;
            string name;
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
                    userView.Rows[index].Cells["Balance"].Value = money;
                }
            }
        }

        private void btnAddPlayer_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(() =>
            {
                string name = txtPlayer.Text;
                if (string.IsNullOrEmpty(name))
                {
                    MessageBox.Show("请输入玩家名");
                }
                if (Helper.ExistUser(name))
                {
                    MessageBox.Show($"已经存在和{name}重名的玩家，不能重复添加");
                    return;
                }
                db.Player.Add(new Player() { Name = name, IsDel = false });
                db.SaveChanges();
                txtPlayer.Clear();
                UserListInit();
            });
            t.Start();
        }

        private void userView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            double money=0;
            string name;
            int playerId = -1;
            if (senderGrid.Rows[e.RowIndex].Cells["PlayerID"].Value==null)
            {
                MessageBox.Show("选择正确的玩家");
            }else if (!int.TryParse(senderGrid.Rows[e.RowIndex].Cells["PlayerID"].Value.ToString(), out playerId))
            {
                MessageBox.Show("选择正确的玩家");
                return;
            }

            if (senderGrid.Rows[e.RowIndex].Cells["Balance"].Value==null)
            {
                money = 0;
            }
            else if (!double.TryParse(senderGrid.Rows[e.RowIndex].Cells["Balance"].Value.ToString(), out money))
            {
                MessageBox.Show("玩家金额不对");
                return;
            }
            
            name = senderGrid.Rows[e.RowIndex].Cells["PlayerName"].Value.ToString();
            if (senderGrid.Columns[e.ColumnIndex].Name == "Settle" && e.RowIndex >= 0)
            {
                new Settle(playerId).ShowDialog();
            }
            else if (senderGrid.Columns[e.ColumnIndex].Name == "GoBet" && e.RowIndex >= 0) //开庄
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
                    Fee = money > 0 ? money * 0.02 : 0
                };
                db.Game.Add(model);
                db.SaveChanges();
                if (money>0)
                {
                    money = money * 0.98; //玩家余额是正数，则抽成
                }
                Play play = new Play(name, money, model.GameID, playerId);
                play.ShowDialog();
            }
        }

        private void btnLoadView_Click(object sender, EventArgs e)
        {
            lbLoad.Text = "正在加载玩家列表";
            UserListInit();
            lbLoad.Text = "加载完毕";
        }
    }
}
