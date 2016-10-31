namespace lottery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterRound : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rounds", "DealerPoint", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Rounds", "DealerPoint");
        }
    }
}
