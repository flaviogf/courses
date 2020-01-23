using System;

namespace TheCodeCamp.WebApi.Models
{
    public class Camp
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Moniker { get; set; }

        public Location Location { get; set; }

        public DateTime EventDate { get; set; }

        public int Length { get; set; }
    }
}