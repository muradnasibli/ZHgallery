using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioWebApp.Models
{
    public class ContactViewModel
    {
        [Required(ErrorMessage ="Enter your name")]
        [MinLength(1, ErrorMessage ="Enter your name correctly")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter your email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter your message")]
        public string Message { get; set; }

    }
}
