namespace lottery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterRound : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rounds", "TotalProfit", c => c.Double(nullable: false));
            AddColumn("dbo.Rounds", "TotalBetMoney", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Rounds", "TotalBetMoney");
            DropColumn("dbo.Rounds", "TotalProfit");
        }
    }
}
