using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SonOfCod.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace SonOfCod.Controllers
{
    public class NewsletterController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        public NewsletterController(UserManager<ApplicationUser> userManager, ApplicationDbContext db)
        {
            _userManager = userManager;
            _db = db;
        }
        public IActionResult Index()
        {
            List<SelectListItem> reasons = new List<SelectListItem>();
            reasons.Add(new SelectListItem() { Text = "Buy in bulk", Value = "Buy in bulk" });
            reasons.Add(new SelectListItem() { Text = "Household shopping", Value = "Household shopping" });
            reasons.Add(new SelectListItem() { Text = "Stock restaurant", Value = "Stock restaurant" });
            reasons.Add(new SelectListItem() { Text = "Looking for deals", Value = "Looking for deals" });
            reasons.Add(new SelectListItem() { Text = "Wider variety of seafood", Value = "Wider variety of seafood" });
            reasons.Add(new SelectListItem() { Text = "Online shopping convenience", Value = "Online shopping convenience" });
            ViewBag.Reasons = reasons;
            ViewBag.Visitors = _db.Visitors.ToList();
            return View();
        }
    }
}
