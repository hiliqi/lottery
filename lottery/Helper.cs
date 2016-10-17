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
        public static bool ExistUser(string name,int type)
        {
            bool b = false;
            if (type==0)//表示查询庄家
            {
                var model = db.Dealer.SingleOrDefault(d => d.Name == name);
                b = db.Dealer.Any(d => string.Equals(d.Name, name));
            }
            else
            {
                b = db.Player.Any(p => string.Equals(p.Name,name));
            }
            return b;
        }
    }
}
