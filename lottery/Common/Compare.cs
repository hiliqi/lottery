using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lottery
{
    public class Compare : IEqualityComparer<PlayInfo>
    {
        public bool Equals(PlayInfo x, PlayInfo y)
        {
            return x.Detail.OriginNumber == y.Detail.OriginNumber;
        }

        public int GetHashCode(PlayInfo obj)
        {
            return obj.Detail.OriginNumber.GetHashCode();
        }
    }
}
