using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Forms;

namespace BleepControlPanel.Models
{
    public class Product
    {
        public int Id { get; set; }

        [MinLength(1, ErrorMessage = "Minimum length of 1")]
        [Required]
        public string naam { get; set; }

        [MinLength(8, ErrorMessage = "Barcodes need to be 8 or 13 long")]
        [Required]
        public string barcode { get; set; }


        [MinLength(1)]
        [RegularExpression(@"\d+\.\d{1,2}", ErrorMessage = "Please use a price format")]
        [Required]
        public string prijs { get; set; }


        public string ingredient { get; set; }

        public string allergie { get; set; }


        public List<string> AllergieList = new List<string>();
        public List<string> IngredientList = new List<string>();

        public override string ToString()
        {
            return naam;
        }
    }
}