using System;
using System.Threading.Tasks;
using GloboTicket.Client.Models.View;
using GloboTicket.Client.Services;
using Microsoft.AspNetCore.Mvc;

namespace GloboTicket.Client.Controllers
{
    public class EventCatalogController : Controller
    {
        private readonly IEventCatalogService _eventCatalogService;

        public EventCatalogController(IEventCatalogService eventCatalogService)
        {
            _eventCatalogService = eventCatalogService;
        }

        public async Task<IActionResult> Index(Guid? categoryId = null)
        {
            var categories = _eventCatalogService.GetAllCategories();

            var events = _eventCatalogService.GetAllEvents(categoryId);

            await Task.WhenAll(categories, events);

            return View(new EventListModel
            {
                Events = events.Result,
                Categories = categories.Result,
                CategoryId = categoryId
            });
        }

        public async Task<IActionResult> Detail(Guid eventId)
        {
            var @event = await _eventCatalogService.GetEvent(eventId);

            return View(@event);
        }
    }
}
