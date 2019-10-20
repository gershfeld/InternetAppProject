namespace secondHandPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mediaadded1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Media",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Images", "Media_ID", c => c.Int());
            AddColumn("dbo.Videos", "Media_ID", c => c.Int());
            CreateIndex("dbo.Images", "Media_ID");
            CreateIndex("dbo.Videos", "Media_ID");
            AddForeignKey("dbo.Images", "Media_ID", "dbo.Media", "ID");
            AddForeignKey("dbo.Videos", "Media_ID", "dbo.Media", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Videos", "Media_ID", "dbo.Media");
            DropForeignKey("dbo.Images", "Media_ID", "dbo.Media");
            DropIndex("dbo.Videos", new[] { "Media_ID" });
            DropIndex("dbo.Images", new[] { "Media_ID" });
            DropColumn("dbo.Videos", "Media_ID");
            DropColumn("dbo.Images", "Media_ID");
            DropTable("dbo.Media");
        }
    }
}
