using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using project5.Models;


namespace projec6.Controllers
{
    public class HomeController : Controller
    {

        footwear_db db = new footwear_db();
        public ActionResult Index()
        {
            var New_products = (from p in db.Products where p.Status == true orderby p.Createtime descending select p).Take(8).ToList() ;
           
            return View(New_products);
            
        }
        public ActionResult Seach(string character)
        {

            var New_products = from p in db.Products where p.Status == true where p.Name.Contains(character) orderby p.Createtime descending select p;
            ViewBag.seach = character;
            ViewBag.count = New_products.Count();
            return View(New_products);
        }

    }
}