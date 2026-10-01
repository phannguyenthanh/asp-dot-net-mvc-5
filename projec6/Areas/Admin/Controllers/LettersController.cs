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
    public class LettersController : Controller
    {
        private footwear_db db = new footwear_db();

        // GET: Admin/Letters
        public ActionResult Index()
        {
            return View(db.Letters.ToList());
        }

        // GET: Admin/Letters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Letter letter = db.Letters.Find(id);
            if (letter == null)
            {
                return HttpNotFound();
            }
            return View(letter);
        }

        // GET: Admin/Letters/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        // POST: Admin/Letters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,IdUser,First_name,Last_name,Email,Address,Phone,Textcontent,Title,Status,Createtime")] Letter letter)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Letters.Add(letter);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(letter);
        //}

        // GET: Admin/Letters/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Letter letter = db.Letters.Find(id);
        //    if (letter == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(letter);
        //}

        // POST: Admin/Letters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,IdUser,First_name,Last_name,Email,Address,Phone,Textcontent,Title,Status,Createtime")] Letter letter)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(letter).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(letter);
        //}

        // GET: Admin/Letters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Letter letter = db.Letters.Find(id);
            if (letter == null)
            {
                return HttpNotFound();
            }
            return View(letter);
        }

        // POST: Admin/Letters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Letter letter = db.Letters.Find(id);
            db.Letters.Remove(letter);
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
