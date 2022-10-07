using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoronaTilbud_V2.Models
{
    public class AddForm
    {
        [Required]
        [Display(Name = "Firma")]
        public string CompanyName { get; set; }

        [Required]
        [Display(Name = "Telefon")]
        public string Phone { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Overskrift til annonce")]
        public string Headline { get; set; }

        [Required]
        [Display(Name = "Corona tilbud")]
        public string Message { get; set; }

        public string Subject { get; set; }

       // public string Path { get; set; }
        public IFormFile Attachments { get; set; }
        public string FileName { get; set; }
    }
}
