using AssetTrackingMVC.Data;
using AssetTrackingMVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AssetTrackingMVC.Controllers
{
    public class AssetsController : Controller
    {
        ApplicationDbContext Context;
        public AssetsController(ApplicationDbContext context)
        {
            Context = context;
        }

        [Authorize]
        public IActionResult Index()
        {
            ViewData["AssetInfo"] = "Here you can find info about your assets";
            var assetList = Context.Assets.Include(x => x.Office).ToList();
            return View(assetList);
        }

        [Authorize(Roles = "admin")]
        public IActionResult AddAsset() // GET function
        {
            ViewData["OfficeId"] = new SelectList(Context.Offices, "Id", "Country");
            return View();
        }

        [HttpPost]
        public IActionResult AddAsset(string type, string brand, string model, int officeid, DateTime purchasedate, double price)
        {
            Asset asset = new Asset();
            asset.Type = type;
            asset.Brand = brand;
            asset.Model = model;
            asset.OfficeId = officeid;
            asset.PurchaseDate = purchasedate;
            asset.Price = Convert.ToDouble(price);
            Context.Assets.Add(asset);
            Context.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "admin")]
        public IActionResult EditAsset(int? id) //GET
        {
            ViewData["OfficeId"] = new SelectList(Context.Offices, "Id", "Country");
            Asset asset = Context.Assets.FirstOrDefault(x => x.Id == id);
            return View(asset); // pass it to the form
        }

        [HttpPost]
        public IActionResult EditAsset(int id, string type, string brand, string model, int officeid, DateTime purchasedate, double price)
        {
            Asset asset = Context.Assets.FirstOrDefault(x => x.Id == id);
            asset.Type = type;
            asset.Brand = brand;
            asset.Model = model;
            asset.OfficeId = officeid;
            asset.PurchaseDate = purchasedate;
            asset.Price = Convert.ToDouble(price);
            Context.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "admin")]
        public IActionResult DeleteAsset(int? id)
        {
            Asset asset = Context.Assets.Include(x => x.Office).FirstOrDefault(x => x.Id == id);
            return View(asset);
        }

        [HttpPost]
        public IActionResult DeleteTheAsset(int? id)
        {
            Asset asset = Context.Assets.FirstOrDefault(x => x.Id == id);
            Context.Remove(asset);
            Context.SaveChanges();
            return RedirectToAction("Index");
        }

        
    }
}
