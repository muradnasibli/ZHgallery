using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioWebApp.Models
{
    public class AboutOwnerViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter title about company...")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Please enter description about company...")]
        public string Description { get; set; }
#nullable enable
        [DisplayName("Company Photo")]
        public IFormFile? CompanyPhoto { get; set; }
    }
}
