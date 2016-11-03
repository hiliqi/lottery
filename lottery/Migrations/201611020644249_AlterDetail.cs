namespace lottery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterDetail : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PlayDetails", "GameID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PlayDetails", "GameID");
        }
    }
}
