namespace secondHandPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedMedia : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Images", "Media_ID", "dbo.Media");
            DropForeignKey("dbo.Videos", "Media_ID", "dbo.Media");
            DropIndex("dbo.Images", new[] { "Media_ID" });
            DropIndex("dbo.Videos", new[] { "Media_ID" });
            AddColumn("dbo.Media", "FileName", c => c.String());
            AddColumn("dbo.Media", "FileSize", c => c.Int(nullable: false));
            AddColumn("dbo.Media", "FilePath", c => c.String());
            DropColumn("dbo.Images", "Media_ID");
            DropColumn("dbo.Videos", "Media_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Videos", "Media_ID", c => c.Int());
            AddColumn("dbo.Images", "Media_ID", c => c.Int());
            DropColumn("dbo.Media", "FilePath");
            DropColumn("dbo.Media", "FileSize");
            DropColumn("dbo.Media", "FileName");
            CreateIndex("dbo.Videos", "Media_ID");
            CreateIndex("dbo.Images", "Media_ID");
            AddForeignKey("dbo.Videos", "Media_ID", "dbo.Media", "ID");
            AddForeignKey("dbo.Images", "Media_ID", "dbo.Media", "ID");
        }
    }
}
