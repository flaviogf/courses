using OdeToFood.Data.Models;
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

        [HttpGet]
        public ActionResult Index()
        {
            var restaurants = _restaurantData.GetAll();

            return View(restaurants);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var restaurant = _restaurantData.Get(id);

            if (restaurant == null)
            {
                return View("NotFound");
            }

            return View(restaurant);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Restaurant restaurant)
        {
            if (!ModelState.IsValid)
            {
                return View(restaurant);
            }

            var created = _restaurantData.Add(restaurant);

            return RedirectToAction("Details", new { id = created.Id });
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var restaurant = _restaurantData.Get(id);

            if (restaurant == null)
            {
                return View("NotFound");
            }

            return View(restaurant);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Restaurant restaurant)
        {
            if (!ModelState.IsValid)
            {
                return View(restaurant);
            }

            var updated = _restaurantData.Update(restaurant);

            return RedirectToAction("Details", new { id = updated.Id });
        }
    }
}