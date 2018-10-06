using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BITCollege_BG.Models;

namespace BITCollege_BG.Controllers
{
    public class NextRegistrationNumberController : Controller
    {
        private BITCollege_BGContext db = new BITCollege_BGContext();

        //
        // GET: /NextRegistrationNumber/

        public ActionResult Index()
        {
            return View(NextRegistrationNumber.GetInstance());
        }

        //
        // GET: /NextRegistrationNumber/Details/5

        public ActionResult Details(int id = 0)
        {
            NextRegistrationNumber nextregistrationnumber = db.NextRegistrationNumbers.Find(id);
            if (nextregistrationnumber == null)
            {
                return HttpNotFound();
            }
            return View(nextregistrationnumber);
        }

        //
        // GET: /NextRegistrationNumber/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /NextRegistrationNumber/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NextRegistrationNumber nextregistrationnumber)
        {
            if (ModelState.IsValid)
            {
                db.NextRegistrationNumbers.Add(nextregistrationnumber);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nextregistrationnumber);
        }

        //
        // GET: /NextRegistrationNumber/Edit/5

        public ActionResult Edit(int id = 0)
        {
            NextRegistrationNumber nextregistrationnumber = db.NextRegistrationNumbers.Find(id);
            if (nextregistrationnumber == null)
            {
                return HttpNotFound();
            }
            return View(nextregistrationnumber);
        }

        //
        // POST: /NextRegistrationNumber/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(NextRegistrationNumber nextregistrationnumber)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nextregistrationnumber).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nextregistrationnumber);
        }

        //
        // GET: /NextRegistrationNumber/Delete/5

        public ActionResult Delete(int id = 0)
        {
            NextRegistrationNumber nextregistrationnumber = db.NextRegistrationNumbers.Find(id);
            if (nextregistrationnumber == null)
            {
                return HttpNotFound();
            }
            return View(nextregistrationnumber);
        }

        //
        // POST: /NextRegistrationNumber/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NextRegistrationNumber nextregistrationnumber = db.NextRegistrationNumbers.Find(id);
            db.NextRegistrationNumbers.Remove(nextregistrationnumber);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}