namespace lottery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFinance : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FinanceInfoes",
                c => new
                    {
                        FinanceInfoID = c.Int(nullable: false, identity: true),
                        Money = c.Double(nullable: false),
                        LogTime = c.DateTime(nullable: false, precision: 0),
                        PlayerID = c.Int(nullable: false),
                        GameID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FinanceInfoID)
                .ForeignKey("dbo.Players", t => t.PlayerID, cascadeDelete: true)
                .Index(t => t.PlayerID);
            
            DropColumn("dbo.Players", "Money");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Players", "Money", c => c.Double(nullable: false));
            DropForeignKey("dbo.FinanceInfoes", "PlayerID", "dbo.Players");
            DropIndex("dbo.FinanceInfoes", new[] { "PlayerID" });
            DropTable("dbo.FinanceInfoes");
        }
    }
}
