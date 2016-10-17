using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lottery
{
    public class PlayDetail
    {
        public int PlayDetailID { get; set; }
        public int PlayerID { get; set; }
        public int RoundOrder { get; set; }

        //投注金额
        public double BetMoney { get; set; }

        //结余金额
        public double Balance { get; set; }

        //盈亏倍数
        public int Multiple { get; set; }
    }
}
