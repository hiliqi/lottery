namespace lottery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Dealers",
                c => new
                    {
                        DealerID = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.DealerID);
            
            CreateTable(
                "dbo.Games",
                c => new
                    {
                        GameID = c.Int(nullable: false, identity: true),
                        GameOrder = c.Int(nullable: false),
                        BetMoney = c.Double(nullable: false),
                        Profit = c.Double(nullable: false),
                        DealerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GameID)
                .ForeignKey("dbo.Dealers", t => t.DealerID, cascadeDelete: true)
                .Index(t => t.DealerID);
            
            CreateTable(
                "dbo.PlayDetails",
                c => new
                    {
                        PlayDetailID = c.Int(nullable: false, identity: true),
                        PlayerID = c.Int(nullable: false),
                        RoundID = c.Int(nullable: false),
                        BetMoney = c.Double(nullable: false),
                        Balance = c.Double(nullable: false),
                        Multiple = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PlayDetailID);
            
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        PlayerID = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                        Money = c.Double(nullable: false),
                        Multiple = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PlayerID);
            
            CreateTable(
                "dbo.Rounds",
                c => new
                    {
                        RoundID = c.Int(nullable: false, identity: true),
                        RoundOrder = c.Int(nullable: false),
                        TotalMoney = c.Double(nullable: false),
                        GameID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RoundID)
                .ForeignKey("dbo.Games", t => t.GameID, cascadeDelete: true)
                .Index(t => t.GameID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rounds", "GameID", "dbo.Games");
            DropForeignKey("dbo.Games", "DealerID", "dbo.Dealers");
            DropIndex("dbo.Rounds", new[] { "GameID" });
            DropIndex("dbo.Games", new[] { "DealerID" });
            DropTable("dbo.Rounds");
            DropTable("dbo.Players");
            DropTable("dbo.PlayDetails");
            DropTable("dbo.Games");
            DropTable("dbo.Dealers");
        }
    }
}
