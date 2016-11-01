namespace lottery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterGame1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Games", "PlayDate", c => c.DateTime(nullable: false, storeType: "date"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Games", "PlayDate");
        }
    }
}
