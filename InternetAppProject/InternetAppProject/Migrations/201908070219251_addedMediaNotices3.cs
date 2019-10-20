namespace secondHandPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedMediaNotices3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Media", "Notice_ID", "dbo.Notices");
            DropIndex("dbo.Media", new[] { "Notice_ID" });
            AddColumn("dbo.Notices", "Image", c => c.String());
            DropColumn("dbo.Media", "Notice_ID");
            DropTable("dbo.Images");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        ImageID = c.Int(nullable: false, identity: true),
                        ImageName = c.String(),
                        ImagePath = c.String(),
                    })
                .PrimaryKey(t => t.ImageID);
            
            AddColumn("dbo.Media", "Notice_ID", c => c.Int());
            DropColumn("dbo.Notices", "Image");
            CreateIndex("dbo.Media", "Notice_ID");
            AddForeignKey("dbo.Media", "Notice_ID", "dbo.Notices", "ID");
        }
    }
}
