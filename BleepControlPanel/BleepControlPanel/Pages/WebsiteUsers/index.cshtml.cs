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
using Microsoft.AspNetCore.Identity;

namespace BleepControlPanel.Pages.WebsiteUsers
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly BleepControlPanel.Data.ApplicationDbContext _context;

        public IndexModel(BleepControlPanel.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<IdentityUser> User { get;set; }

        public async Task OnGetAsync()
        {
            User = await _context.Users.ToListAsync();
        }
    }
}