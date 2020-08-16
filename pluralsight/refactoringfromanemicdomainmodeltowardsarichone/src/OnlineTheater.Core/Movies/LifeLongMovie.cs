namespace OnlineTheater.Core.Movies
{
    public class LifeLongMovie : Movie
    {
        public LifeLongMovie(string name) : base(name, ELicensingModel.LifeLong)
        {
        }

        public override ExpirationDate ExpirationDate => ExpirationDate.Infinite;

        public override Dollar Price => (Dollar)8;
    }
}
