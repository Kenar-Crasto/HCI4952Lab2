using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CommunityApp.Data;
using CommunityApp.Models;

namespace CommunityApp.Pages_CityPages
{
    public class DeleteModel : PageModel
    {
        private readonly CommunityApp.Data.ApplicationDbContext _context;

        public DeleteModel(CommunityApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public City City { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.City == null)
            {
                return NotFound();
            }

            var city = await _context.City.FirstOrDefaultAsync(m => m.CityId == id);

            if (city == null)
            {
                return NotFound();
            }
            else 
            {
                City = city;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.City == null)
            {
                return NotFound();
            }
            var city = await _context.City.FindAsync(id);

            if (city != null)
            {
                City = city;
                _context.City.Remove(City);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
