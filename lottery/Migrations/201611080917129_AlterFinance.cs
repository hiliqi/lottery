namespace lottery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterFinance : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FinanceInfoes", "RoundID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.FinanceInfoes", "RoundID");
        }
    }
}
