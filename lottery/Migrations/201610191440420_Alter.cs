namespace lottery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Alter : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Games", "FeePercent", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Games", "FeePercent", c => c.Int(nullable: false));
        }
    }
}
