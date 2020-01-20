using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BleepControlPanel.Data;
using BleepControlPanel.Models;

namespace BleepControlPanel.Pages.Shoppinglists
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
        ViewData["UserId"] = new SelectList(_context.users, "Id", "Email");
            return Page();
        }

        [BindProperty]
        public Shoppinglist Shoppinglist { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Shoppinglist.Add(Shoppinglist);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
