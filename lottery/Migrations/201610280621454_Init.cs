namespace lottery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Games",
                c => new
                    {
                        GameID = c.Int(nullable: false, identity: true),
                        GameOrder = c.Int(nullable: false),
                        BetMoney = c.Double(nullable: false),
                        Balance = c.Double(nullable: false),
                        FeePercent = c.Double(nullable: false),
                        Fee = c.Double(nullable: false),
                        PlayerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GameID)
                .ForeignKey("dbo.Players", t => t.PlayerID, cascadeDelete: true)
                .Index(t => t.PlayerID);
            
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        PlayerID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50, unicode: false),
                        IsDel = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PlayerID);
            
            CreateTable(
                "dbo.PlayDetails",
                c => new
                    {
                        PlayDetailID = c.Int(nullable: false, identity: true),
                        PlayerID = c.Int(nullable: false),
                        BetMoney = c.Double(nullable: false),
                        Balance = c.Double(nullable: false),
                        Multiple = c.Int(nullable: false),
                        FinalMultiple = c.Int(nullable: false),
                        Profit = c.Double(nullable: false),
                        RoundID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PlayDetailID)
                .ForeignKey("dbo.Players", t => t.PlayerID, cascadeDelete: true)
                .ForeignKey("dbo.Rounds", t => t.RoundID, cascadeDelete: true)
                .Index(t => t.PlayerID)
                .Index(t => t.RoundID);
            
            CreateTable(
                "dbo.Rounds",
                c => new
                    {
                        RoundID = c.Int(nullable: false, identity: true),
                        RoundOrder = c.Int(nullable: false),
                        DealerBalance = c.Double(nullable: false),
                        TotalMoney = c.Double(nullable: false),
                        DealerProfit = c.Double(nullable: false),
                        TotalBetMoney = c.Double(nullable: false),
                        IsAddMoney = c.Boolean(nullable: false),
                        GameID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RoundID)
                .ForeignKey("dbo.Games", t => t.GameID, cascadeDelete: true)
                .Index(t => t.GameID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PlayDetails", "RoundID", "dbo.Rounds");
            DropForeignKey("dbo.Rounds", "GameID", "dbo.Games");
            DropForeignKey("dbo.PlayDetails", "PlayerID", "dbo.Players");
            DropForeignKey("dbo.Games", "PlayerID", "dbo.Players");
            DropIndex("dbo.Rounds", new[] { "GameID" });
            DropIndex("dbo.PlayDetails", new[] { "RoundID" });
            DropIndex("dbo.PlayDetails", new[] { "PlayerID" });
            DropIndex("dbo.Games", new[] { "PlayerID" });
            DropTable("dbo.Rounds");
            DropTable("dbo.PlayDetails");
            DropTable("dbo.Players");
            DropTable("dbo.Games");
        }
    }
}
