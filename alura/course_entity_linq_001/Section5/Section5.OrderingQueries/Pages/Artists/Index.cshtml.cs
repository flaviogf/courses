using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Section5.OrderingQueries.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Section5.OrderingQueries.Pages.Artists
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationContext _context;

        public IList<Artist> Artists { get; set; }


        [BindProperty(SupportsGet = true)]
        public int Skip { get; set; } = 0;


        [BindProperty(SupportsGet = true)]
        public int Take { get; set; } = 5;

        public IndexModel(ApplicationContext context)
        {
            _context = context;
        }

        public async Task OnGetAsync()
        {
            Artists = await (from artist in _context.Artists
                             orderby artist.Id
                             select artist)
                            .Skip(Skip)
                            .Take(Take)
                            .ToListAsync();
        }
    }
}
