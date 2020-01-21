using OdeToFood.Data.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace OdeToFood.Data.Services
{
    public class EntityFrameworkRestaurantData : IRestaurantData
    {
        private readonly OdeToFoodDbContext _context;

        public EntityFrameworkRestaurantData(OdeToFoodDbContext context)
        {
            _context = context;
        }

        public Restaurant Add(Restaurant restaurant)
        {
            _context.Restaurants.Add(restaurant);
            _context.SaveChanges();
            return restaurant;
        }

        public Restaurant Get(int id)
        {
            return _context.Restaurants.FirstOrDefault(it => it.Id == id);
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return from restaurant in _context.Restaurants
                   orderby restaurant.Name
                   select restaurant;
        }

        public Restaurant Update(Restaurant restaurant)
        {
            _context.Entry(restaurant).State = EntityState.Modified;
            _context.SaveChanges();
            return restaurant;
        }

        public Restaurant Remove(Restaurant restaurant)
        {
            var removed = _context.Restaurants.FirstOrDefault(it => it.Id == restaurant.Id);
            _context.Restaurants.Remove(removed);
            _context.SaveChanges();
            return removed;
        }
    }
}
