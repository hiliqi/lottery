namespace lottery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterGame : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Games", "FeePercent", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Games", "FeePercent");
        }
    }
}
