using OdeToFood.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data.Services
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        private readonly IList<Restaurant> _restaurants;

        public InMemoryRestaurantData()
        {
            _restaurants = new List<Restaurant>()
            {
                new Restaurant { Id = 1, Name="Scott's Pizza", Cuisine = CuisineType.Italian },
                new Restaurant { Id = 2, Name="Tersiguels", Cuisine = CuisineType.French },
                new Restaurant { Id = 3, Name="Mango Grove", Cuisine = CuisineType.Indian }
            };
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return _restaurants.OrderBy(it => it.Name);
        }

        public Restaurant Get(int id)
        {
            return _restaurants.FirstOrDefault(it => it.Id == id);
        }

        public Restaurant Add(Restaurant restaurant)
        {
            var id = _restaurants.Max(it => it.Id) + 1;

            var created = new Restaurant
            {
                Id = id,
                Name = restaurant.Name,
                Cuisine = restaurant.Cuisine
            };

            _restaurants.Add(created);

            return created;
        }

        public Restaurant Update(Restaurant restaurant)
        {
            var updated = _restaurants.FirstOrDefault(it => it.Id == restaurant.Id);

            updated.Name = restaurant.Name;
            updated.Cuisine = restaurant.Cuisine;

            return updated;
        }
    }
}
