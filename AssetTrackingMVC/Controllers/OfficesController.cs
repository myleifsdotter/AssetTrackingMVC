using AssetTrackingMVC.Data;
using AssetTrackingMVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AssetTrackingMVC.Controllers
{
    public class OfficesController : Controller
    {
        ApplicationDbContext Context;
        public OfficesController(ApplicationDbContext context)
        {
            Context = context;
        }

        [Authorize]
        public IActionResult Index()
        {
            ViewData["OfficeInfo"] = "Here you can find info about our offices.";
            var officeList = Context.Offices.ToList();
            return View(officeList);
        }

        [Authorize(Roles = "admin")]
        public IActionResult AddOffice() // GET function
        {
            ViewData["NewOfficeInfo"] = "If the new office has a new currency, it must be added to the local currencies in Asset.LocalPriceToday()";
            return View();
        }

        [HttpPost]
        public IActionResult AddOffice(string country, string currency) 
        {
            Office office = new Office();
            office.Country = country;
            office.Currency = currency;
            Context.Offices.Add(office);
            Context.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize]
        public IActionResult Details(int? id)
        {
            Office office = Context.Offices.Include(x => x.Address).FirstOrDefault(x => x.Id == id);
            return View(office);
        }

        [Authorize]
        public IActionResult OfficeAssets(int id)
        {
            Office office = Context.Offices.Include(x => x.Assets).FirstOrDefault(x => x.Id == id);
            return View(office);
        }

        [Authorize(Roles = "admin")]
        public IActionResult DeleteOffice(int? id)
        {
            Office office = Context.Offices.FirstOrDefault(x => x.Id == id);
            return View(office);
        }

        [HttpPost]
        public IActionResult DeleteTheOffice(int? id)
        {
            Office office = Context.Offices.FirstOrDefault(x => x.Id == id);
            Context.Remove(office);
            Context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
