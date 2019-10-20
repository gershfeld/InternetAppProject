namespace secondHandPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class useradded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Notices", "U_Username", c => c.String(maxLength: 128));
            CreateIndex("dbo.Notices", "U_Username");
            AddForeignKey("dbo.Notices", "U_Username", "dbo.Users", "Username");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Notices", "U_Username", "dbo.Users");
            DropIndex("dbo.Notices", new[] { "U_Username" });
            DropColumn("dbo.Notices", "U_Username");
        }
    }
}
