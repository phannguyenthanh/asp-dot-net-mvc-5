using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using project5.Models;

namespace projec6.Controllers.Login
{
    public class loginwepController : Controller
    {
        //footwear_db db = new footwear_db();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Check_login(User user)
        {

            using (footwear_db db = new footwear_db())
            {

                var obj = db.Users.Where(a => a.Email.Equals(user.Email) && a.Passwold.Equals(user.Passwold) && a.Access == 0).FirstOrDefault();
                if (obj != null)
                {
                    Session.Remove("First_name_web");
                    Session.Remove("Lats_name_web");
                    Session.Remove("Id_web");
                    Session.Remove("Avatar_web");
                    Session.Remove("Email_web");
                    Session["First_name_web"] = obj.First_name.ToString();
                    Session["Lats_name_web"] = obj.Last_name.ToString();
                    Session["Id_web"] = obj.Id.ToString();
                    Session["Avatar_web"] = obj.Avatar.ToString();
                    Session["Email_web"] = obj.Email.ToString();

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Thông tin tài khoản hoặc mật khẩu không chính xác!");
                    ViewBag.error = "Thông tin tài khoản hoặc mật khẩu không chính xác !";

                    ViewBag.t = "1";
                    return View("Index");
                }
            }


        }
        public ActionResult Logout()
        {
            Session.RemoveAll();

            return RedirectToAction("Index", "Home");
        }
    }
}