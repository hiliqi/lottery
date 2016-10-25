﻿using System;
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
        private int currentRoundId = -1; //当前轮ID
        private int currentRoundOrder = 0; //当前轮数
        private int lastRoundId = -1;
        private int lastRoundOrder = 0;//上一轮数
        double dealerBalance = 0;//庄家结余
        private LotteryDbContext db = new LotteryDbContext();
        private bool isNewRound = false;
        private List<string> tempPlayerName = new List<string>(); //保存从数据库里查出来的闲家名字，用来检查新添加的闲家重名

        public Play(string dealerName, int betMoney, int gameID)
        {
            this.dealerName = dealerName;
            this.betMoney = betMoney;
            this.gameID = gameID;
            InitializeComponent();
            txtDealer.Text = dealerName;
            var game = db.Game.SingleOrDefault(g => g.GameID == gameID);
            gameOrder = game.GameOrder;
            lbGameCount.Text = $"当前第{gameOrder}局";
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
            var list = await db.Player.ToListAsync();
            foreach (var player in list)
            {
                int index = lotteryView.Rows.Add();
                var playDetail = await db.PlayDetail.SingleOrDefaultAsync(p => p.PlayerID == player.PlayerID && p.Round.RoundOrder == currentRoundOrder && p.Round.GameID == gameID);
                if (playDetail == null) //如果该闲家本盘未参与,则查出最近一盘数据
                {
                    playDetail = await db.PlayDetail.Where(p => p.PlayerID == player.PlayerID && p.Round.GameID==gameID).OrderByDescending(p => p.RoundID).FirstOrDefaultAsync();
                    lotteryView.Rows[index].Cells["PlayerID"].Value = player.PlayerID;
                    lotteryView.Rows[index].Cells["Player"].Value = player.Name;
                    if (playDetail == null)//如果没有最近一盘
                    {
                        //lotteryView.Rows[index].Cells["LastSurplus"].Value = 0;
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
            Round round = new Round() { GameID = gameID, RoundOrder = currentRoundOrder };
            var model = db.Round.Add(round);
            db.SaveChanges();
            betMoney = dealerBalance; //新一轮开始时，本轮庄家投注等于上一轮的庄家结余
            currentRoundId = model.RoundID;
            isNewRound = true; //表示新的一轮
        }

        //开始计算
        private async void btnCal_Click(object sender, EventArgs e)
        {
            if (!isNewRound)
            {
                MessageBox.Show("当前轮已结束，请开始新的一轮");
                return;
            }
            bool b = int.TryParse(txtDealerPoint.Text, out dealerPoint);
            if (!b)
            {
                MessageBox.Show("输入正确的庄家点数");
                return;
            }
            if (dealerPoint < 0)
            {
                MessageBox.Show("点数必须大于0");
                return;
            }
            PlayDetail detail = null;
            PlayDetail lastDetail = null;
            int finalMultiple = 0; //最终盈亏倍数
            int playerBetMoney = 0; //闲家投注
            foreach (DataGridViewRow row in lotteryView.Rows)
            {
                if (row.Cells["Money"].Value == null)
                {
                    row.Cells["Money"].Value = 0;
                    playerBetMoney = 0;
                }
                else if (!int.TryParse(row.Cells["Money"].Value.ToString(), out playerBetMoney))
                {
                    MessageBox.Show("请输入正确的投注金额和倍数");
                    return;
                }
                int multiple = 0; //闲家倍数
                if (row.Cells["Multiple"].Value == null)
                {
                    row.Cells["Multiple"].Value = 0;
                    multiple = 0;
                }
                else if (!int.TryParse(row.Cells["Multiple"].Value.ToString(), out multiple))
                {
                    MessageBox.Show("请输入正确的投注金额和倍数");
                    return;
                }
                int profit = 0;
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
                    var player = new Player() { Name = name.ToString(), IsDel = false };
                    db.Player.Add(player); //将新增的闲家保存进数据库
                    db.SaveChanges();
                    playerId = player.PlayerID;
                }

                if (lastRoundOrder != 0) //如果存在上一把
                {
                    lastDetail = await db.PlayDetail.SingleOrDefaultAsync(p => p.RoundID == lastRoundId && p.PlayerID == playerId);
                    lastBalance = lastDetail == null ? 0 : lastDetail.Balance; //则赋值上把结余,如果该玩家没有上把，则为0
                }
                if (multiple > dealerPoint) //闲家点数大，则闲家赢，按闲家倍数赔
                {
                    finalMultiple = multiple;
                    profit = playerBetMoney * multiple; //计算出盈亏
                    balance = profit + lastBalance; //计算出本次闲家结余
                    //dealerProfit -= profit; //计算本把庄家盈亏
                }
                else if (multiple < dealerPoint) //闲家点数小，则庄家赢，按庄家点数赔
                {
                    finalMultiple = -dealerPoint; //倍数变为庄家点数的负数
                    profit = playerBetMoney * finalMultiple;
                    balance = profit + lastBalance; //计算出本次闲家结余
                   // dealerProfit += -profit; //计算本把庄家盈亏
                }
                else //如果打平
                {
                    finalMultiple = multiple;
                    balance = lastBalance;
                }
                detail = new PlayDetail();
                detail.PlayerID = playerId;
                detail.RoundID = currentRoundId; //赋值本轮id
                lbRoundCount.Text = $"当前第{currentRoundOrder}轮";
                detail.BetMoney = playerBetMoney;
                detail.Balance = balance;
                detail.Multiple = multiple;
                detail.FinalMultiple = finalMultiple;
                detail.Profit = profit;
                db.PlayDetail.Add(detail);
                await db.SaveChangesAsync();
            }
            
            UpdateRoundStatus(); //更新本轮状态
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
            game.Fee = betMoney * 0.03;
            if (game.Balance>0)
            {
                game.Fee = game.Fee + game.Balance * 0.02;
            }
            db.Entry(game).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }

        //计算时更新当前轮状态
        private async void UpdateRoundStatus()
        {
            var round = db.Round.SingleOrDefault(r => r.RoundID == currentRoundId);
            if (round == null)
            {
                MessageBox.Show("获取当前轮出现错误，请联系软件作者");
            }
            double lastRoundBalance = 0;
            var lastRound = db.Round.SingleOrDefault(r => r.RoundID == lastRoundId);
            if (lastRound==null) //说明没有上一把
            {
                lastRoundBalance = betMoney;
            }
            else
            {
                lastRoundBalance = lastRound.DealerBalance;
            }           
            var list = db.PlayDetail.Where(p => p.RoundID == currentRoundId); //找出本轮所有detail
            double dealerProfit = -list.Sum(l => l.Profit);
            dealerBalance = lastRoundBalance + dealerProfit;
            round.DealerProfit = dealerProfit;//庄家盈亏
            round.DealerBalance = dealerBalance; //庄家结余
            db.Entry(round).State = EntityState.Modified;
            await db.SaveChangesAsync();
            txtDealerBalance.Text = dealerBalance.ToString();
            txtDealerProfit.Text = dealerProfit.ToString();
        }

        //增加投注
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
            int multiple = 0;
            int finalMultiple = 0;
            double profit = 0;
            double betMoney = 0;
            double balance = 0;
            double lastBalance = 0;
            int playerDetailId = int.Parse(senderGrid.Rows[e.RowIndex].Cells["PlayDetailID"].Value.ToString());
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                //edit = new Edit(
                //     int.Parse(senderGrid.Rows[e.RowIndex].Cells["PlayDetailID"].Value.ToString()),
                //     senderGrid.Rows[e.RowIndex].Cells["Player"].Value.ToString(),
                //     double.Parse(senderGrid.Rows[e.RowIndex].Cells["Money"].Value.ToString()),
                //     int.Parse(senderGrid.Rows[e.RowIndex].Cells["Multiple"].Value.ToString()),
                //     dealerPoint,
                //     double.Parse(senderGrid.Rows[e.RowIndex].Cells["LastSurplus"].Value.ToString()),
                //     this
                // );
                //edit.FormClosed += Edit_FormClosed;
                //edit.ShowDialog();        
                bool b = double.TryParse(txtBetMoney.Text, out betMoney);
                b = int.TryParse(senderGrid.Rows[e.RowIndex].Cells["Multiple"].Value.ToString(), out multiple);
                if (!b)
                {
                    MessageBox.Show("请输入正确的金额和倍数");
                    return;
                }
                var model = db.PlayDetail.SingleOrDefault(p => p.PlayDetailID == playerDetailId);
                if (multiple > dealerPoint) //闲家点数大，则闲家赢，按闲家倍数赔
                {
                    finalMultiple = multiple;
                    profit = betMoney * multiple; //计算出盈亏
                    balance = profit + lastBalance; //计算出本次闲家结余
                }
                else if (multiple < dealerPoint) //闲家点数小，则庄家赢，按庄家点数赔
                {
                    finalMultiple = -dealerPoint; //倍数变为庄家点数的负数
                    profit = betMoney * finalMultiple;
                    balance = profit + lastBalance; //计算出本次闲家结余
                }
                else //如果打平
                {
                    finalMultiple = multiple;
                    balance = lastBalance;
                }
                model.Multiple = multiple;
                model.BetMoney = betMoney;
                model.FinalMultiple = finalMultiple;
                model.Balance = balance;
                model.Profit = profit;
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
                ReLoadTable();
                UpdateRoundStatus();
            }
        }

        private void Edit_FormClosed(object sender, FormClosedEventArgs e)
        {
            MessageBox.Show("Test");
            ReLoadTable();
        }
    }
}
