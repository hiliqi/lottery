using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lottery
{
    public static class Helper
    {
        private static LotteryDbContext db = new LotteryDbContext();
        //判断是否存在同名的玩家，type表示玩家类型
        public static bool ExistUser(string name)
        {
            return db.Player.Any(p => string.Equals(p.Name, name));
        }
    }
}
