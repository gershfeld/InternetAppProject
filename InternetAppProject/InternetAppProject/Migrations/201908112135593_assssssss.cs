namespace secondHandPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class assssssss : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Statis",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Statis");
        }
    }
}
