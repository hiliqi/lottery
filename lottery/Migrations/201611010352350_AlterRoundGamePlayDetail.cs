namespace lottery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterRoundGamePlayDetail : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Games", "EndTime", c => c.DateTime(nullable: false, precision: 0));
            AddColumn("dbo.PlayDetails", "OriginNumber", c => c.String(unicode: false));
            AddColumn("dbo.Rounds", "OriginNumber", c => c.String(unicode: false));
            AddColumn("dbo.Rounds", "PlayTime", c => c.DateTime(nullable: false, precision: 0));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Rounds", "PlayTime");
            DropColumn("dbo.Rounds", "OriginNumber");
            DropColumn("dbo.PlayDetails", "OriginNumber");
            DropColumn("dbo.Games", "EndTime");
        }
    }
}
