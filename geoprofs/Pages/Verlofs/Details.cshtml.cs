﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using geoprofs.Data;
using geoprofs.Models;
using Microsoft.AspNetCore.Authorization;

namespace geoprofs.Pages.Verlofs
{
    [Authorize]
    public class DetailsModel : PageModel
    {
        private readonly geoprofs.Data.geoprofsContext _context;

        public DetailsModel(geoprofs.Data.geoprofsContext context)
        {
            _context = context;
        }

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
    }
}
