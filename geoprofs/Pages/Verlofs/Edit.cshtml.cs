using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using geoprofs.Data;
using geoprofs.Models;
using Microsoft.AspNetCore.Authorization;

namespace geoprofs.Pages.Verlofs
{
    [Authorize(Roles = "Werknemer,Manager")]
    public class EditModel : PageModel
    {
        private readonly geoprofs.Data.geoprofsContext _context;

        public EditModel(geoprofs.Data.geoprofsContext context)
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

            var verlof =  await _context.Verlof.FirstOrDefaultAsync(m => m.VerlofId == id);
            if (verlof == null)
            {
                return NotFound();
            }
            Verlof = verlof;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Verlof).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VerlofExists(Verlof.VerlofId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool VerlofExists(int id)
        {
          return (_context.Verlof?.Any(e => e.VerlofId == id)).GetValueOrDefault();
        }
    }
}
