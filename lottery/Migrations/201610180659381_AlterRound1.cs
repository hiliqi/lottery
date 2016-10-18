namespace lottery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterRound1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rounds", "TotalMoney", c => c.Double(nullable: false));
            AddColumn("dbo.Rounds", "DealerProfit", c => c.Double(nullable: false));
            DropColumn("dbo.Rounds", "TotalProfit");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rounds", "TotalProfit", c => c.Double(nullable: false));
            DropColumn("dbo.Rounds", "DealerProfit");
            DropColumn("dbo.Rounds", "TotalMoney");
        }
    }
}
