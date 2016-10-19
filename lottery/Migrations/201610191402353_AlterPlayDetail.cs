namespace lottery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterPlayDetail : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PlayDetails", "FinalMultiple", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PlayDetails", "FinalMultiple");
        }
    }
}
