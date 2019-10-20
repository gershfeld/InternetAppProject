namespace secondHandPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class idsss : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Media");
            DropTable("dbo.Videos");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Videos",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FileName = c.String(),
                        FileSize = c.Int(nullable: false),
                        FilePath = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Media",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FileName = c.String(),
                        FileSize = c.Int(nullable: false),
                        FilePath = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
    }
}
