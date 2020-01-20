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
        [RegularExpression(
            "(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|\"(?:[\\x01-\\x08\\x0b\\x0c\\x0e-\\x1f\\x21\\x23-\\x5b\\x5d-\\x7f]|\\\\[\\x01-\\x09\\x0b\\x0c\\x0e-\\x7f])*\")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\\x01-\\x08\\x0b\\x0c\\x0e-\\x1f\\x21-\\x5a\\x53-\\x7f]|\\\\[\\x01-\\x09\\x0b\\x0c\\x0e-\\x7f])+)\\])",
            ErrorMessage = "Wrong format")]
        [Required]
        public string Email { get; set; }

        public string allergies { get; set; }

        [StringLength(60, MinimumLength = 1)]
        [Required]
        public string Password { get; set; }

        [Required] public DateTime DateCreated { get; set; }
    }
}