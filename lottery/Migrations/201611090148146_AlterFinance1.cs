namespace lottery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterFinance1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FinanceInfoes", "IsClosed", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.FinanceInfoes", "IsClosed");
        }
    }
}
