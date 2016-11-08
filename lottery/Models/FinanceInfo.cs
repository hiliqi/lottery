using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lottery
{
    public class FinanceInfo
    {
        [Key]
        public int FinanceInfoID { get; set; }
        public double Money { get; set; }
        public DateTime LogTime { get; set; }
        public int PlayerID { get; set; }
        public virtual Player Player { get; set; }
        public int GameID { get; set; }
        public int RoundID { get; set; }
    }
}
