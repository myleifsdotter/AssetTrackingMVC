using AssetTrackingMVC.Data;
using AssetTrackingMVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AssetTrackingMVC.Controllers
{
    public class AddressesController : Controller
    {
        ApplicationDbContext Context;
        public AddressesController(ApplicationDbContext context)
        {
            Context = context;
        }

        [Authorize]
        public IActionResult Index()
        {
            ViewData["AddressInfo"] = "Address information viewdata. ";
            var addressList = Context.Addresses.ToList();
            return View(addressList);
        }

        [Authorize(Roles = "admin")]
        public IActionResult AddAddress() // GET function
        {
            //ViewData["OfficeId"] = new SelectList(Context.Offices, "Id", "Country");
            return View();
        }

        [HttpPost]
        public IActionResult AddAddress(string streetname, string housenumber, string postalcode, string city, string country, string phonenumber)
        {
            Address address = new Address();
            address.StreetName = streetname;
            address.HouseNumber = housenumber;
            address.PostalCode = postalcode;
            address.City = city;
            address.Country = country;
            address.PhoneNumber = phonenumber;
            Context.Addresses.Add(address);
            Context.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "admin")]
        public IActionResult EditAddress(int? id) //GET
        {
            //ViewData["AddressCountry"] = new SelectList(Context.Addresses, "Id", "Country");
            Address address = Context.Addresses.FirstOrDefault(x => x.Id == id);
            return View(address); // pass it to the form
        }

        [HttpPost]
        public IActionResult EditAddress(int id, string streetname, string housenumber, string postalcode, string city, string country, string phonenumber)
        {
            Address address = Context.Addresses.FirstOrDefault(x => x.Id == id);
            address.StreetName = streetname;
            address.HouseNumber = housenumber;
            address.PostalCode = postalcode;
            address.City = city;
            address.Country = country;
            address.PhoneNumber = phonenumber;
            Context.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "admin")]
        public IActionResult DeleteAddress(int? id)
        {
            Address address = Context.Addresses.FirstOrDefault(x => x.Id == id);
            return View(address);
        }

        [HttpPost]
        public IActionResult DeleteTheAddress(int? id)
        {
            Address address = Context.Addresses.FirstOrDefault(x => x.Id == id);
            Context.Remove(address);
            Context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
