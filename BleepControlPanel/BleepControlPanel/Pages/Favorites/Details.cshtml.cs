using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BleepControlPanel.Data;
using BleepControlPanel.Models;

namespace BleepControlPanel.Pages.Favorites
{
    public class DetailsModel : PageModel
    {
        private readonly BleepControlPanel.Data.ApplicationDbContext _context;

        public DetailsModel(BleepControlPanel.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Favorite Favorite { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Favorite = await _context.Favorite.FirstOrDefaultAsync(m => m.Id == id);

            if (Favorite == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
