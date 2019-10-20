namespace secondHandPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovesUserForNow : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Notices", "U_Username", "dbo.Users");
            DropIndex("dbo.Notices", new[] { "U_Username" });
            DropColumn("dbo.Notices", "U_Username");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Notices", "U_Username", c => c.String(maxLength: 128));
            CreateIndex("dbo.Notices", "U_Username");
            AddForeignKey("dbo.Notices", "U_Username", "dbo.Users", "Username");
        }
    }
}
