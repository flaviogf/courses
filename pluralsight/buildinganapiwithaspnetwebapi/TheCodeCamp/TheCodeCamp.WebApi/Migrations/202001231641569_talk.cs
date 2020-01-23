namespace TheCodeCamp.WebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class talk : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Talks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Abstract = c.String(),
                        Level = c.Int(nullable: false),
                        Camp_Id = c.Int(),
                        Speaker_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Camps", t => t.Camp_Id)
                .ForeignKey("dbo.Speakers", t => t.Speaker_Id)
                .Index(t => t.Camp_Id)
                .Index(t => t.Speaker_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Talks", "Speaker_Id", "dbo.Speakers");
            DropForeignKey("dbo.Talks", "Camp_Id", "dbo.Camps");
            DropIndex("dbo.Talks", new[] { "Speaker_Id" });
            DropIndex("dbo.Talks", new[] { "Camp_Id" });
            DropTable("dbo.Talks");
        }
    }
}
