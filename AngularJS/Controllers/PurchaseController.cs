using AngularJS.Models;
using AngularJS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace AngularJS.Controllers
{
    public class PurchaseController : Controller
    {
        private AngularJSEntities _dbContext = new AngularJSEntities();
        // GET: Purchase
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult GetMaterials()
        {
            List<Material> materials = _dbContext.Materials.ToList();
            return Json(materials, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Insert(PurchaseViewModel purchaseViewModel)
        {
            var purchase = new Purchase()
            {
                PurchaseId = Guid.NewGuid(),
                PurchaseDate = purchaseViewModel.PurchaseDate,
                PurchaseStatus = purchaseViewModel.PurchaseStatus
            };
            _dbContext.Purchases.Add(purchase);

            foreach(var item in purchaseViewModel.PurchaseItems)
            {
                var purchaseItem = new PurchaseItem()
                {
                    PurchaseId = purchase.PurchaseId,
                    PurchaseItemId = Guid.NewGuid(),
                    MaterialId = item.MaterialId,
                    UnitPrice = item.UnitPrice,
                    Quantity = item.Quantity,
                    Tax = item.Tax
                };
                _dbContext.PurchaseItems.Add(purchaseItem);
            }
            _dbContext.SaveChanges();
            return View();
        }
    }
}