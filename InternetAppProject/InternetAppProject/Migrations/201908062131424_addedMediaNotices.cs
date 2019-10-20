namespace secondHandPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedMediaNotices : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Images", "Notice_ID", "dbo.Notices");
            DropIndex("dbo.Images", new[] { "Notice_ID" });
            AddColumn("dbo.Media", "Notice_ID", c => c.Int());
            CreateIndex("dbo.Media", "Notice_ID");
            AddForeignKey("dbo.Media", "Notice_ID", "dbo.Notices", "ID");
            DropColumn("dbo.Images", "Notice_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Images", "Notice_ID", c => c.Int());
            DropForeignKey("dbo.Media", "Notice_ID", "dbo.Notices");
            DropIndex("dbo.Media", new[] { "Notice_ID" });
            DropColumn("dbo.Media", "Notice_ID");
            CreateIndex("dbo.Images", "Notice_ID");
            AddForeignKey("dbo.Images", "Notice_ID", "dbo.Notices", "ID");
        }
    }
}
