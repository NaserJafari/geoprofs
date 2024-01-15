using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using geoprofs.Data;
using geoprofs.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace geoprofs.Pages.Verlofs
{
    [Authorize(Roles = "Admin,Werknemer,Manager")]
    public class IndexModel : PageModel
    {
        private readonly geoprofsContext _context;

        public IndexModel(geoprofsContext context)
        {
            _context = context;
        }

        public List<Verlof> Verlof { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            Verlof = await _context.Verlof.ToListAsync();
            return Page();
        }

        public IActionResult OnPostApprove(int id)
        {
            UpdateVerlofStatus(id, "Approved");
            return RedirectToPage("./Index");
        }

        public IActionResult OnPostDeny(int id)
        {
            UpdateVerlofStatus(id, "Denied");
            return RedirectToPage("./Index");
        }

        private void UpdateVerlofStatus(int id, string status)
        {
            var verlof = _context.Verlof.Find(id);
            if (verlof != null)
            {
                if (int.TryParse(status, out int statusValue))
                {
                    verlof.VerlofStatus = statusValue;
                    _context.SaveChanges();
                }
                else
                {
                    // Handle the case where status is not a valid integer
                    // For example, log an error or set a default status
                }
            }
        }
    }
}
