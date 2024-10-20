using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Florea_Iulia_Lab2.Data;
using Florea_Iulia_Lab2.Models;

namespace Florea_Iulia_Lab2.Pages.Authors
{
    public class DeleteModel : PageModel
    {
        private readonly Florea_Iulia_Lab2.Data.Florea_Iulia_Lab2Context _context;

        public DeleteModel(Florea_Iulia_Lab2.Data.Florea_Iulia_Lab2Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Florea_Iulia_Lab2.Models.Authors Authors { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var authors = await _context.Authors.FirstOrDefaultAsync(m => m.ID == id);

            if (authors == null)
            {
                return NotFound();
            }
            else
            {
                Authors = authors;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var authors = await _context.Authors.FindAsync(id);
            if (authors != null)
            {
                Authors = authors;
                _context.Authors.Remove(Authors);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
