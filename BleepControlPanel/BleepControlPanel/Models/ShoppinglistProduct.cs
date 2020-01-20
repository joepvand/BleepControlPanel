using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BleepControlPanel.Models
{
    public class ShoppinglistProduct
    {
        public int Id { get; set; }
        public Shoppinglist Shoppinglist { get; set; }
        public Product Product { get; set; }
    }
}
