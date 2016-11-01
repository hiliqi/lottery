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
            DataGridView.CheckForIllegalCrossThreadCalls = false;
            new Thread(() => LoadView(DateTime.Now)).Start();
        }

        private void LoadView(DateTime time)
        {
            lbMsg.Text = "正在加载报表";
            resultView.Rows.Clear();
            var list = db.Game.Include(g => g.Player).Where(
                    g => g.Year == time.Year &&
                        g.Month == time.Month &&
                        g.Day == time.Day
                ).ToList();
            foreach (var item in list)
            {
                int index= resultView.Rows.Add();
                resultView.Rows[index].Cells["GameID"].Value = item.GameID;
                resultView.Rows[index].Cells["GameOrder"].Value = item.GameOrder;
                resultView.Rows[index].Cells["Dealer"].Value = item.Player.Name;
                resultView.Rows[index].Cells["BetMoney"].Value = item.BetMoney;
                resultView.Rows[index].Cells["Balance"].Value = item.Balance;
                resultView.Rows[index].Cells["Fee"].Value = item.Fee;
                resultView.Rows[index].Cells["PlayTime"].Value = item.PlayTime;
            }
            lbMsg.Text = "报表加载完成";
        }

        private void btnReloadView_Click(object sender, EventArgs e)
        {
            var date = DateTime.Parse(dateTimePicker1.Text);
            LoadView(date);
        }
    }
}
