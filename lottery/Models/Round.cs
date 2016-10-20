using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lottery
{
    public class Round
    {
        public int RoundID { get; set; }
        public int RoundOrder { get; set; } //盘数
        public double DealerBalance { get; set; } //庄家结余
        public double TotalMoney { get; set; } //总账面
        public double DealerProfit { get; set; } //庄家盈亏
        public double TotalBetMoney { get; set; } //总投注额
        public double Fee { get; set; } //每轮抽成
        public int GameID { get; set; }
        public virtual Game Game { get; set; }
    }
}
