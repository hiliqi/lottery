namespace lottery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterGame2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Games", "Year", c => c.Int(nullable: false));
            AddColumn("dbo.Games", "Month", c => c.Int(nullable: false));
            AddColumn("dbo.Games", "Day", c => c.Int(nullable: false));
            DropColumn("dbo.Games", "PlayDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Games", "PlayDate", c => c.DateTime(nullable: false, storeType: "date"));
            DropColumn("dbo.Games", "Day");
            DropColumn("dbo.Games", "Month");
            DropColumn("dbo.Games", "Year");
        }
    }
}
