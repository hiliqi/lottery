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
            Button.CheckForIllegalCrossThreadCalls = false;
            new Thread(() => { UserListInit(); }).Start();
        }

        //加载玩家列表
        private void UserListInit()
        {
            lbMsg.Text = "正在加载玩家列表";
            userView.Rows.Clear();
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
            }
            lbMsg.Text = "加载完毕";
        }

        //添加玩家
        private void btnAddPlayer_Click(object sender, EventArgs e)
        {
            new Thread(() =>
              {
                  string name = txtPlayer.Text;
                  if (string.IsNullOrEmpty(name))
                  {
                      lbMsg.Text = "请输入玩家名";
                      return;
                  }
                  if (Helper.ExistUser(name))
                  {
                      lbMsg.Text = $"已经存在和{name}重名的玩家，不能重复添加";
                      return;
                  }
                  lbMsg.Text = "正在添加玩家";
                  db.Player.Add(new Player() { Name = name, IsDel = false });
                  db.SaveChanges();
                  lbMsg.Text = "添加玩家成功";
                  txtPlayer.Clear();
                  UserListInit();
              }).Start();
            
        }

        private void userView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            double money = 0;
            string name;
            int playerId = -1;
            if (senderGrid.Rows[e.RowIndex].Cells["PlayerID"].Value == null)
            {
                lbMsg.Text= "选择正确的玩家";
                return;
            }
            else if (!int.TryParse(senderGrid.Rows[e.RowIndex].Cells["PlayerID"].Value.ToString(), out playerId))
            {
                lbMsg.Text = "选择正确的玩家";
                return;
            }

            if (senderGrid.Rows[e.RowIndex].Cells["Money"].Value == null)
            {
                lbMsg.Text = "请输入一个金额";
                return;
            }
            else if (!double.TryParse(senderGrid.Rows[e.RowIndex].Cells["Money"].Value.ToString(), out money))
            {
                lbMsg.Text = "玩家金额不对";
                return;
            }
            money = Math.Abs(money);

            name = senderGrid.Rows[e.RowIndex].Cells["PlayerName"].Value.ToString();
            if (senderGrid.Columns[e.ColumnIndex].Name == "GoBet" && e.RowIndex >= 0) //开庄
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
                    BetMoney = money, //开庄金额
                    PlayerID = playerId,
                    PlayTime = DateTime.Now,
                    Year = DateTime.Now.Year,
                    Month = DateTime.Now.Month,
                    Day = DateTime.Now.Day,
                    Fee = money*0.02
                };
                db.Game.Add(model);
                db.SaveChanges();
                money = money * 0.98; //抽成后开庄金额
                Play play = new Play(name, money, model.GameID, playerId);
                play.ShowDialog();
            }
        }

        private void btnLoadView_Click(object sender, EventArgs e)
        {
            UserListInit();
        }
    }
}
