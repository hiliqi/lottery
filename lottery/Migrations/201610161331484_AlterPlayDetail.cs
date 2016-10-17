namespace lottery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterPlayDetail : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PlayDetails", "RoundOrder", c => c.Int(nullable: false));
            DropColumn("dbo.PlayDetails", "RoundID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PlayDetails", "RoundID", c => c.Int(nullable: false));
            DropColumn("dbo.PlayDetails", "RoundOrder");
        }
    }
}
