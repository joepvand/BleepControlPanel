using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BleepControlPanel.Data;
using BleepControlPanel.Models;

namespace BleepControlPanel
{
    public class DishDetailsModel : PageModel
    {
        private readonly BleepControlPanel.Data.ApplicationDbContext _context;

        public DishDetailsModel(BleepControlPanel.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Dish Dish { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Dish = await _context.Dishes.FirstOrDefaultAsync(m => m.ID == id);

            if (Dish == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
