using OdeToFood.Data.Models;
using OdeToFood.Data.Services;
using System.Collections.Generic;
using System.Web.Http;

namespace OdeToFood.Web.Api
{
    public class RestaurantsController : ApiController
    {
        private readonly IRestaurantData _restaurantData;

        public RestaurantsController(IRestaurantData restaurantData)
        {
            _restaurantData = restaurantData;
        }

        public IEnumerable<Restaurant> Get()
        {
            var restaurants = _restaurantData.GetAll();

            return restaurants;
        }
    }
}
