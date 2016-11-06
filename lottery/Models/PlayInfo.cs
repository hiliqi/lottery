using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lottery
{
    public class PlayInfo
    {
        public PlayDetail Detail { get; set; }
        public double LastBalance { get; set; }
    }


    public enum CompareResult
    {
        DealerWin, PlayerWin, Even
    }
}
