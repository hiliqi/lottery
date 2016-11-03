namespace lottery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BigChange : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SettleInfoes",
                c => new
                    {
                        SettleInfoID = c.Int(nullable: false, identity: true),
                        PlayerID = c.Int(nullable: false),
                        SettleMoney = c.Double(nullable: false),
                        SettleTime = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.SettleInfoID);
            
            AddColumn("dbo.PlayDetails", "PlayerType", c => c.Int(nullable: false));
            DropColumn("dbo.Rounds", "DealerBalance");
            DropColumn("dbo.Rounds", "TotalMoney");
            DropColumn("dbo.Rounds", "DealerProfit");
            DropColumn("dbo.Rounds", "OriginNumber");
            DropColumn("dbo.Rounds", "DealerPoint");
            DropColumn("dbo.Rounds", "TotalBetMoney");
            DropColumn("dbo.Rounds", "IsAddMoney");
            DropTable("dbo.FinanceInfoes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.FinanceInfoes",
                c => new
                    {
                        FinanceInfoID = c.Int(nullable: false, identity: true),
                        GameID = c.Int(nullable: false),
                        PlayerID = c.Int(nullable: false),
                        Balance = c.Double(nullable: false),
                        IsClosed = c.Boolean(nullable: false),
                        PlayerType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FinanceInfoID);
            
            AddColumn("dbo.Rounds", "IsAddMoney", c => c.Boolean(nullable: false));
            AddColumn("dbo.Rounds", "TotalBetMoney", c => c.Double(nullable: false));
            AddColumn("dbo.Rounds", "DealerPoint", c => c.Int(nullable: false));
            AddColumn("dbo.Rounds", "OriginNumber", c => c.String(unicode: false));
            AddColumn("dbo.Rounds", "DealerProfit", c => c.Double(nullable: false));
            AddColumn("dbo.Rounds", "TotalMoney", c => c.Double(nullable: false));
            AddColumn("dbo.Rounds", "DealerBalance", c => c.Double(nullable: false));
            DropColumn("dbo.PlayDetails", "PlayerType");
            DropTable("dbo.SettleInfoes");
        }
    }
}
