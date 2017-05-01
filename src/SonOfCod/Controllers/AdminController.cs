using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using SonOfCod.Models;
using SonOfCod.ViewModels;

namespace SonOfCod.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AdminController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ApplicationDbContext db)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _db = db;
        }
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.User = _db.Users.FirstOrDefault(users => users.UserName == User.Identity.Name);
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(AdminRegisterViewModel model)
        {
            var admin = new ApplicationUser { UserName = model.Email };
            IdentityResult result = await _userManager.CreateAsync(admin, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("Login");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(AdminLoginViewModel model)
        {
            Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, isPersistent: true, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
    }
}
