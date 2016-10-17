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
        //局数
        public int GameOrder { get; set; }

        //开庄金额
        public double BetMoney { get; set; }

        //庄家盈亏
        public double Profit { get; set; }

        public int DealerID { get; set; }

        public Dealer Dealer { get; set; }
    }
}
