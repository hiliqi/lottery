using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lottery
{
    //结算信息类
   public  class SettleInfo
    {
        public int SettleInfoID { get; set; }
        public int PlayerID { get; set; }
        public double SettleMoney { get; set; }
        public DateTime SettleTime { get; set; }
    }
}
