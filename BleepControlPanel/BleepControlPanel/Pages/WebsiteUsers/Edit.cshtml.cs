using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BleepControlPanel.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BleepControlPanel.Pages.WebsiteUsers
{
    public class EditModel : PageModel
    {
        private readonly BleepControlPanel.Data.ApplicationDbContext _context;

        public EditModel(BleepControlPanel.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public IdentityUser User { get; set; }

        public async Task<IActionResult> OnGetAsync(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            User = await _context.Users.FirstOrDefaultAsync(m => m.Id == id);

            if (User == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(User).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(Convert.ToInt32(User.Id)))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool UserExists(int id)
        {
            return _context.users.Any(e => e.Id == id);
        }
    }
}
