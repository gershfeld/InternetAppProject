namespace secondHandPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedCounter : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Notices", "counter", c => c.Int(nullable: false));
            DropTable("dbo.Statis");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Statis",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.ID);
            
            DropColumn("dbo.Notices", "counter");
        }
    }
}
