using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace BleepControlPanel.Models
{
    public class Favorite
    {
        public int Id { get; set; }

        [Column(TypeName="date")]
        public DateTime date_added { get; set; }

        public User User { get; set; }
        public int User_Id { get; set; }

        public Product Product { get; set; }
        public int Product_Id { get; set; }

    }
}
