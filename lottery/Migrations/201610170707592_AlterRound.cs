namespace lottery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterRound : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rounds", "DealerBalance", c => c.Double(nullable: false));
            DropColumn("dbo.Rounds", "TotalMoney");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rounds", "TotalMoney", c => c.Double(nullable: false));
            DropColumn("dbo.Rounds", "DealerBalance");
        }
    }
}
