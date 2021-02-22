using System;
using System.Collections.Generic;
using GloboTicket.Client.Models.Api;

namespace GloboTicket.Client.Models.View
{
    public class EventListModel
    {
        public IEnumerable<Event> Events { get; set; } = new List<Event>();
        public IEnumerable<Category> Categories { get; set; } = new List<Category>();
        public Guid? CategoryId { get; set; }
    }
}
