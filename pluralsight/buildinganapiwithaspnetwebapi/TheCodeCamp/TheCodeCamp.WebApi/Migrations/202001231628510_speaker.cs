namespace TheCodeCamp.WebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class speaker : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Speakers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        MiddleName = c.String(),
                        Company = c.String(),
                        CompanyUrl = c.String(),
                        BlogUrl = c.String(),
                        Twitter = c.String(),
                        GitHub = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Speakers");
        }
    }
}
