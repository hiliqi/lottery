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
        public int RoundOrder { get; set; } //盘数
        public DateTime PlayTime { get; set; }
        public int GameID { get; set; }
        public virtual Game Game { get; set; }
        public virtual ICollection<PlayDetail> PlayDetails { get; set; }
    }
}
