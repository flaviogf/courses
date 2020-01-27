namespace Paladin.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Street = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Zip = c.String(),
                        IsMailing = c.Boolean(nullable: false),
                        Applicant_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Applicants", t => t.Applicant_Id)
                .Index(t => t.Applicant_Id);
            
            CreateTable(
                "dbo.Applicants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tracker = c.Guid(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        Phone = c.String(),
                        Email = c.String(),
                        MaritalStatus = c.String(),
                        HighestEducation = c.String(),
                        LicenseStatus = c.String(),
                        YearLicensed = c.String(),
                        WorkFlowStage = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Employements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        Employer = c.String(),
                        Position = c.String(),
                        GrossMonthlyIncome = c.Double(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        IsPrimary = c.Boolean(nullable: false),
                        Applicant_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Applicants", t => t.Applicant_Id)
                .Index(t => t.Applicant_Id);
            
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Year = c.Int(nullable: false),
                        Make = c.String(),
                        Model = c.String(),
                        BodyType = c.String(),
                        PrimaryUse = c.String(),
                        OwnLease = c.String(),
                        Applicant_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Applicants", t => t.Applicant_Id)
                .Index(t => t.Applicant_Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Liability = c.Double(nullable: false),
                        RoadSideAssistance = c.Boolean(nullable: false),
                        PropertyDamage = c.Double(nullable: false),
                        Collision = c.Double(nullable: false),
                        Comprehensive = c.Double(nullable: false),
                        Rental = c.Boolean(nullable: false),
                        LoanPayoff = c.Boolean(nullable: false),
                        DriveRewards = c.Boolean(nullable: false),
                        Applicant_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Applicants", t => t.Applicant_Id)
                .Index(t => t.Applicant_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "Applicant_Id", "dbo.Applicants");
            DropForeignKey("dbo.Vehicles", "Applicant_Id", "dbo.Applicants");
            DropForeignKey("dbo.Employements", "Applicant_Id", "dbo.Applicants");
            DropForeignKey("dbo.Addresses", "Applicant_Id", "dbo.Applicants");
            DropIndex("dbo.Products", new[] { "Applicant_Id" });
            DropIndex("dbo.Vehicles", new[] { "Applicant_Id" });
            DropIndex("dbo.Employements", new[] { "Applicant_Id" });
            DropIndex("dbo.Addresses", new[] { "Applicant_Id" });
            DropTable("dbo.Products");
            DropTable("dbo.Vehicles");
            DropTable("dbo.Employements");
            DropTable("dbo.Applicants");
            DropTable("dbo.Addresses");
        }
    }
}
