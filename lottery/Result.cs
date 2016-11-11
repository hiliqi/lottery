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

namespace lottery
{
    public partial class Result : Form
    {
        private LotteryDbContext db;
        private int gameId;
        public Result(int gameId)
        {
            db = DBSession.GetDbContext();
            this.gameId = gameId;
            InitializeComponent();
            InitView();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void InitView()
        {            
            var game = await db.Game.SingleOrDefaultAsync(g => g.GameID == gameId);
            if (game == null)
            {
                MessageBox.Show("出错了！请重新开局");
                return;
            }

            lbDealerName.Text = lbDealerName.Text + game.Player.Name; //庄家名称
            lbBetMoney.Text = lbBetMoney.Text + game.BetMoney.ToString(); //开庄金额
            lbDealerBalance.Text = lbDealerBalance.Text + game.Balance.ToString(); //庄家结余
            lbDealerProfit.Text = lbDealerProfit.Text + (game.Balance - game.BetMoney).ToString(); //庄家盈利，这里必须减去开庄抽成和追庄抽成
            lbPlayTime.Text = lbPlayTime.Text + game.PlayTime.ToLongDateString() + " " + game.PlayTime.ToLongTimeString();
            lbEndTime.Text = lbEndTime.Text + game.EndTime.ToLongDateString() + " " + game.EndTime.ToLongTimeString();

            var temp = from q in db.FinanceInfo
                       where q.GameID==gameId
                       group q by q.PlayerID into g
                       select new
                       {
                           PlayerID = g.Key,
                           Money = g.Sum(x => x.Money)
                       };
            var list = await temp.ToListAsync();
            foreach (var item in list)
            {
                if (item.PlayerID!=game.PlayerID) //不显示出庄家
                {
                    int index = resultView.Rows.Add();
                    resultView.Rows[index].Cells["PlayerID"].Value = item.PlayerID;
                    resultView.Rows[index].Cells["PlayerName"].Value = (await db.Player.SingleOrDefaultAsync(p => p.PlayerID == item.PlayerID)).Name;
                    resultView.Rows[index].Cells["Balance"].Value = item.Money;
                }
                         
            }

            var financeList = db.FinanceInfo;
            var start = await financeList.Where(f => f.PlayerID == game.PlayerID && f.GameID==gameId && f.RoundID==-1).ToListAsync(); //开庄抽成
            var add = await financeList.Where(f => f.PlayerID == game.PlayerID && f.GameID==gameId && f.RoundID == -2).ToListAsync(); //追庄抽成
            var end = await financeList.Where(f => f.PlayerID == game.PlayerID && f.GameID==gameId && f.RoundID == -3).ToListAsync(); //下庄抽成
            var startMoney = start.Sum(s => s.Money);
            var addMoney = add.Sum(a => a.Money);
            var endMoney = end.Sum(e => e.Money);
           
            lbStartFee.Text = lbStartFee.Text + startMoney;
            lbAddFee.Text = lbAddFee.Text + addMoney;
            lbEndFee.Text = lbEndFee.Text + endMoney;
            lbTotalFee.Text = lbTotalFee.Text + (startMoney + addMoney + endMoney);
        }

        private void resultView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int playerID = 0;
            bool b = int.TryParse(resultView.Rows[e.RowIndex].Cells["PlayerID"].Value.ToString(), out playerID);
            if (!b)
            {
                MessageBox.Show("用户ID出错了！");
            }
            new Detail(playerID, gameId).ShowDialog();
        }
    }
}
