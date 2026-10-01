using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using project5.Models;

namespace projec6.Controllers
{
    public class RegisterController : Controller
    {
        private footwear_db db = new footwear_db();

        // GET: Register
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        // GET: Register/Details/5
        public ActionResult Details()
        {
            
            if (Session["Id_web"] == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            int id = Convert.ToInt32(Session["Id_web"]);
            //User user = db.Users.Find(Session["Id_web"]);
            User user = (from u in db.Users where u.Id == id select u).First();
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Register/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Register/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,First_name,Last_name,Email,Passwold,Passwold2,Sex,Birthday,Phone,Address,Avatar,Access,Status,Createtime")] User user)
        {
            ModelState["Access"].Errors.Clear();
            //ModelState["Status"].Errors.Clear();
            user.Access = project5.Models.access.Thường;
            user.Status = true;
            if (ModelState.IsValid)
            {
                user.Createtime = DateTime.Now;
                
                db.Users.Add(user);
                db.SaveChanges();
                Session["First_name_web"] = user.First_name.ToString();
                Session["Lats_name_web"] = user.Last_name.ToString();
                Session["Id_web"] = user.Id.ToString();
                Session["Avatar_web"] = user.Avatar.ToString();
                Session["Email_web"] = user.Email.ToString();
                return RedirectToAction("Index","Home");
            }

            return View(user);
        }

        // GET: Register/Edit/5
        public ActionResult Edit()
        {
            if (Session["id_web"] == null)
            {
                
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            int id = Convert.ToInt32(Session["id_web"]);
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return RedirectToAction("Index","Home");
        }

        // POST: Register/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,First_name,Last_name,Email,Passwold,Passwold2,Sex,Birthday,Phone,Address,Avatar,Access,Status,Createtime")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: Register/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Register/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
