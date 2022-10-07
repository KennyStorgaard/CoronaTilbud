using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoronaTilbud_V2.Models
{
    public class EmailForm
    {
        [Required]
        [Display(Name = "Navn")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Telefon")]
        public string Phone { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }


        [Required]
        [Display(Name = "Besked")]
        public string Message { get; set; }

        public string Subject { get; set; }
    }
}
