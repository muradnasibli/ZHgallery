using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioWebApp.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Enter your email")]
        [StringLength(80), EmailAddress, DataType(DataType.EmailAddress)]        
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter your password")]
        [StringLength(150), DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
    }
}
