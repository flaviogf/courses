using Microsoft.AspNetCore.Mvc;

namespace GloboTicket.Client.Controllers
{
    public class ShoppingBasketController : ControllerBase
    {
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddLine()
        {
            return RedirectToAction("Index", "EventCatalog");
        }
    }
}
