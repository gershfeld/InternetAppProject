namespace secondHandPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Notices",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Contact = c.String(),
                        Name = c.String(),
                        Description = c.String(),
                        Price = c.Double(nullable: false),
                        State = c.Int(nullable: false),
                        Category = c.Int(nullable: false),
                        Images_ImageID = c.Int(),
                        U_Username = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Images", t => t.Images_ImageID)
                .ForeignKey("dbo.Users", t => t.U_Username)
                .Index(t => t.Images_ImageID)
                .Index(t => t.U_Username);
            
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        ImageID = c.Int(nullable: false, identity: true),
                        ImagePath = c.String(),
                    })
                .PrimaryKey(t => t.ImageID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Username = c.String(nullable: false, maxLength: 128),
                        Password = c.String(nullable: false),
                        Email = c.String(),
                        Phone = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Username);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Notices", "U_Username", "dbo.Users");
            DropForeignKey("dbo.Notices", "Images_ImageID", "dbo.Images");
            DropIndex("dbo.Notices", new[] { "U_Username" });
            DropIndex("dbo.Notices", new[] { "Images_ImageID" });
            DropTable("dbo.Users");
            DropTable("dbo.Images");
            DropTable("dbo.Notices");
        }
    }
}
