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

        //[Authorize(Roles = "admin")]
        public IActionResult AddOffice() // GET function
        {
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

        public IActionResult Details(int? id)
        {
            Office office = Context.Offices.FirstOrDefault(x => x.Id == id);
            return View(office);
        }

        public IActionResult OfficeAssets(int id)
        {
            Office office = Context.Offices.Include(x => x.Assets).FirstOrDefault(x => x.Id == id);
            return View(office);
        }
    }
}
