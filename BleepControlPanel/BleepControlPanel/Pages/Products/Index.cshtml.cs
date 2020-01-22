
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BleepControlPanel;
using BleepControlPanel.Data;
using BleepControlPanel.Models;
using Microsoft.AspNetCore.Authorization;

namespace BleepControlPanel
{
    [Authorize(Roles = "Admin")]

    public class ProductIndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public ProductIndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public string NameSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public PaginatedList<Product> Products { get; set; }

        public async Task OnGetAsync(string sortOrder,
            string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DateSort = sortOrder == "Prijs" ? "Prijs_desc" : "Prijs";
            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;

            IQueryable<Product> studentsIQ = from s in _context.Product
                select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                studentsIQ = studentsIQ.Where(s => s.naam.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    studentsIQ = studentsIQ.OrderByDescending(s => s.naam);
                    break;
                case "Prijs":
                    studentsIQ = studentsIQ.OrderBy(s => s.prijs);
                    break;
                case "Prijs_desc":
                    studentsIQ = studentsIQ.OrderByDescending(s => s.prijs);
                    break;
                default:
                    studentsIQ = studentsIQ.OrderBy(s => s.naam);
                    break;
            }

            int pageSize = 20;
            Products = await PaginatedList<Product>.CreateAsync(
                studentsIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}