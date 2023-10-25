using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using geoprofs.Models;

namespace geoprofs.Pages.Verlofs
{
    public class IndexModel : PageModel
    {
        private readonly geoprofs.Data.geoprofsContext _context;

        public IndexModel(geoprofs.Data.geoprofsContext context)
        {
            _context = context;
        }

        public IList<Verlof> Verlof { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Verlof != null)
            {
                Verlof = await _context.Verlof.ToListAsync();
            }
        }
    }
}
