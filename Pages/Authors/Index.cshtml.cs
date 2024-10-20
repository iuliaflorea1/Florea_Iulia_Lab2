﻿using System;
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
    public class IndexModel : PageModel
    {
        private readonly Florea_Iulia_Lab2.Data.Florea_Iulia_Lab2Context _context;

        public IndexModel(Florea_Iulia_Lab2.Data.Florea_Iulia_Lab2Context context)
        {
            _context = context;
        }

        
        public IList<Florea_Iulia_Lab2.Models.Authors> Authors { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Authors = await _context.Authors.ToListAsync();
        }
    }
}
