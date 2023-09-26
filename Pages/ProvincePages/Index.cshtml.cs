using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CommunityApp.Data;
using CommunityApp.Models;

namespace CommunityApp.Pages_ProvincePages
{
    public class IndexModel : PageModel
    {
        private readonly CommunityApp.Data.ApplicationDbContext _context;

        public IndexModel(CommunityApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Province> Province { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Province != null)
            {
                Province = await _context.Province.ToListAsync();
            }
        }
    }
}
