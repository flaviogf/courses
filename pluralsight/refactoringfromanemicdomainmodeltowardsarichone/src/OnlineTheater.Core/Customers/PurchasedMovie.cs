using OnlineTheater.Core.Movies;
using System;

namespace OnlineTheater.Core.Customers
{
    public class PurchasedMovie
    {
        public PurchasedMovie(Movie movie, Customer customer, Dollar price, ExpirationDate expirationDate)
        {
            Movie = movie;
            Customer = customer;
            Price = price;
            ExpirationDate = expirationDate;
            PurchasedDate = DateTime.UtcNow;
        }

        public Movie Movie { get; }

        public Customer Customer { get; }

        public Dollar Price { get; }

        public ExpirationDate ExpirationDate { get; }

        public DateTime PurchasedDate { get; }
    }
}
