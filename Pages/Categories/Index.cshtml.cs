using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Florea_Iulia_Lab2.Data;
using Florea_Iulia_Lab2.Models;
using Florea_Iulia_Lab2.ViewModels;

namespace Florea_Iulia_Lab2.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly Florea_Iulia_Lab2.Data.Florea_Iulia_Lab2Context _context;

        public IndexModel(Florea_Iulia_Lab2.Data.Florea_Iulia_Lab2Context context)
        {
            _context = context;
        }

        public IList<Category> Category { get;set; } = default!;


        public CategoryIndexData CategoryData { get; set; }
        public int CategoryID { get; set; }
        public int BookID { get; set; }

        public async Task OnGetAsync(int? id)
        {
            CategoryData = new CategoryIndexData();
            CategoryData.Category = await _context.Category
                .Include(c => c.BookCategories)
                    .ThenInclude(bc => bc.Book)
                        .ThenInclude(b => b.Author)
                .ToListAsync();

            if (id != null)
            {
                CategoryID = id.Value;
                var category = CategoryData.Category
                    .Where(c => c.ID == id.Value).Single();
                CategoryData.Books = category.BookCategories.Select(bc => bc.Book);
            }
        }
    }
}
