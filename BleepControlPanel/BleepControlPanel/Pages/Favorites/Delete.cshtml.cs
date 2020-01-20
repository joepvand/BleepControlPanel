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
    public class DeleteModel : PageModel
    {
        private readonly BleepControlPanel.Data.ApplicationDbContext _context;

        public DeleteModel(BleepControlPanel.Data.ApplicationDbContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Favorite = await _context.Favorite.FindAsync(id);

            if (Favorite != null)
            {
                _context.Favorite.Remove(Favorite);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
