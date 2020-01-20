using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BleepControlPanel.Models;

namespace BleepControlPanel.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<BleepControlPanel.Models.User> users { get; set; }
        public DbSet<BleepControlPanel.Models.Product> Product { get; set; }
        public DbSet<BleepControlPanel.Models.Dish> Dishes { get; set; }
        public DbSet<BleepControlPanel.Models.Shoppinglist> Shoppinglist { get; set; }
        public DbSet<BleepControlPanel.Models.ShoppinglistProduct> ShoppinglistProduct { get; set; }
        public DbSet<BleepControlPanel.Models.Favorite> Favorite { get; set; }
    }
}
