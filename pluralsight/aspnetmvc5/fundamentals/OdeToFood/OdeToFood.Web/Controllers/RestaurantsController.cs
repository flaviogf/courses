using OdeToFood.Data.Services;
using System.Web.Mvc;

namespace OdeToFood.Web.Controllers
{
    public class RestaurantsController : Controller
    {
        private readonly IRestaurantData _restaurantData;

        public RestaurantsController(IRestaurantData restaurantData)
        {
            _restaurantData = restaurantData;
        }

        public ActionResult Index()
        {
            var restaurants = _restaurantData.GetAll();

            return View(restaurants);
        }

        public ActionResult Details(int id)
        {
            var restaurant = _restaurantData.Get(id);

            if (restaurant == null)
            {
                return View("NotFound");
            }

            return View(restaurant);
        }

        public ActionResult Create()
        {
            return View();
        }
    }
}