using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Section5.OrderingQueries.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Section5.OrderingQueries.Pages.Artists
{
    public class ShowModel : PageModel
    {
        private readonly ApplicationContext _context;

        public ShowModel(ApplicationContext context)
        {
            _context = context;
        }

        public Artist Artist { get; set; }

        public async Task OnGet(int id)
        {
            Artist = await (from artist in _context.Artists
                            .Include(it => it.Albums)
                            .ThenInclude(it => it.Tracks)
                            where artist.Id == id
                            select artist)
                            .FirstAsync();
        }
    }
}