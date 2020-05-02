using Microsoft.AspNetCore.Mvc.Rendering;
using PortfolioWebApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioWebApp.Models
{
    public class SelectListItemViewModel
    {
        public List<SelectListItem> SelectListCategory { get; set; }
        public Category Category { get; set; }
    }
}
