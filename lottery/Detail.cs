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
    public partial class Detail : Form
    {
        private LotteryDbContext db;
        public Detail(int playerId, int gameId)
        {
            db = DBSession.GetDbContext();
            InitializeComponent();
            Init(playerId,gameId);
        }

        private async void Init(int playerId, int gameId)
        {
            lbName.Text = (await db.Player.SingleOrDefaultAsync(p => p.PlayerID == playerId)).Name;
            var list = await db.PlayDetail.Where(p => p.PlayerID == playerId && p.Round.GameID==gameId).Include(p=>p.Round).ToListAsync();
            foreach (var item in list)
            {
                int index = detailView.Rows.Add();
                detailView.Rows[index].Cells["BetMoney"].Value = item.BetMoney;
                detailView.Rows[index].Cells["Multiple"].Value = item.Multiple;
                int roundId = item.RoundID;
                var dealerDetail = db.PlayDetail.SingleOrDefault(p => p.RoundID == roundId);
                detailView.Rows[index].Cells["DealerPoint"].Value = dealerDetail.Multiple;
                detailView.Rows[index].Cells["Profit"].Value = item.Profit;
                detailView.Rows[index].Cells["Balance"].Value = item.Balance;
                detailView.Rows[index].Cells["RoundOrder"].Value = item.Round.RoundOrder;
            }
        }
    }
}
