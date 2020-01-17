using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BleepControlPanel.Models
{
    public class User
    {
        public int Id { get; set; }

        [StringLength(60, MinimumLength = 1)]
        [Required]
        public string Name { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [Required]
        public string Email { get; set; }



        public string allergies { get; set; }

        [StringLength(60, MinimumLength = 1)]
        [Required]
        public string Password { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }
    }
}
