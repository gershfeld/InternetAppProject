namespace secondHandPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedLocation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Notices", "Location", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Notices", "Location");
        }
    }
}
