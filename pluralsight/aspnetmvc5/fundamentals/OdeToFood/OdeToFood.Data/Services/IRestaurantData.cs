using OdeToFood.Data.Models;
using System.Collections.Generic;

namespace OdeToFood.Data.Services
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();

        Restaurant Get(int id);

        Restaurant Add(Restaurant restaurant);

        Restaurant Update(Restaurant restaurant);

        Restaurant Remove(Restaurant restaurant);
    }
}