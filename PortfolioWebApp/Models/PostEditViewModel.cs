using Microsoft.AspNetCore.Mvc.Rendering;
using PortfolioWebApp.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioWebApp.Models
{
    public class PostEditViewModel : BaseEntity
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter name...")]
        [StringLength(maximumLength: 150, ErrorMessage = "Please enter name correctly...")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter description...")]        
        [Display(Name = "Description")]
        public string Title { get; set; }
#nullable enable
        public string? FirstImageUrl { get; set; }
        public string? SecondImageUrl { get; set; }
        public string? ThirdImageUrl { get; set; }
        public string? FourthImageUrl { get; set; }
        public string? FifthImageUrl { get; set; }
        public string? SixthImageUrl { get; set; }
        public int? CategoryId { get; set; }
#nullable disable
        public Category Category { get; set; }

    }
}
