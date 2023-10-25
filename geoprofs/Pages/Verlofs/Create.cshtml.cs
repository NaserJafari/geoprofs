using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using geoprofs.Data;
using geoprofs.Models;

namespace geoprofs.Pages.Verlofs
{
    public class CreateModel : PageModel
    {
        private readonly geoprofs.Data.geoprofsContext _context;

        public CreateModel(geoprofs.Data.geoprofsContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Verlof Verlof { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Verlof == null || Verlof == null)
            {
                return Page();
            }

            _context.Verlof.Add(Verlof);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
