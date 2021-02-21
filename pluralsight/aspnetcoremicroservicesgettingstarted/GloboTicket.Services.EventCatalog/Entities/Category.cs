using System;
using System.Collections.Generic;

namespace GloboTicket.Services.EventCatalog.Entities
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IList<Event> Events { get; set; } = new List<Event>();
    }
}
