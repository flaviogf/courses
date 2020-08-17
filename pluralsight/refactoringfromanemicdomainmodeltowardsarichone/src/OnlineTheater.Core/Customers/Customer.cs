using CSharpFunctionalExtensions;
using OnlineTheater.Core.Movies;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineTheater.Core.Customers
{
    public class Customer
    {
        private readonly IList<PurchasedMovie> _purchasedMovies;

        public Customer(Name name, Email email)
        {
            Name = name;
            Email = email;
            MoneySpent = Dollar.Minimum;
            Status = CustomerStatus.Regular;
            _purchasedMovies = new List<PurchasedMovie>();
        }

        public Name Name { get; }

        public Email Email { get; }

        public Dollar MoneySpent { get; private set; }

        public CustomerStatus Status { get; private set; }

        public IReadOnlyList<PurchasedMovie> PurchasedMovies => _purchasedMovies.ToList();

        public bool HasPurchasedMovie(Movie movie)
        {
            return PurchasedMovies.Any(it => it.Movie == movie && !it.ExpirationDate.IsExpired);
        }

        public void PurchaseMovie(Movie movie)
        {
            if (HasPurchasedMovie(movie))
            {
                throw new Exception();
            }

            var price = movie.CalculatePrice(Status);

            var purchasedMovie = new PurchasedMovie(movie, this, price, movie.ExpirationDate);

            _purchasedMovies.Add(purchasedMovie);

            MoneySpent += price;
        }

        public Result CanPromote()
        {
            if (Status.Type == ECustomerStatusType.Advanced)
            {
                return Result.Failure("The customer already has the Advanced status");
            }

            return Result.Success();
        }

        public void Promote()
        {
            if (CanPromote().IsFailure)
            {
                throw new Exception();
            }

            Status = Status.Promote();
        }
    }
}
