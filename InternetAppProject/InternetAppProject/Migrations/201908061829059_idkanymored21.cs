namespace secondHandPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class idkanymored21 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Notices", "Check");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Notices", "Check", c => c.Int(nullable: false));
        }
    }
}
