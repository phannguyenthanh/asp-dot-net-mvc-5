using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using project5.Models;


namespace projec6.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        footwear_db db = new footwear_db();
        // GET: Admin/Login
        public ActionResult Index()
        {
            var bg = db.Users.Where(a => a.Email.Equals("admin@gmail.com")).FirstOrDefault();
            if (bg == null)
            {


                User u = new User();
                u.First_name = "System";
                u.Last_name = "Admin";
                u.Email = "admin@gmail.com";
                u.Passwold = "123456";
                u.Passwold2 = "123456";
                u.Phone = "0901234567";
                u.Address = "Ha Noi";
                u.Avatar = "/images/images/Users/avatar-dep-nhat-2_112147.jpg";
                u.Birthday = DateTime.Parse("01/01/1995");  
                u.Sex = 0;
                u.Access = 0;
                u.Status = true;
                u.Createtime = DateTime.Now;
                db.Users.Add(u);
                db.SaveChanges();

            }
          
           
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Clogin(User user)
        {
            
                using (footwear_db db = new footwear_db())
                {

                    var obj = db.Users.Where(a => a.Email.Equals(user.Email) && a.Passwold.Equals(user.Passwold) && a.Access == 0).FirstOrDefault();
                    if (obj!= null)
                    {
                        Session["First_name"] = obj.First_name.ToString();
                        Session["Lats_name"] = obj.Last_name.ToString();
                        Session["Id"] = obj.Id.ToString();
                        Session["Avatar"] = obj.Avatar.ToString();
                        Session["Email"] = obj.Email.ToString();

                    return RedirectToAction("Index", "Products");
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
        public ActionResult Sign_Out()
        {
            Session.RemoveAll();

            return RedirectToAction("Index", "Login");
        }     
        public ActionResult CheckEmail(String Email, int? Id = null)
        {
            
            
                var bg = db.Users.Where(a => a.Email.Equals(Email) && a.Id != Id).FirstOrDefault(); 
                //return Json(!db.Users.Any(x => x.Email == Email), JsonRequestBehavior.AllowGet);
                if (bg == null)
                {


                    return Content("true");
                    
                }
              
                else
                {
                    return Content("false");
                }
            
        }
    }
}