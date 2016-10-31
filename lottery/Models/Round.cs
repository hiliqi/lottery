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
        public int DealerPoint { get; set; }//庄家点数
        public double TotalBetMoney { get; set; } //总投注额
        public bool IsAddMoney { get; set; } //是否追加
        public int GameID { get; set; }
        public virtual Game Game { get; set; }
    }
}
