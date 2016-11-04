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
        private string dealerName; //庄家名称
        private int dealerID;
        private double betMoney; //开庄金额
        private int dealerPoint; //庄家点数
        private int gameID;
        private int gameOrder;
        private int currentRoundId; //当前轮ID
        private int currentRoundOrder; //当前轮数
        private int lastRoundId;
        private int lastRoundOrder;//上一轮数
        private double dealerBalance;//庄家结余
        private LotteryDbContext db;
        private bool isNewRound;
        private List<string> tempPlayerName = new List<string>(); //保存从数据库里查出来的闲家名字，用来检查新添加的闲家重名

        public Play(string dealerName, double betMoney, int gameID,int dealerID)
        {
            this.dealerName = dealerName;
            this.dealerID = dealerID;
            this.betMoney = betMoney;
            this.gameID = gameID;
            isNewRound = false;
            db = DBSession.GetDbContext();
            InitializeComponent();
            txtDealer.Text = dealerName;
            var game = db.Game.SingleOrDefault(g => g.GameID == gameID);
            gameOrder = game.GameOrder;
            dealerBalance = betMoney; //一开始庄家的结余等于投注金额
            txtBetMoney.Text = betMoney.ToString();
            txtDealerBalance.Text = betMoney.ToString();
            InitRound(); //开局的时候就初始化一轮
            LoadAllPlayer();
        }

        //刷新表格
        public async void ReLoadTable()
        {
            lotteryView.Rows.Clear();
            var list = await db.Player.Where(p=>p.IsDel==false).ToListAsync();
            foreach (var player in list)
            {
                if (player.PlayerID==dealerID) //如果是庄家
                {
                    continue;
                }
                int index = lotteryView.Rows.Add();
                var playDetail = await db.PlayDetail.SingleOrDefaultAsync(p => p.PlayerID == player.PlayerID && p.Round.RoundOrder == currentRoundOrder && p.Round.GameID == gameID);
                if (playDetail == null) //如果该闲家本盘未参与,则查出最近一盘数据
                {
                    playDetail = await db.PlayDetail.Where(p => p.PlayerID == player.PlayerID && p.Round.GameID==gameID).OrderByDescending(p => p.RoundID).FirstOrDefaultAsync();
                    lotteryView.Rows[index].Cells["PlayerID"].Value = player.PlayerID;
                    lotteryView.Rows[index].Cells["Player"].Value = player.Name;
                    if (playDetail == null)//如果没有最近一盘
                    {
                    }
                    else
                    {
                        lotteryView.Rows[index].Cells["LastSurplus"].Value = playDetail.Balance;
                    }
                }
                else
                {
                    lotteryView.Rows[index].Cells["PlayDetailID"].Value = playDetail.PlayDetailID;
                    lotteryView.Rows[index].Cells["PlayerID"].Value = player.PlayerID;
                    lotteryView.Rows[index].Cells["Player"].Value = player.Name;
                    lotteryView.Rows[index].Cells["Money"].Value = playDetail.BetMoney;
                    lotteryView.Rows[index].Cells["Multiple"].Value = playDetail.FinalMultiple;
                    lotteryView.Rows[index].Cells["OriginNumber"].Value = playDetail.OriginNumber;
                    lotteryView.Rows[index].Cells["PlayerProfit"].Value = playDetail.Profit;
                    lotteryView.Rows[index].Cells["DealerProfit"].Value = -playDetail.Profit;
                    //查出该玩家在本局的上轮情况
                    var lastRound = await db.PlayDetail.FirstOrDefaultAsync(p => p.PlayerID == player.PlayerID && p.Round.RoundOrder == lastRoundOrder && p.Round.GameID == gameID);
                    if (lastRound != null)
                    {
                        lotteryView.Rows[index].Cells["LastSurplus"].Value = lastRound.Balance;
                    }
                    else
                    {
                        lotteryView.Rows[index].Cells["LastSurplus"].Value = 0;
                    }
                    lotteryView.Rows[index].Cells["Surplus"].Value = playDetail.Balance;
                }
            }
        }

        //加载窗体时，把所有闲家加载进datagridview
        private async void LoadAllPlayer()
        {
            var list = await db.Player.Where(p => p.IsDel == false).ToListAsync();
            foreach (var player in list)
            {
                if (player.PlayerID==dealerID)
                {
                    continue;
                }
                int index = lotteryView.Rows.Add();
                lotteryView.Rows[index].Cells["PlayerID"].Value = player.PlayerID;
                lotteryView.Rows[index].Cells["Player"].Value = player.Name;
                tempPlayerName.Clear();
                tempPlayerName.Add(player.Name);
            }
        }

        //初始化一轮
        private void InitRound()
        {
            var lastRound = db.Round.Where(r => r.GameID == gameID).OrderByDescending(r => r.RoundID).FirstOrDefault(); //查出本局最近的一把
            if (lastRound != null)
            {
                lastRoundOrder = lastRound.RoundOrder;
                lastRoundId = lastRound.RoundID;
                currentRoundOrder = lastRound.RoundOrder + 1;
            }
            else
            {
                currentRoundOrder = 1;
            }
            Round round = new Round() { GameID = gameID, RoundOrder = currentRoundOrder,PlayTime=DateTime.Now };
            var model = db.Round.Add(round);
            db.SaveChanges();
            currentRoundId = model.RoundID;
            isNewRound = true; //表示新的一轮
            lbTime.Text = DateTime.Now.ToLongDateString () + " " + DateTime.Now.ToLongTimeString();
        }

        //开始计算
        private async void btnCal_Click(object sender, EventArgs e)
        {

            if (!isNewRound)
            {
                MessageBox.Show("当前轮已结束，请开始新的一轮");
                return;
            }
            dealerPoint = Helper.CalPoint(txtDealerPoint.Text);
            if (dealerPoint == -1)
            {
                MessageBox.Show("点数和倍数请输入三位数");
                return;
            }
            txtDealerPoint.Text = dealerPoint.ToString();
            PlayDetail detail = null;
            PlayDetail lastDetail = null;
            int finalMultiple = 0; //最终盈亏倍数
            int playerBetMoney = 0; //闲家投注
            double dealerProfit = 0; //庄家本轮盈亏
            foreach (DataGridViewRow row in lotteryView.Rows)
            {
                if (row.Cells["Money"].Value == null)
                {
                    row.Cells["Money"].Value = 0;
                    playerBetMoney = 0;
                }
                else
                {
                    if (!int.TryParse(row.Cells["Money"].Value.ToString(),out playerBetMoney))
                    {
                        MessageBox.Show("请输入正确的金额");
                    }
                }
                int multiple = 0; //闲家倍数
                if (row.Cells["OriginNumber"].Value == null)
                {
                    row.Cells["OriginNumber"].Value = 0;
                    multiple = 0;
                }
                else
                {
                    multiple = Helper.CalPoint(row.Cells["OriginNumber"].Value.ToString());
                    if (multiple == -1)
                    {
                        MessageBox.Show("点数和倍数请输入三位数");
                        return;
                    }
                }
                double profit = 0;
                double lastBalance = 0; //上把闲家结余
                double balance = 0; //本把闲家结余
                int playerId = -1;
                if (row.Cells["PlayerID"].Value != null) //如果存在ID
                {
                    playerId = int.Parse(row.Cells["PlayerID"].Value.ToString());
                }
                else //是新加入的闲家
                {
                    object name = row.Cells["Player"].Value;
                    if (name == null)
                    {
                        if (string.IsNullOrEmpty(name.ToString()))
                        {
                            MessageBox.Show("闲家名字不能为空，请补上名字或移除该条投注");
                            return;
                        }
                    }
                    if (tempPlayerName.Any(t => string.Equals(t, name.ToString())))
                    {
                        MessageBox.Show("闲家名字重复");
                        continue;
                    }
                    var player = new Player() { Name = name.ToString(), IsDel = false};
                    db.Player.Add(player); //将新增的闲家保存进数据库
                    db.SaveChanges();
                    playerId = player.PlayerID;
                }
                if (lastRoundOrder != 0) //如果存在上一把
                {
                    lastDetail = await db.PlayDetail.SingleOrDefaultAsync(p => p.RoundID == lastRoundId && p.PlayerID == playerId);
                    lastBalance = lastDetail == null ? 0 : lastDetail.Balance; //则赋值上把结余,如果该玩家没有上把，则为0
                }

                if (multiple == 0 || dealerPoint == 0) //玩家0.01的情况
                {
                    finalMultiple = multiple;
                    balance = lastBalance;
                }
                else if(multiple > dealerPoint) //闲家点数大，则闲家赢，按闲家倍数赔
                {
                    finalMultiple = multiple;
                    profit = Math.Abs(playerBetMoney) * multiple; //计算出盈亏
                    balance = profit + lastBalance; //计算出本次闲家结余
                    dealerProfit += -profit; //计算本把庄家盈亏
                }
                else if (multiple < dealerPoint) //闲家点数小，则庄家赢，按庄家点数赔
                {
                    finalMultiple = -dealerPoint; //倍数变为庄家点数的负数
                    profit = Math.Abs(playerBetMoney) * finalMultiple;
                    balance = profit + lastBalance; //计算出本次闲家结余
                    dealerProfit += -profit; //计算本把庄家盈亏
                }
                else //如果打平
                {
                    finalMultiple = multiple;
                    balance = lastBalance;
                }
                detail = new PlayDetail();
                detail.PlayerID = playerId;
                detail.RoundID = currentRoundId; //保存本轮id
                detail.GameID = gameID; //保存本局id
                lbRoundCount.Text = $"当前第{currentRoundOrder}轮";
                detail.BetMoney = playerBetMoney;
                detail.Balance = balance;
                detail.OriginNumber = row.Cells["OriginNumber"].Value.ToString();
                detail.Multiple = multiple;
                detail.FinalMultiple = finalMultiple;
                detail.Profit = profit;
                detail.PlayerType = PlayerType.Player;
                db.PlayDetail.Add(detail);
            }
            dealerBalance += dealerProfit; //最后计算出庄家总盈亏
            var dealerDetail = new PlayDetail();//记录庄家信息
            dealerDetail.PlayerID = dealerID;
            dealerDetail.RoundID = currentRoundId;
            dealerDetail.GameID = gameID;
            dealerDetail.BetMoney = betMoney;
            dealerDetail.Balance = dealerBalance;
            dealerDetail.OriginNumber = txtDealerPoint.Text;
            dealerDetail.Multiple = dealerPoint;
            dealerDetail.FinalMultiple = dealerPoint;
            dealerDetail.Profit = dealerProfit;
            dealerDetail.PlayerType = PlayerType.Dealer;
            db.PlayDetail.Add(dealerDetail);
            await db.SaveChangesAsync();
            txtDealerProfit.Text = dealerProfit.ToString();
            txtDealerBalance.Text = dealerBalance.ToString();
            UpdateGameStatus(); //更新本局状态
            ReLoadTable();
            isNewRound = false; //表示该轮已经结束  
        }

        private async void UpdateGameStatus()
        {
            var game = await db.Game.SingleOrDefaultAsync(g => g.GameID == gameID);
            if (game != null)
            {
                game.Balance = dealerBalance;
            }
            game.EndTime = DateTime.Now;
            //if (game.Balance>0)
            //{
            //    game.Fee = game.Fee + game.Balance * 0.03;
            //}
            db.Entry(game).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }

        private void btnAddPlayer_Click(object sender, EventArgs e)
        {
            lotteryView.Rows.Add();
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
            if (isNewRound)
            {
                MessageBox.Show("当前已是新的一轮");
                return;
            }
            txtDealerPoint.Text = string.Empty;
            isNewRound = true;
            lotteryView.Rows.Clear();
            InitRound();
            LoadAllPlayer(); //重新加载表格
        }

        //返回开庄
        private void btnChangeDealer_Click(object sender, EventArgs e)
        {
            UpdateGameStatus(); //换庄时更新本局状态
            new Result(gameID).ShowDialog();
            Close();
        }

        private void lotteryView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;           
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                int multiple = 0;
                int finalMultiple = 0;
                double profit = 0;
                double betMoney = 0;
                double balance = 0;
                double lastBalance = 0;
                if (senderGrid.Rows[e.RowIndex].Cells["PlayDetailID"].Value==null)
                {
                    MessageBox.Show("闲家为空");
                    return;
                }
                if (senderGrid.Rows[e.RowIndex].Cells["Money"].Value==null)
                {
                    MessageBox.Show("金额为空");
                    return;
                }
                if (senderGrid.Rows[e.RowIndex].Cells["Multiple"].Value==null)
                {
                    MessageBox.Show("倍数为空");
                    return;
                }
                int playerDetailId = int.Parse(senderGrid.Rows[e.RowIndex].Cells["PlayDetailID"].Value.ToString());
                bool b = double.TryParse(senderGrid.Rows[e.RowIndex].Cells["Money"].Value.ToString(), out betMoney);
                multiple = Helper.CalPoint(senderGrid.Rows[e.RowIndex].Cells["OriginNumber"].Value.ToString());
                if (multiple == -1)
                {
                    MessageBox.Show("点数和倍数请输入三位数");
                    return;
                }
                var model = db.PlayDetail.SingleOrDefault(p => p.PlayDetailID == playerDetailId);
                int roundId = model.RoundID;
                //找出本轮庄家信息
                var dealerModel = db.PlayDetail.SingleOrDefault(p => p.RoundID == roundId && p.PlayerType == PlayerType.Dealer);
                //还原庄家数据
                dealerModel.Profit = dealerModel.Profit - (-model.Profit);
                dealerBalance= dealerModel.Balance - (-model.Profit);
                dealerModel.Balance = dealerBalance;
                if (multiple == 0 || dealerPoint == 0) //玩家拿到0.01
                {
                    finalMultiple = multiple;
                    balance = lastBalance;
                }
                else if(multiple > dealerPoint) //闲家点数大，则闲家赢，按闲家倍数赔
                {
                    finalMultiple = multiple;
                    profit = Math.Abs(betMoney) * multiple; //计算出盈亏
                    balance = profit + lastBalance; //计算出本次闲家结余
                    dealerModel.Profit += -profit;
                    dealerBalance += -profit;
                    dealerModel.Balance = dealerBalance;
                }
                else if (multiple < dealerPoint) //闲家点数小，则庄家赢，按庄家点数赔
                {
                    finalMultiple = -dealerPoint; //倍数变为庄家点数的负数
                    profit = Math.Abs(betMoney) * finalMultiple;
                    balance = profit + lastBalance; //计算出本次闲家结余
                    dealerModel.Profit += -profit;
                    dealerBalance += -profit;
                    dealerModel.Balance = dealerBalance;
                }
                else //如果打平
                {
                    finalMultiple = multiple;
                    balance = lastBalance;
                }
                model.Multiple = multiple;
                model.OriginNumber = senderGrid.Rows[e.RowIndex].Cells["OriginNumber"].Value.ToString();
                model.BetMoney = betMoney;
                model.FinalMultiple = finalMultiple;
                model.Balance = balance;
                model.Profit = profit;
                db.Entry(model).State = EntityState.Modified;
                db.Entry(dealerModel).State = EntityState.Modified;
                db.SaveChanges();
                txtDealerProfit.Text = dealerModel.Profit.ToString();
                txtDealerBalance.Text = dealerModel.Balance.ToString();
                ReLoadTable();
                UpdateGameStatus();
            }
        }

        private void Edit_FormClosed(object sender, FormClosedEventArgs e)
        {
            MessageBox.Show("Test");
            ReLoadTable();
        }

        private void btnAddDealMoney_Click(object sender, EventArgs e)
        {
            double temp = 0;
            if (!double.TryParse(txtAddDeal.Text,out temp))
            {
                MessageBox.Show("请输入正确的追庄金额");
                return;
            }
            betMoney += temp * 0.98; //追加开庄金额
            dealerBalance += temp * 0.98; //追加庄家结余            
            var game=db.Game.SingleOrDefault(g => g.GameID == gameID);
            game.BetMoney = betMoney;
            game.Balance = dealerBalance;
            game.Fee = game.Fee + temp * 0.02;
            db.Entry(game).State = EntityState.Modified;
            var playDetail = db.PlayDetail.Where(p => p.PlayerID == dealerID).OrderByDescending(p => p.PlayDetailID).FirstOrDefault();
            if (playDetail!=null)
            {
                playDetail.Balance = dealerBalance;
                db.Entry(playDetail).State = EntityState.Modified;
            }
            db.SaveChanges();
            txtBetMoney.Text = betMoney.ToString();
            txtDealerBalance.Text = dealerBalance.ToString();
            txtAddDeal.Clear();
        }
    }
}
