namespace lottery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterDealerPlayer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Dealers", "IsDel", c => c.Boolean(nullable: false));
            AddColumn("dbo.Players", "IsDel", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Players", "IsDel");
            DropColumn("dbo.Dealers", "IsDel");
        }
    }
}
