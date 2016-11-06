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
        public double BetMoney { get; set; }//投注金额       
        public double Balance { get; set; }//结余金额   
        public string OriginNumber { get; set; } //红包点数  
        public int Multiple { get; set; }//盈亏倍数
        public int FinalMultiple { get; set; } //最终盈亏倍数
        public double Profit { get; set; } //实际盈亏
        public int RoundID { get; set; }
        public int GameID { get; set; }
        public virtual Round Round { get; set; }
    }

    public enum PlayerType
    {
        Dealer,Player
    }
}
