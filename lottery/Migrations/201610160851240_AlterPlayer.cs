namespace lottery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterPlayer : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Players", "Money");
            DropColumn("dbo.Players", "Multiple");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Players", "Multiple", c => c.Int(nullable: false));
            AddColumn("dbo.Players", "Money", c => c.Double(nullable: false));
        }
    }
}
