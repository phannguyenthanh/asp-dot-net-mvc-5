using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using project5.Models;

namespace projec6.Controllers
{
    
    public class CategoryController : Controller
    {
        footwear_db db = new footwear_db();
        // GET: Category
        public ActionResult Index(int Id)
        {
            var products = from p in db.Products where p.Status == true where p.IdCategory == Id select p;
            string productCa = db.Categories.Where(c => c.Id.Equals(Id)).FirstOrDefault().Name.ToString();
            ViewBag.Title = productCa;

            return View(products);
        }
    }
}