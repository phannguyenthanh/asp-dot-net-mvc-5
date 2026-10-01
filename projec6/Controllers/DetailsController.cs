using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using project5.Models;

namespace projec6.Controllers
{
    public class DetailsController : Controller
    {
        footwear_db db = new footwear_db();
        public int? Pro_category;
        // GET: Details
        public ActionResult Index(int? id)
        {
            //var detailpr = db.Products.Where(p => p.Id == id ).SingleOrDefault();

            //return View();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            int? count = product._View;
            if(count == null)
            {
                product._View = 1;
            }
            else
            {
                product._View = count + 1;
            }
            //int? count = product._View;
            
            
            db.Entry(product).State = EntityState.Modified;
            db.SaveChanges();
           
            return View(product);
        }
        public PartialViewResult pro_category(int id , int produc)
        {
            int? idca = Pro_category;
            var product = (from p in db.Products where p.IdCategory == id where p.Id != produc where p.Status == true select p).Take(3);
            //var a = Pro_category;
            return PartialView(product);
        }
        public PartialViewResult Category()
        {
            var category = from c in db.Categories where c.Status == true select c;
            return PartialView(category);
        }
        public PartialViewResult best_sellers()
        {
            var product = (from p in db.Products where p.Status == true orderby p._View descending  select p).Take(4);

            return PartialView(product);
        }
    }
}