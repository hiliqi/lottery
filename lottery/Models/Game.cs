using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lottery
{
    public class Game
    {
        [Key]
        public int GameID { get; set; }      
        public int GameOrder { get; set; }//局数       
        public double BetMoney { get; set; }//开庄金额  
        public double Balance { get; set; } //结算金额     
        public double FeePercent { get; set; } //本局平台抽成比例
        public double Fee { get; set; }
        public DateTime PlayTime { get; set; } //开庄时间
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
        public DateTime EndTime { get; set; } //下庄时间
        public int PlayerID { get; set; }
        public virtual Player Player { get; set; }
        public virtual ICollection<Round> Rounds { get; set; }
    }
}
