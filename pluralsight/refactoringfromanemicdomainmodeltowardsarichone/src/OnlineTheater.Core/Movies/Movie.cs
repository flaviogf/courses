namespace OnlineTheater.Core.Movies
{
    public abstract class Movie
    {
        protected Movie(string name, ELicensingModel licensingModel)
        {
            Name = name;
            LicensingModel = licensingModel;
        }

        public string Name { get; }

        public ELicensingModel LicensingModel { get; }

        public abstract ExpirationDate ExpirationDate { get; }

        public abstract Dollar Price { get; }
    }
}
