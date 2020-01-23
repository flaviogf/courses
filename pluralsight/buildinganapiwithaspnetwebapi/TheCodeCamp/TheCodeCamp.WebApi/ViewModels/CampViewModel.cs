using System;

namespace TheCodeCamp.WebApi.ViewModels
{
    public class CampViewModel
    {
        public string Name { get; set; }

        public string Moniker { get; set; }

        public DateTime EventDate { get; set; }

        public int Length { get; set; }
    }
}