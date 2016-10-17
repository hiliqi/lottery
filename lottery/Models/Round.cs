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

        //盘数
        public int RoundOrder { get; set; }

        //本局合计
        public double TotalMoney { get; set; }

        public int GameID { get; set; }
        public Game Game { get; set; }
    }
}
