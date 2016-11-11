namespace lottery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterRound : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rounds", "Multiple", c => c.Double(nullable: false));
            AddColumn("dbo.Rounds", "OriginNumber", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Rounds", "OriginNumber");
            DropColumn("dbo.Rounds", "Multiple");
        }
    }
}
