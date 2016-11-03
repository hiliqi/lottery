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
    public partial class Report : Form
    {
        private readonly LotteryDbContext db;
        public Report()
        {
            db = DBSession.GetDbContext();
            InitializeComponent();
        }

        private void LoadView(DateTime time)
        {
            resultView.Rows.Clear();
            int playerID = 0;
            if(!int.TryParse(cmbPlayer.SelectedValue.ToString(), out playerID))
            {
                MessageBox.Show("请选择玩家");
                return;
            }
            if (playerID==-1)
            {
                MessageBox.Show("请选择玩家");
                return;
            }
            var gamelist = db.Game.Where(
                g => g.Year == time.Year &&
                    g.Month == time.Month &&
                    g.Day == time.Day 
                );
            //gamelist = from g in gamelist
            //           where g.Rounds.Any(r=>r.any
            //           ))
                            
            var player = db.Player.SingleOrDefault(p => p.PlayerID == playerID);
            var last = db.PlayDetail.Include(p => p.Round.Game).Where(
                p => p.PlayerID == player.PlayerID &&
                    p.Round.Game.Year == time.Year &&
                    p.Round.Game.Month == time.Month &&
                    p.Round.Game.Day == time.Day
                ).OrderByDescending(p => p.RoundID).FirstOrDefault();

            foreach (var item in gamelist)
            {
                int index= resultView.Rows.Add();
                resultView.Rows[index].Cells["GameID"].Value = item.GameID;
                resultView.Rows[index].Cells["GameOrder"].Value = item.GameOrder;
                resultView.Rows[index].Cells["Dealer"].Value = item.Player.Name;
                resultView.Rows[index].Cells["BetMoney"].Value = item.BetMoney;
                resultView.Rows[index].Cells["DealerBalance"].Value = item.Balance;
                resultView.Rows[index].Cells["Fee"].Value = item.Fee;
                resultView.Rows[index].Cells["PlayTime"].Value = item.PlayTime;
                resultView.Rows[index].Cells["EndTime"].Value = item.EndTime;
            }
        }

        private void btnReloadView_Click(object sender, EventArgs e)
        {
            var date = DateTime.Parse(dateTimePicker1.Text);
            LoadView(date);
        }
    }
}
