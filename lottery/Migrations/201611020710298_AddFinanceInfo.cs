namespace lottery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFinanceInfo : DbMigration
    {
        public override void Up()
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
        }
        
        public override void Down()
        {
            DropTable("dbo.FinanceInfoes");
        }
    }
}
