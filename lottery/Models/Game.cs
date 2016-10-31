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
        public double Balance { get; set; } //结算金额     
        public double FeePercent { get; set; } //本局平台抽成比例
        public double Fee { get; set; }
        public DateTime PlayTime { get; set; }
        public int PlayerID { get; set; }
        public virtual Player Player { get; set; }
    }
}
