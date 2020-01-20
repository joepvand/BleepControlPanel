using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BleepControlPanel.Data;
using BleepControlPanel.Models;

namespace BleepControlPanel.Pages.Shoppinglists
{
    public class DetailsModel : PageModel
    {
        private readonly BleepControlPanel.Data.ApplicationDbContext _context;

        public DetailsModel(BleepControlPanel.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Shoppinglist Shoppinglist { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Shoppinglist = await _context.Shoppinglist
                .Include(s => s.user).FirstOrDefaultAsync(m => m.Id == id);

            if (Shoppinglist == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
