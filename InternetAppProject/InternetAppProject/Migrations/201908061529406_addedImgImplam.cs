namespace secondHandPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedImgImplam : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Notices", "Images_ImageID", "dbo.Images");
            DropIndex("dbo.Notices", new[] { "Images_ImageID" });
            AddColumn("dbo.Images", "ImageName", c => c.String());
            AddColumn("dbo.Images", "Notice_ID", c => c.Int());
            CreateIndex("dbo.Images", "Notice_ID");
            AddForeignKey("dbo.Images", "Notice_ID", "dbo.Notices", "ID");
            DropColumn("dbo.Notices", "Images_ImageID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Notices", "Images_ImageID", c => c.Int());
            DropForeignKey("dbo.Images", "Notice_ID", "dbo.Notices");
            DropIndex("dbo.Images", new[] { "Notice_ID" });
            DropColumn("dbo.Images", "Notice_ID");
            DropColumn("dbo.Images", "ImageName");
            CreateIndex("dbo.Notices", "Images_ImageID");
            AddForeignKey("dbo.Notices", "Images_ImageID", "dbo.Images", "ImageID");
        }
    }
}
