using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioWebApp.Data
{
    public class Post : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
#nullable enable
        public string? FirstImageUrl { get; set; }
        public string? SecondImageUrl { get; set; }
        public string? ThirdImageUrl { get; set; }
        public string? FourthImageUrl { get; set; }
        public string? FifthImageUrl { get; set; }
        public string? SixthImageUrl { get; set; }
        //Relation between category
        public int? CategoryId { get; set; }
#nullable disable
        public Category Category { get; set; }

    }
}
