using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using geoprofs.Data;
using geoprofs.Models;

namespace geoprofs.Pages.Verlofs
{
    public class DeleteModel : PageModel
    {
        private readonly geoprofs.Data.geoprofsContext _context;

        public DeleteModel(geoprofs.Data.geoprofsContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Verlof Verlof { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Verlof == null)
            {
                return NotFound();
            }

            var verlof = await _context.Verlof.FirstOrDefaultAsync(m => m.VerlofId == id);

            if (verlof == null)
            {
                return NotFound();
            }
            else 
            {
                Verlof = verlof;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Verlof == null)
            {
                return NotFound();
            }
            var verlof = await _context.Verlof.FindAsync(id);

            if (verlof != null)
            {
                Verlof = verlof;
                _context.Verlof.Remove(Verlof);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
