using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PortfolioWebApp.Data;
using PortfolioWebApp.Models;
using static PortfolioWebApp.Extensions.SD;

namespace PortfolioWebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        [Authorize(Roles = "SuperAdmin,Admin")]
        [HttpGet]        
        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Registration(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser()
                {
                    FirstName = model.Firstname,
                    LastName = model.Lastname,
                    UserName = model.Username,
                    Email = model.Email
                };

                IdentityResult result = await _userManager.CreateAsync(user, model.Password);

                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }

                    return View(model);
                }
                await _userManager.AddToRoleAsync(user, Roles.Admin.ToString());

                await _signInManager.SignInAsync(user, true);

                return Redirect("/Account/Login");

            }

            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var data = await _userManager.FindByEmailAsync(model.Email);
                if (data == null)
                {
                    ModelState.AddModelError("", "Email address or password is incorrect");
                    return View();
                }

                var result = await _signInManager.PasswordSignInAsync(data, model.Password, model.RememberMe, false);
                if (!result.Succeeded)
                {
                    ModelState.AddModelError("", "Email address or password is incorrect");
                    return View(model);
                }
                return RedirectToAction("Index", "Post", new { area = "Admin" });

            }
        }

    }
}