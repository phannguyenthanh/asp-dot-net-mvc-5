using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using project5.Models;

namespace projec6.Controllers.Block
{
    public class MenuController : Controller
    {
        footwear_db db = new footwear_db();
        // GET: menu
        public PartialViewResult Menu()
        {

            var category = from c in db.Categories where c.Status  == true   select c;
            return PartialView(category);
        }
    }
}