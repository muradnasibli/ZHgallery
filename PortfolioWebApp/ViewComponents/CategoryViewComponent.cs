using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PortfolioWebApp.Data;
using PortfolioWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioWebApp.ViewComponents
{
    public class CategoryViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _db;

        public CategoryViewComponent(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            SelectListItemViewModel selectList = new SelectListItemViewModel
            {
                SelectListCategory = await _db.Categories.Select(d => new SelectListItem
                {
                    Text = d.Name.ToString(),
                    Value = d.Id.ToString()
                }).ToListAsync(),
            };
            return View(selectList);
        }

    }
}
