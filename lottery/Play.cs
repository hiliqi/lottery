using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Data.Entity;

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
        private int currentRoundId = -1; //当前轮ID
        private int currentRoundOrder = 0; //当前轮数
        private int lastRoundId = -1;
        private int lastRoundOrder = 0;//上一轮数
        private LotteryDbContext db = new LotteryDbContext();
        private bool isNewRound = false;

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
            InitRound(); //开局的时候就初始化一轮
            Thread t = new Thread(() => LoadAllPlayer());
        }

        //加载窗体时，把所有闲家加载进datagridview
        private void LoadAllPlayer()
        {
            foreach (DataGridViewRow row in lotteryView.Rows)
            {
                InitPlayerList(row.Cells["Player"] as DataGridViewComboBoxCell);
            }
        }

        //初始化一轮
        private void InitRound()
        {
            var lastRound = db.Round.OrderByDescending(r => r.RoundID).FirstOrDefault(); //查出最近的一把
            if (lastRound!=null)
            {
                lastRoundOrder = lastRound.RoundOrder;
                lastRoundId = lastRound.RoundID;
                currentRoundOrder = lastRound.RoundOrder + 1;
            }
            else
            {
                currentRoundOrder = 1;
            }
            Round round = new Round() { GameID = gameID, RoundOrder = currentRoundOrder};
            var model = db.Round.Add(round);
            db.SaveChanges();
            currentRoundId = model.RoundID;
            isNewRound = true; //表示新的一轮
        }

        private void btnCal_Click(object sender, EventArgs e)
        {
            if (!isNewRound)
            {
                MessageBox.Show("当轮已结束，请开始新的一轮");
                return;
            }
            bool b = int.TryParse(txtDealerPoint.Text, out dealerPoint);
            if (!b)
            {
                MessageBox.Show("输入正确的庄家点数");
                return;
            }
            PlayDetail detail = null;
            PlayDetail lastDetail = null;
            double dealerProfit = 0;//总盈亏
            double totalBetMoney = 0;//总投注额
            double totalMoney = 0; //总流水额
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
                totalBetMoney += playerBetMoney;//累加投注额
                txtTotalBetMoney.Text = totalBetMoney.ToString();
                int profit = 0;              
                double lastBalance = 0; //上把闲家结余
                double balance = 0; //本把闲家结余
                var cell = row.Cells["Player"] as DataGridViewComboBoxCell;
                int playerId = int.Parse(cell.Value.ToString());
                if (lastRoundOrder != 0) //如果存在上一把
                {
                    lastDetail = db.PlayDetail.SingleOrDefault(p => p.RoundID == lastRoundId && p.PlayerID==playerId);
                    lastBalance = lastDetail == null ? 0 : lastDetail.Balance; //则赋值上把结余,如果该玩家没有上把，则为0
                }
                if (multiple>dealerPoint) //闲家点数大，则闲家赢，按闲家倍数赔
                {
                    profit= playerBetMoney * Math.Abs(multiple); //计算出盈亏
                    row.Cells["PlayerProfit"].Value = profit;
                    row.Cells["DealerProfit"].Value = -profit;
                    balance = profit + lastBalance; //计算出本次闲家结余
                    dealerProfit -= profit; //计算本把总盈亏
                }
                else if (multiple<dealerPoint) //闲家点数小，则庄家赢，按庄家点数赔
                {
                    profit = playerBetMoney * Math.Abs(dealerPoint);
                    row.Cells["Multiple"].Value = -dealerPoint; //倍数变为庄家点数的负数
                    row.Cells["PlayerProfit"].Value = -profit;
                    row.Cells["DealerProfit"].Value = profit;
                    balance = -profit + lastBalance; //计算出本次闲家结余
                    dealerProfit += profit; //计算本把总盈亏
                }
                else //如果打平
                {
                    row.Cells["PlayerProfit"].Value = "0";
                    row.Cells["DealerProfit"].Value = "0";
                    balance = lastBalance;
                }
                totalMoney += profit;
                row.Cells["LastSurplus"].Value = lastBalance;
                row.Cells["Surplus"].Value = balance;
                detail = new PlayDetail();               
                detail.PlayerID = playerId;
                detail.RoundID = currentRoundId; //赋值本轮id
                lbRoundCount.Text = $"当前第{currentRoundOrder}轮";
                detail.BetMoney = playerBetMoney;
                detail.Balance = balance;
                detail.Multiple = multiple;
                db.PlayDetail.Add(detail);
                db.SaveChanges();             
            }            
            txtDealerProfit.Text = dealerProfit.ToString();
            txtTotalMoney.Text = totalMoney.ToString();
            dealerBalance = dealerBalance + dealerProfit; //计算出庄家结余
            txtDealerBalance.Text = dealerBalance.ToString();
            UpdateRoundStatus(currentRoundId, dealerBalance, totalMoney, totalBetMoney); //更新本轮状态
            isNewRound = false; //表示该轮已经结束       
        }

        //计算时更新当前轮状态
        private void UpdateRoundStatus(int id,double dealerBalance,double totalMoney, double totalBetMoney)
        {
            var round = db.Round.SingleOrDefault(r => r.RoundID == id);
            if (round==null)
            {
                MessageBox.Show("获取当前轮出现错误，请联系软件作者");
            }
            round.DealerBalance = dealerBalance; //庄家结余
            round.TotalBetMoney = totalBetMoney; //总投注额
            round.TotalMoney = totalMoney; //总流水额
            db.Entry(round).State = EntityState.Modified;
            db.SaveChanges();
        }

        //增加投注
        private void btnAddPlayer_Click(object sender, EventArgs e)
        {
            lotteryView.Rows.Add();            
        }

        //增加投注事件
        private void lotteryView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            var cell = lotteryView.Rows[e.RowIndex].Cells["Player"] as DataGridViewComboBoxCell;
            InitPlayerList(cell);
        }

        //获取闲家名单并绑定到datagridview
        private void InitPlayerList(DataGridViewComboBoxCell cell)
        {
            cell.DataSource = db.Player.Where(p => p.IsDel == false).ToList();
            cell.DisplayMember = "Name";
            cell.ValueMember = "PlayerID";
        }
        //移除投注
        private void btnRemovePlayer_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in lotteryView.SelectedRows)
            {
                lotteryView.Rows.RemoveAt(item.Index);
            }
        }

        //初始化新的一轮
        private void btnNew_Click(object sender, EventArgs e)
        {
            txtDealerPoint.Text = string.Empty;
            isNewRound = true;
            lotteryView.Rows.Clear();
            InitRound();
        }

        //返回开庄
        private void btnChangeDealer_Click(object sender, EventArgs e)
        {
            Close();
        }

        //增加闲家
        private void btnAddNewPlayer_Click(object sender, EventArgs e)
        {
            var name = txtNewPlayerName.Text.Trim();
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("请输入一个有效的名字");
                return;
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
