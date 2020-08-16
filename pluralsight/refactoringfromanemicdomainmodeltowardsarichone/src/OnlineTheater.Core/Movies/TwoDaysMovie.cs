using System;

namespace OnlineTheater.Core.Movies
{
    public class TwoDaysMovie : Movie
    {
        public TwoDaysMovie(string name) : base(name, ELicensingModel.TwoDays)
        {
        }

        public override ExpirationDate ExpirationDate => (ExpirationDate)DateTime.UtcNow.AddDays(2);

        public override Dollar Price => (Dollar)4;
    }
}
