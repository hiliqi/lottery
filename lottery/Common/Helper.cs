using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        //凭借输入的钱，计算点数
        public static int CalPoint(string origin)
        {
            if (origin.Length != 3)
            {
                return -1;
            }
            int first; //小数点前一位
            int second; //小数点后一位
            int third; //小数点后二位
            bool b = true;
            b = int.TryParse(origin[0].ToString(), out first);
            b = int.TryParse(origin[1].ToString(), out second);
            b = int.TryParse(origin[2].ToString(), out third);
            if (!b)
            {
                return -1;
            }
            if (first==0&&second==0&&third==1)
            {
                return 0;
            }
            if ((first == 0 || first == 1) && second == 1 && third == 0)
            {
                return 11;
            }
            if (first == second && second == third && first == third)//豹子
            {
                return 15;
            }
            if (second == third)//对子
            {
                return 12;
            }
            if (first > 0 && second - first == 1 && third - second == 1) //顺子
            {
                return 13;
            }
            int result = second + third;
            if (result % 10 == 0)//牛牛
            {
                return 10;
            }
            return result % 10;
        }

        //闲家和庄家比，如果闲家点数大，则为true
        public static CompareResult Compare(int multiple,int dealerPoint)
        {
            if (multiple == 0 || dealerPoint == 0)
            {
                return CompareResult.Even;
            }
            if (multiple==dealerPoint)
            {
                if (multiple <= 4)
                {
                    return CompareResult.DealerWin;
                }
                else
                {
                    return CompareResult.Even;
                }
            }else if (multiple>dealerPoint)
            {
                return CompareResult.PlayerWin;
            }
            else
            {
                return CompareResult.DealerWin;
            }
        }

    }
}
