using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace lottery
{
    class DBSession
    {
        public static LotteryDbContext GetDbContext()
        {
            var db = CallContext.GetData("db") as LotteryDbContext;
            if (db == null)
            {
                db = new LotteryDbContext();
                CallContext.SetData("db", db);
            }
            return db;
        }
    }
}
