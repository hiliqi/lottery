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
        private LotteryDbContext db = new LotteryDbContext();
        private int gameId;
        public Result(int gameId)
        {
            this.gameId = gameId;
            InitializeComponent();
            lbGameOrder.Text = $"这是第{gameId}局的结果";
            InitView();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void InitView()
        {
            var game = await db.Game.SingleOrDefaultAsync(g => g.GameID == gameId);
            lbDealerName.Text = lbDealerName.Text + game.Dealer.Name;
            lbBetMoney.Text = lbBetMoney.Text + game.BetMoney.ToString();
            lbFee.Text = lbFee.Text + (game.FeePercent * game.BetMoney).ToString();
            var list = await db.PlayDetail.Where(p=>p.Round.GameID== gameId).ToListAsync(); //查出当前轮的所有情况
            var distinctPlayer = list.Select(l => l.PlayerID).Distinct();
            IEnumerable<PlayDetail> finalList = null;
            foreach (var id in distinctPlayer)
            {
                finalList = list.Where(l => l.PlayerID == id);
                int index = resultView.Rows.Add();
                resultView.Rows[index].Cells["PlayerID"].Value = id;
                resultView.Rows[index].Cells["PlayerName"].Value = finalList.First().Player.Name;
                resultView.Rows[index].Cells["TotalBetMoney"].Value = finalList.Sum(l => l.BetMoney);
                resultView.Rows[index].Cells["Profit"].Value = finalList.OrderByDescending(f => f.PlayDetailID).First().Balance;
                resultView.Rows[index].Cells["PlayRounds"].Value = finalList.Select(l => l.RoundID).Count();
            }
        }
    }
}
