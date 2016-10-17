namespace lottery
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class LotteryDbContext : DbContext
    {
        //您的上下文已配置为从您的应用程序的配置文件(App.config 或 Web.config)
        //使用“LotteryDbContext”连接字符串。默认情况下，此连接字符串针对您的 LocalDb 实例上的
        //“lottery.LotteryDbContext”数据库。
        // 
        //如果您想要针对其他数据库和/或数据库提供程序，请在应用程序配置文件中修改“LotteryDbContext”
        //连接字符串。
        public LotteryDbContext()
            : base(nameOrConnectionString: "LotteryDbContext")
        {
        }

        //为您要在模型中包含的每种实体类型都添加 DbSet。有关配置和使用 Code First  模型
        //的详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=390109。

         public virtual DbSet<Player> Player { get; set; }
        public virtual DbSet<Dealer> Dealer { get; set; }
        public virtual DbSet<Round> Round { get; set; }
        public virtual DbSet<Game> Game { get; set; }
        public virtual DbSet<PlayDetail> PlayDetail { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    Database.SetInitializer<LotteryDbContext>(new CreateDatabaseIfNotExists<LotteryDbContext>());

        //    base.OnModelCreating(modelBuilder);
        //}

    }
}