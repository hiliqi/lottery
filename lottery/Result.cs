﻿using System;
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
            db = new LotteryDbContext();
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
                lbErrorMsg.Text = "出错了！请重新开局";
                return;
            }
            var rounds = db.Round.Where(r => r.GameID == gameId); //本局所有轮
            var lastRound = await rounds.OrderByDescending(r => r.RoundID).FirstOrDefaultAsync(); //查出最后一轮
            if (lastRound == null)
            {
                lbErrorMsg.Text = "出错了！本局还没玩过一轮";
                return;
            }
            lbDealerBalance.Text = lbDealerBalance.Text + lastRound.DealerBalance.ToString(); //庄家结余
            lbDealerName.Text = lbDealerName.Text + game.Player.Name; //庄家名称
            lbBetMoney.Text = lbBetMoney.Text + game.BetMoney.ToString(); //开庄金额
            lbFee.Text = lbFee.Text + game.Fee; //结算金额
            var list = await db.PlayDetail.Where(p => p.Round.GameID == gameId).ToListAsync(); //查出当前局的所有情况
            var distinctPlayer = list.Select(l => l.PlayerID).Distinct();
            IEnumerable<PlayDetail> finalList = null;
            foreach (var id in distinctPlayer)
            {
                finalList = list.Where(l => l.PlayerID == id);
                int index = resultView.Rows.Add();
                resultView.Rows[index].Cells["PlayerID"].Value = id;
                resultView.Rows[index].Cells["PlayerName"].Value = finalList.First().Player.Name;
                resultView.Rows[index].Cells["Profit"].Value = finalList.OrderByDescending(f => f.PlayDetailID).First().Balance;
                //resultView.Rows[index].Cells["PlayRounds"].Value = finalList.Select(l => l.RoundID).Count();
            }
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
