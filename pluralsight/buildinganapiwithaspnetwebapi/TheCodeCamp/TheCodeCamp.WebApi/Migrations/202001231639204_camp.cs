namespace TheCodeCamp.WebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class camp : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Camps",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Moniker = c.String(),
                        EventDate = c.DateTime(nullable: false),
                        Length = c.Int(nullable: false),
                        Location_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Locations", t => t.Location_Id)
                .Index(t => t.Location_Id);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VenueName = c.String(),
                        Address1 = c.String(),
                        Address2 = c.String(),
                        Address3 = c.String(),
                        CityTown = c.String(),
                        StateProvince = c.String(),
                        PostalCode = c.String(),
                        Country = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Camps", "Location_Id", "dbo.Locations");
            DropIndex("dbo.Camps", new[] { "Location_Id" });
            DropTable("dbo.Locations");
            DropTable("dbo.Camps");
        }
    }
}
