using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BleepControlPanel.Data;
using BleepControlPanel.Models;
using Microsoft.AspNetCore.Authorization;

namespace BleepControlPanel
{
    [Authorize(Roles = "Admin")]
    public class DishIndexModel : PageModel
    {
        private readonly BleepControlPanel.Data.ApplicationDbContext _context;

        public DishIndexModel(BleepControlPanel.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Dish> Dish { get;set; }

        public async Task OnGetAsync()
        {
            Dish = await _context.Dishes.ToListAsync();
        }
    }
}
