using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioWebApp.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Enter your user name")]
        [StringLength(150)]
        [Display(Name = "User Name")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Enter your first name")]
        [StringLength(20)]
        [Display(Name = "First Name")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Enter your last name")]
        [StringLength(20)]
        [Display(Name = "Last Name")]
        public string Lastname { get; set; }

        [Required(ErrorMessage = "Enter your password")]
        [StringLength(150), DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm password")]
        [StringLength(150), DataType(DataType.Password), Compare(nameof(Password))]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Enter your email")]
        [StringLength(80), EmailAddress, DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
