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
        private Rectangle dragBoxFromMouseDown;
        private int rowIndexFromMouseDown;
        private int rowIndexOfItemUnderMouseToDrop;
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
        private List<string> tempPlayerName; //保存从数据库里查出来的闲家名字，用来检查新添加的闲家重名

        public Play(string dealerName, double betMoney, int dealerID)
        {
            this.dealerName = dealerName;
            this.dealerID = dealerID;
            this.betMoney = betMoney;
            tempPlayerName = new List<string>();
            isNewRound = false;
            db = DBSession.GetDbContext();
            InitializeComponent();
            Init(dealerName, betMoney, gameID, dealerID);
            InitRound(); //开局的时候就初始化一轮
            LoadAllPlayer();
        }

        //开庄时初始化数据
        private void Init(string dealerName, double betMoney, int gameID, int dealerID)
        {
            txtBetMoney.Text = betMoney.ToString(); //显示开庄金额
            txtDealer.Text = dealerName; //显示庄家名称
            int gameOrder = 1; //保存局数
            var game = db.Game.OrderByDescending(g => g.GameID).FirstOrDefault();
            if (game != null)
            {
                gameOrder = game.GameOrder + 1; //查出最近一局的局数
            }
            Game model = new Game()
            {
                GameOrder = gameOrder,
                BetMoney = betMoney, //开庄金额，这里是没抽成前的金额
                PlayerID = dealerID,
                PlayTime = DateTime.Now,
                Year = DateTime.Now.Year,
                Month = DateTime.Now.Month,
                Day = DateTime.Now.Day
            };
            db.Game.Add(model);
            db.SaveChanges();
            this.betMoney = betMoney * 0.98; //抽成后开庄金额
            this.gameID = model.GameID;
            this.gameOrder = game.GameOrder;
            dealerBalance = this.betMoney; //一开始庄家的结余等于抽成后开庄金额
            txtDealerBalance.Text = dealerBalance.ToString();
            FinanceInfo finfo = new FinanceInfo()
            {
                Money = -betMoney*0.02, //抽成后写入财务表
                LogTime = DateTime.Now,
                PlayerID = dealerID,
                GameID = model.GameID, //当前局
                RoundID = -1//表示开庄抽成
            };
            db.FinanceInfo.Add(finfo);
            db.SaveChanges();

        }

        //刷新表格
        public async void ReLoadTable()
        {
            lotteryView.Rows.Clear();
            var detaiList = await db.PlayDetail.Where(d => d.RoundID == currentRoundId).OrderByDescending(d => d.Balance).ToListAsync();

            //db = new LotteryDbContext();
            foreach (var detail in detaiList)
            {
                if (detail.PlayerID == dealerID) //如果是庄家
                {
                    continue;
                }
                int index = lotteryView.Rows.Add();
                var lastDetail = await db.PlayDetail.SingleOrDefaultAsync(p => p.PlayerID == detail.PlayerID && p.Round.GameID == gameID && p.Round.RoundOrder == lastRoundOrder);
                if (detail != null) //本盘数据
                {
                    lotteryView.Rows[index].Cells["PlayerID"].Value = detail.PlayerID;
                    lotteryView.Rows[index].Cells["Player"].Value = detail.Player.Name;
                    lotteryView.Rows[index].Cells["LastSurplus"].Value = lastDetail == null ? 0 : lastDetail.Balance;
                    lotteryView.Rows[index].Cells["Surplus"].Value = detail.Balance;
                    lotteryView.Rows[index].Cells["PlayDetailID"].Value = detail.PlayDetailID;
                    lotteryView.Rows[index].Cells["Money"].Value = detail.BetMoney;
                    lotteryView.Rows[index].Cells["Multiple"].Value = detail.FinalMultiple;
                    lotteryView.Rows[index].Cells["OriginNumber"].Value = detail.OriginNumber;
                    lotteryView.Rows[index].Cells["PlayerProfit"].Value = detail.Profit;
                    lotteryView.Rows[index].Cells["DealerProfit"].Value = -detail.Profit;
                }
            }
        }

        //加载窗体时，把所有闲家加载进datagridview
        private async void LoadAllPlayer()
        {
            var list = await db.Player.Where(p => p.IsDel == false).ToListAsync();
            foreach (var player in list)
            {
                if (player.PlayerID == dealerID)
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
            Round round = new Round() { GameID = gameID, RoundOrder = currentRoundOrder, PlayTime = DateTime.Now, DealerID = dealerID };
            var model = db.Round.Add(round);
            db.SaveChanges();
            currentRoundId = model.RoundID;
            isNewRound = true; //表示新的一轮
            lbTime.Text = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString();
        }
       
        private void btnCal_Click(object sender, EventArgs e)
        {
            Calculate();
        }
        //开始计算
        private async void Calculate()
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
            txtDealerMultiple.Text = dealerPoint.ToString();
            PlayDetail detail = null;
            int playerBetMoney = 0; //闲家投注
            double dealerProfit = 0; //庄家本轮盈亏
            List<PlayInfo> WinPlayInfo = new List<PlayInfo>(); //保存赢了的闲家信息
            List<PlayInfo> LostPlayInfo = new List<PlayInfo>(); //保存输了的闲家信息
            foreach (DataGridViewRow row in lotteryView.Rows)
            {
                if (row.Cells["Money"].Value == null)
                {
                    row.Cells["Money"].Value = 0;
                    playerBetMoney = 0;
                }
                else
                {
                    if (!int.TryParse(row.Cells["Money"].Value.ToString(), out playerBetMoney))
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
                double lastBalance = 0; //上把闲家结余
                double balance = 0; //本把闲家结余
                int playerId = -1;
                #region 添加新闲家
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
                #endregion
                var financeInfoList = db.FinanceInfo.Where(f => f.PlayerID == playerId && f.GameID==gameID); //查出本局玩家的钱
                if (financeInfoList.Count()>0)
                {
                    lastBalance = financeInfoList.Sum(f => f.Money);
                }
                else
                {
                    lastBalance = 0;
                }

                detail = new PlayDetail();
                detail.PlayerID = playerId;
                detail.RoundID = currentRoundId; //保存本轮id
                detail.GameID = gameID; //保存本局id
                detail.BetMoney = playerBetMoney;
                detail.OriginNumber = row.Cells["OriginNumber"].Value.ToString();
                detail.Multiple = multiple;

                CompareResult result = Helper.Compare(multiple, dealerPoint);
                if (result == CompareResult.DealerWin)
                {
                    detail.FinalMultiple = -dealerPoint; //倍数变为庄家点数的负数
                    LostPlayInfo.Add(new PlayInfo() { Detail = detail, LastBalance = lastBalance });
                }
                else if (result == CompareResult.PlayerWin)
                {
                    detail.FinalMultiple = multiple;
                    WinPlayInfo.Add(new PlayInfo() { Detail = detail, LastBalance = lastBalance });
                }
                else if (result == CompareResult.Even)
                {
                    detail.FinalMultiple = multiple;
                    balance = lastBalance;
                    db.PlayDetail.Add(detail);
                }
            }
            dealerProfit = LostPlayInfo.Sum(l => l.Detail.BetMoney * Math.Abs(l.Detail.FinalMultiple));
            dealerBalance += dealerProfit; //先把输家的钱吃进去
            var dealerFinanceInfo = new FinanceInfo()
            {
                PlayerID = dealerID,
                GameID = gameID,
                LogTime = DateTime.Now,
                Money = dealerProfit, //庄家赢的钱
                RoundID=currentRoundId
            };
            db.FinanceInfo.Add(dealerFinanceInfo);
            foreach (var item in LostPlayInfo)
            {
                item.Detail.Profit = item.Detail.BetMoney * item.Detail.FinalMultiple;
                item.Detail.Balance = item.LastBalance + item.Detail.Profit;
                var playerFinanceInfo = new FinanceInfo()
                {
                    PlayerID = item.Detail.PlayerID,
                    GameID = gameID,
                    LogTime = DateTime.Now,
                    Money = item.Detail.Profit, //闲家输的钱
                    RoundID=currentRoundId
                };
                db.FinanceInfo.Add(playerFinanceInfo);
                var player = db.Player.SingleOrDefault(p => p.PlayerID == item.Detail.PlayerID);
                db.Entry(player).State = EntityState.Modified;
                db.PlayDetail.Add(item.Detail);
            }
            double dealerLoseMoney = WinPlayInfo.Sum(l => l.Detail.BetMoney * l.Detail.FinalMultiple);
            WinPlayInfo = WinPlayInfo.OrderByDescending(w => w.Detail.Multiple).ThenByDescending(w => int.Parse(w.Detail.OriginNumber)).ThenByDescending(w => w.Detail.BetMoney).ToList();
            foreach (var item in WinPlayInfo)
            {
                item.Detail.Profit = item.Detail.BetMoney * item.Detail.FinalMultiple;
                double remianing = dealerBalance - item.Detail.Profit;
                if (remianing >= 0) //如果钱还够赔
                {
                    item.Detail.Balance = item.LastBalance + item.Detail.Profit;
                    var player = db.Player.SingleOrDefault(p => p.PlayerID == item.Detail.PlayerID);
                    var playerFinanceInfo = new FinanceInfo()
                    {
                        PlayerID = item.Detail.PlayerID,
                        GameID = gameID,
                        LogTime = DateTime.Now,
                        Money = item.Detail.Profit, //闲家赢的钱
                        RoundID=currentRoundId
                    };
                    var dealerFinanceInfo2 = new FinanceInfo()
                    {
                        PlayerID = dealerID,
                        GameID = gameID,
                        LogTime = DateTime.Now,
                        Money = -item.Detail.Profit, //闲家输的钱
                        RoundID=currentRoundId
                    };
                    db.FinanceInfo.Add(playerFinanceInfo);
                    db.FinanceInfo.Add(dealerFinanceInfo2);
                    db.Entry(player).State = EntityState.Modified;
                    dealerProfit = dealerProfit - item.Detail.Profit;
                    dealerBalance = remianing;
                }
                else
                {
                    item.Detail.Balance = item.LastBalance + item.Detail.Profit - Math.Abs(remianing); //赔额出了负数，要减去这部分钱
                    var player = db.Player.SingleOrDefault(p => p.PlayerID == item.Detail.PlayerID);
                    var playerFinanceInfo = new FinanceInfo()
                    {
                        PlayerID = item.Detail.PlayerID,
                        GameID = gameID,
                        LogTime = DateTime.Now,
                        RoundID=currentRoundId,
                        Money = item.Detail.Profit - Math.Abs(remianing)//闲家赢的钱
                    };
                    var dealerFinanceInfo2 = new FinanceInfo()
                    {
                        PlayerID = dealerID,
                        GameID = gameID,
                        LogTime = DateTime.Now,
                        RoundID=currentRoundId,
                        Money = -(item.Detail.Profit - Math.Abs(remianing))//闲家输的钱
                    };
                    db.FinanceInfo.Add(playerFinanceInfo);
                    db.FinanceInfo.Add(dealerFinanceInfo2);
                    db.Entry(player).State = EntityState.Modified;
                    dealerProfit = dealerProfit - item.Detail.Profit + Math.Abs(remianing);
                    dealerBalance = 0;
                }
                db.PlayDetail.Add(item.Detail);
            }
            await db.SaveChangesAsync();
            lbRoundCount.Text = $"当前第{currentRoundOrder}轮";
            txtDealerProfit.Text = dealerProfit.ToString();
            txtDealerBalance.Text = dealerBalance.ToString();
            UpdateRoundStatus(dealerProfit);
            UpdateGameStatus(false); //更新本局状态
            ReLoadTable();
            isNewRound = false; //表示该轮已经结束  
        }

        private async void UpdateGameStatus(bool isCloseGame)
        {
            var game = await db.Game.SingleOrDefaultAsync(g => g.GameID == gameID);
            if (game != null)
            {
                if (isCloseGame) //如果是换庄
                {
                    game.Balance = dealerBalance * 0.97; //庄家结余要扣除掉下庄抽成
                    game.EndTime = DateTime.Now;
                    FinanceInfo finfo = new FinanceInfo()
                    {
                        Money = -dealerBalance * 0.03,
                        LogTime = DateTime.Now,
                        PlayerID = dealerID,
                        GameID = gameID,
                        RoundID = -3//表示下庄抽成
                    };
                    db.FinanceInfo.Add(finfo);
                }
                else
                {
                    game.Balance = dealerBalance;
                }
                db.Entry(game).State = EntityState.Modified;
                await db.SaveChangesAsync();
            }       
            
        }

        private async void UpdateRoundStatus(double dealerProfit)
        {
            var round = await db.Round.SingleOrDefaultAsync(r => r.RoundID == currentRoundId);
            round.DealerProfit = dealerProfit;
            round.DealerBalance = dealerBalance;
            round.OriginNumber = txtDealerPoint.Text;
            round.Multiple = dealerPoint;
            db.Entry(round).State = EntityState.Modified;
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
            txtDealerMultiple.Text = string.Empty;
            isNewRound = true;
            lotteryView.Rows.Clear();
            InitRound();
            LoadAllPlayer(); //重新加载表格
        }

        //返回开庄
        private void btnChangeDealer_Click(object sender, EventArgs e)
        {
            UpdateGameStatus(true); //换庄时更新本局状态
            new Result(gameID).ShowDialog();
            Close();
        }

        private void btnAddDealMoney_Click(object sender, EventArgs e)
        {
            double temp = 0;
            if (!double.TryParse(txtAddDeal.Text, out temp))
            {
                MessageBox.Show("请输入正确的追庄金额");
                return;
            }
            txtBetMoney.Text = (betMoney+temp).ToString(); //加上没抽成前的金额
            var game = db.Game.SingleOrDefault(g => g.GameID == gameID);
            game.BetMoney = betMoney+temp; //没抽成前的金额
            betMoney += temp * 0.98; //追加开庄金额，要抽成
            dealerBalance += temp * 0.98; //追加庄家结余  
            game.Balance = dealerBalance;
            db.Entry(game).State = EntityState.Modified;
            db.SaveChanges();
                                 
            FinanceInfo finfo = new FinanceInfo()
            {
                Money = -temp * 0.02,
                LogTime = DateTime.Now,
                PlayerID = dealerID,
                GameID = game.GameID,
                RoundID = -2//表示追庄抽成
            };
            db.FinanceInfo.Add(finfo);
            db.SaveChanges();
            
            txtDealerBalance.Text = dealerBalance.ToString();
            txtAddDeal.Clear();
        }

        private void lotteryView_DragDrop(object sender, DragEventArgs e)
        {
            // The mouse locations are relative to the screen, so they must be 
            // converted to client coordinates.
            Point clientPoint = lotteryView.PointToClient(new Point(e.X, e.Y));

            // Get the row index of the item the mouse is below. 
            rowIndexOfItemUnderMouseToDrop =
                lotteryView.HitTest(clientPoint.X, clientPoint.Y).RowIndex;

            // If the drag operation was a move then remove and insert the row.
            if (e.Effect == DragDropEffects.Move)
            {
                DataGridViewRow rowToMove = e.Data.GetData(
                    typeof(DataGridViewRow)) as DataGridViewRow;
                lotteryView.Rows.RemoveAt(rowIndexFromMouseDown);
                lotteryView.Rows.Insert(rowIndexOfItemUnderMouseToDrop, rowToMove);

            }
        }

        private void lotteryView_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void lotteryView_MouseDown(object sender, MouseEventArgs e)
        {
            // Get the index of the item the mouse is below.
            rowIndexFromMouseDown = lotteryView.HitTest(e.X, e.Y).RowIndex;
            if (rowIndexFromMouseDown != -1)
            {
                // Remember the point where the mouse down occurred. 
                // The DragSize indicates the size that the mouse can move 
                // before a drag event should be started.                
                Size dragSize = SystemInformation.DragSize;

                // Create a rectangle using the DragSize, with the mouse position being
                // at the center of the rectangle.
                dragBoxFromMouseDown = new Rectangle(new Point(e.X - (dragSize.Width / 2),
                                                               e.Y - (dragSize.Height / 2)),
                                    dragSize);
            }
            else
                // Reset the rectangle if the mouse is not over an item in the ListBox.
                dragBoxFromMouseDown = Rectangle.Empty;
        }

        private void lotteryView_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                // If the mouse moves outside the rectangle, start the drag.
                if (dragBoxFromMouseDown != Rectangle.Empty &&
                    !dragBoxFromMouseDown.Contains(e.X, e.Y))
                {

                    // Proceed with the drag and drop, passing in the list item.                    
                    DragDropEffects dropEffect = lotteryView.DoDragDrop(
                    lotteryView.Rows[rowIndexFromMouseDown],
                    DragDropEffects.Move);
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var detailList = db.PlayDetail.Where(r => r.RoundID == currentRoundId);
            if (detailList.Count()<=0)
            {
                MessageBox.Show("本轮已经不能修改");
            }
            db.PlayDetail.RemoveRange(detailList);
            var financeInfoList = db.FinanceInfo.Where(r => r.RoundID == currentRoundId);
            db.FinanceInfo.RemoveRange(financeInfoList);
            var lastRound = db.Round.SingleOrDefault(r => r.RoundID == lastRoundId);
            if (lastRound==null)
            {
                dealerBalance = betMoney;
            }
            else
            {
                dealerBalance = lastRound.DealerBalance; //还原庄家结余
            }
            var game = db.Game.SingleOrDefault(g => g.GameID == gameID);
            game.Fee = dealerBalance * 0.02;
            db.Entry(game).State = EntityState.Modified;
            db.SaveChanges(); //先把本轮结果删掉
            isNewRound = true;
            Calculate();
        }
    }
}
