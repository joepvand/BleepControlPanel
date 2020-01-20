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
    public class IndexModel : PageModel
    {
        private readonly BleepControlPanel.Data.ApplicationDbContext _context;

        public IndexModel(BleepControlPanel.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Shoppinglist> Shoppinglist { get;set; }

        public async Task OnGetAsync()
        {
            Shoppinglist = await _context.Shoppinglist
                .Include(s => s.user).ToListAsync();
        }
    }
}
