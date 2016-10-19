using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lottery
{
    public class Game
    {
        public int GameID { get; set; }      
        public int GameOrder { get; set; }//局数       
        public double BetMoney { get; set; }//开庄金额       
        public double Profit { get; set; }//庄家盈亏
        public double FeePercent { get; set; } //本局平台抽成比例
        public int DealerID { get; set; }
        public virtual Dealer Dealer { get; set; }
    }
}
