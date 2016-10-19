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
        public virtual Player Player { get; set; }
       // public int RoundOrder { get; set; }       
        public double BetMoney { get; set; }//投注金额       
        public double Balance { get; set; }//结余金额        
        public int Multiple { get; set; }//盈亏倍数
        public int FinalMultiple { get; set; } //最终盈亏倍数
        public int RoundID { get; set; }
        public virtual Round Round { get; set; }
    }
}
