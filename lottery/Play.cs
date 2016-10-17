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

    public partial class Play : Form
    {
        private string dealerName = string.Empty; //庄家名称
        private double betMoney = 0; //开庄金额
        private int dealerPoint = 0; //庄家点数
        private int gameID = 0;
        private int gameOrder = 0;
        private double dealerBalance = 0;//庄家结余
        private LotteryDbContext db = new LotteryDbContext();

        public Play(string dealerName, int betMoney, int gameID)
        {
            this.dealerName = dealerName;
            this.betMoney = betMoney;
            this.gameID = gameID;
            InitializeComponent();
            dealerBalance = betMoney;
            txtBetMoney.Text = betMoney.ToString();
            txtDealerBalance.Text = betMoney.ToString();
            txtDealer.Text = dealerName;
            var game = db.Game.SingleOrDefault(g => g.GameID == gameID);
            gameOrder = game.GameOrder;
            lbGameCount.Text = $"当前第{gameOrder}局";
        }



        private List<Player> GetPlayerList()
        {
            return db.Player.Where(p=>p.IsDel==false).ToList();
        }
        private void btnCal_Click(object sender, EventArgs e)
        {
            bool b = int.TryParse(txtDealerPoint.Text, out dealerPoint);
            if (!b)
            {
                MessageBox.Show("输入正确的庄家点数");
                return;
            }
            PlayDetail detail = null;
            PlayDetail lastDetail = null;
            var lastRound = db.Round.OrderByDescending(r => r.RoundID).FirstOrDefault(); //查出最近的一把
            double totalProfit = 0;//总盈亏
            foreach (DataGridViewRow row in lotteryView.Rows)
            {
                bool bb = true;
                int playerBetMoney = 0; //闲家投注
                bb = int.TryParse(row.Cells["Money"].Value.ToString(), out playerBetMoney);
                int multiple = 0; //闲家倍数
                bb = int.TryParse(row.Cells["Multiple"].Value.ToString(), out multiple);
                int dealerPoint = 0; //庄家点数
                bb = int.TryParse(txtDealerPoint.Text, out dealerPoint);
                if (!bb)
                {
                    MessageBox.Show("请输入正确的投注金额和倍数");
                    return;
                }
              
                int profit = 0;              
                double lastBalance = 0; //上把闲家结余
                double balance = 0; //本把闲家结余
                var cell = row.Cells["Player"] as DataGridViewComboBoxCell;
                int playerId = int.Parse(cell.Value.ToString());
                if (lastRound != null) //如果存在上一把
                {
                    lastDetail = db.PlayDetail.SingleOrDefault(p => p.RoundOrder == lastRound.RoundOrder && p.PlayerID==playerId);
                    lastBalance = lastDetail==null?0: lastDetail.Balance; //则赋值上把结余,如果该玩家没有上把，则为0
                }
                if (multiple>dealerPoint) //闲家点数大，则闲家赢，按闲家倍数赔
                {
                    profit= playerBetMoney * Math.Abs(multiple); //计算出盈亏
                    row.Cells["PlayerProfit"].Value = profit;
                    row.Cells["DealerProfit"].Value = -profit;
                    balance = profit + lastBalance; //计算出本次闲家结余
                    totalProfit -= profit; //计算本把总盈亏
                }
                else if (multiple<dealerPoint) //闲家点数小，则庄家赢，按庄家点数赔
                {
                    profit = playerBetMoney * Math.Abs(dealerPoint);
                    row.Cells["Multiple"].Value = dealerPoint; //倍数变为庄家点数
                    row.Cells["PlayerProfit"].Value = -profit;
                    row.Cells["DealerProfit"].Value = profit;
                    balance = -profit + lastBalance; //计算出本次闲家结余
                    totalProfit += profit; //计算本把总盈亏
                }
                else //如果打平
                {
                    row.Cells["PlayerProfit"].Value = "0";
                    row.Cells["DealerProfit"].Value = "0";
                    balance = lastBalance;
                }
                row.Cells["LastSurplus"].Value = lastBalance;
                row.Cells["Surplus"].Value = balance;
                detail = new PlayDetail();               
                detail.PlayerID = playerId;
                detail.RoundOrder = lastRound == null ? 1 : lastRound.RoundOrder + 1;
                lbRoundCount.Text = $"当前第{detail.RoundOrder}轮";
                detail.BetMoney = playerBetMoney;
                detail.Balance = balance;
                detail.Multiple = multiple;
                db.PlayDetail.Add(detail);              
            }
            txtTotalProfit.Text = totalProfit.ToString();
            dealerBalance = dealerBalance + totalProfit;
            txtDealerBalance.Text = dealerBalance.ToString();
            Round round = new Round()
            {
                RoundOrder = lastRound == null ? 1 : lastRound.RoundOrder + 1,
                DealerBalance = dealerBalance, //庄家结余
                GameID = gameID
            };
            db.Round.Add(round);
            db.SaveChanges();
        }

        private void btnAddPlayer_Click(object sender, EventArgs e)
        {
            lotteryView.Rows.Add();            
        }

        private void lotteryView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            var cell = lotteryView.Rows[e.RowIndex].Cells[0] as DataGridViewComboBoxCell;
            cell.DataSource = db.Player.ToList();
            cell.DisplayMember = "Name";
            cell.ValueMember = "PlayerID";
        }

        private void btnRemovePlayer_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in lotteryView.SelectedRows)
            {
                lotteryView.Rows.RemoveAt(item.Index);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtDealerPoint.Text = string.Empty;
            lotteryView.Rows.Clear();
        }

        private void btnChangeDealer_Click(object sender, EventArgs e)
        {
            new Main().Show();
            Close();
        }

        private void btnAddNewPlayer_Click(object sender, EventArgs e)
        {
            var name = txtNewPlayerName.Text.Trim();
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("请输入一个有效的名字");
            }
            if (Helper.ExistUser(name,1))
            {
                MessageBox.Show("已经存在同名的闲家，无法添加！");
                return;
            }
            var player = new Player() { Name = name, IsDel = false };
            db.Player.Add(player);
            db.SaveChanges();
            txtNewPlayerName.Clear();
            MessageBox.Show("添加成功");
        }
    }
}
