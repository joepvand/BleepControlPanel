using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BleepControlPanel.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BleepControlPanel.Pages.WebsiteUsers
{
    public class CreateModel : PageModel
    {
        private readonly BleepControlPanel.Data.ApplicationDbContext _context;

        public CreateModel(BleepControlPanel.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public IdentityUser User { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Users.Add(User);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}