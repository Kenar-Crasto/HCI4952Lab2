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
    public class DetailsModel : PageModel
    {
        private readonly CommunityApp.Data.ApplicationDbContext _context;

        public DetailsModel(CommunityApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public Province Province { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.Province == null)
            {
                return NotFound();
            }

            var province = await _context.Province.FirstOrDefaultAsync(m => m.ProvinceCode == id);
            if (province == null)
            {
                return NotFound();
            }
            else 
            {
                Province = province;
            }
            return Page();
        }
    }
}
