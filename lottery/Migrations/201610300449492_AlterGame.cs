namespace lottery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterGame : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Games", "PlayTime", c => c.DateTime(nullable: false, precision: 0));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Games", "PlayTime");
        }
    }
}
