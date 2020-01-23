namespace TheCodeCamp.WebApi.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TheCodeCamp.WebApi.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<TheCodeCamp.WebApi.TheCodeCampContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TheCodeCamp.WebApi.TheCodeCampContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            context.Camps.AddOrUpdate
            (
                it => it.Id,
                new Camp
                {
                    Id = 1,
                    Moniker = "ATL2018",
                    Name = "Atlanta Cod Camp",
                    EventDate = new DateTime(2018, 10, 18),
                    Location = new Location
                    {
                        VenueName = "Atlanta Convention Center",
                        Address1 = "123 Main Street",
                        CityTown = "Atlanta",
                        StateProvince = "GA",
                        PostalCode = "12345",
                        Country = "USA"
                    },
                    Length = 1,
                    Talks = new Talk[]
                    {
                        new Talk
                        {
                            Id = 1,
                            Title = "Entity Framework From Scratch",
                            Abstract = "Entity Framework from scratch in an hour. Probably cover it all.",
                            Level = 100,
                            Speaker = new Speaker
                            {
                                Id = 1,
                                FirstName = "Shawn",
                                LastName = "Wildermuth",
                                BlogUrl = "http://widermuth.com",
                                Company = "Wilder Minds LLC",
                                CompanyUrl = "http://wilderminds.com",
                                GitHub = "shawnwildermuth",
                                Twitter = "shawnwildermuth"
                            }
                        },
                        new Talk
                        {
                            Id = 2,
                            Title = "Writing Sample Data Made Easy",
                            Abstract ="Thinking of good sample data examples is tiring.",
                            Level = 200,
                            Speaker = new Speaker
                            {
                                Id = 2,
                                FirstName = "Resa",
                                LastName = "Wildermuth",
                                BlogUrl = "http://shawandresa.com",
                                Company = "Wilder Minds LLC",
                                CompanyUrl = "http://wilderminds.com",
                                GitHub = "resawildermuth",
                                Twitter = "resawildermuth"
                            }
                        }
                    }
                }
            );
        }
    }
}