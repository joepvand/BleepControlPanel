using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BleepControlPanel.Data;
using BleepControlPanel.Models;

namespace BleepControlPanel.Pages.Favorites
{
    public class EditModel : PageModel
    {
        private readonly BleepControlPanel.Data.ApplicationDbContext _context;

        public EditModel(BleepControlPanel.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Favorite).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FavoriteExists(Favorite.Id))
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

        private bool FavoriteExists(int id)
        {
            return _context.Favorite.Any(e => e.Id == id);
        }
    }
}
