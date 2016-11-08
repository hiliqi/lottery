namespace lottery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterPlayer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Players", "Money", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Players", "Money");
        }
    }
}
