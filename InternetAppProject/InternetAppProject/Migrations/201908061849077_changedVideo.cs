namespace secondHandPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedVideo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Videos", "fileName", c => c.String());
            DropColumn("dbo.Videos", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Videos", "Name", c => c.String());
            DropColumn("dbo.Videos", "fileName");
        }
    }
}
