namespace secondHandPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class idkanymored2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Notices", "Check", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Notices", "Check");
        }
    }
}
