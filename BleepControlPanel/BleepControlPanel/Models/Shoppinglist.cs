using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace BleepControlPanel.Models
{
    public class Shoppinglist
    {
        public int Id { get; set; }
        public DateTime Creation_date { get; set; }

        public DateTime Date_updated { get; set; }
        public string Name { get; set; }

        public User user { get; set; }
        public int UserId { get; set; }
    }
}
