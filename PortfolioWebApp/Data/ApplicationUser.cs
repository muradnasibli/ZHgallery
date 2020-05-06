using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioWebApp.Data
{
    public class ApplicationUser : IdentityUser
    {
        [Required(ErrorMessage = "Enter your Name")]
        [StringLength(50, ErrorMessage = "Maximum 50 symbols")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Enter your Surname")]
        [StringLength(50, ErrorMessage = "Maximum 50 symbols")]
        public string LastName { get; set; }
    }
}
