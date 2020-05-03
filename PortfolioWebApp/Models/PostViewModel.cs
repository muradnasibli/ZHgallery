using Microsoft.AspNetCore.Http;
using PortfolioWebApp.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioWebApp.Models
{
    public class PostViewModel : BaseEntity
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter name...")]
        [StringLength(maximumLength: 150, ErrorMessage = "Please enter name correctly...")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter description...")]
        [Display(Name = "Description")]
        public string Title { get; set; }
#nullable enable
        public IFormFile? FirstImageUrl { get; set; }
        public IFormFile? SecondImageUrl { get; set; }
        public IFormFile? ThirdImageUrl { get; set; }
        public IFormFile? FourthImageUrl { get; set; }
        public IFormFile? FifthImageUrl { get; set; }
        public IFormFile? SixthImageUrl { get; set; }
        //Relation between category
        public int? CategoryId { get; set; }
#nullable disable
        public Category Category { get; set; }


    }
}
