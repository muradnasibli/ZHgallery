using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PortfolioWebApp.Data;

namespace PortfolioWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManger;
        public AccountController(SignInManager<ApplicationUser> signInManager)
        {
            _signInManger = signInManager;
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManger.SignOutAsync();
            return Redirect("/Account/Login");
        }
    }
}