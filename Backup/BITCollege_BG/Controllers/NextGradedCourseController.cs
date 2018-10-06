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
    public class NextGradedCourseController : Controller
    {
        private BITCollege_BGContext db = new BITCollege_BGContext();

        //
        // GET: /NextGradedCourse/

        public ActionResult Index()
        {
            return View(NextGradedCourse.GetInstance());
        }

        //
        // GET: /NextGradedCourse/Details/5

        public ActionResult Details(int id = 0)
        {
            NextGradedCourse nextgradedcourse = db.NextGradedCourses.Find(id);
            if (nextgradedcourse == null)
            {
                return HttpNotFound();
            }
            return View(nextgradedcourse);
        }

        //
        // GET: /NextGradedCourse/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /NextGradedCourse/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NextGradedCourse nextgradedcourse)
        {
            if (ModelState.IsValid)
            {
                db.NextGradedCourses.Add(nextgradedcourse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nextgradedcourse);
        }

        //
        // GET: /NextGradedCourse/Edit/5

        public ActionResult Edit(int id = 0)
        {
            NextGradedCourse nextgradedcourse = db.NextGradedCourses.Find(id);
            if (nextgradedcourse == null)
            {
                return HttpNotFound();
            }
            return View(nextgradedcourse);
        }

        //
        // POST: /NextGradedCourse/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(NextGradedCourse nextgradedcourse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nextgradedcourse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nextgradedcourse);
        }

        //
        // GET: /NextGradedCourse/Delete/5

        public ActionResult Delete(int id = 0)
        {
            NextGradedCourse nextgradedcourse = db.NextGradedCourses.Find(id);
            if (nextgradedcourse == null)
            {
                return HttpNotFound();
            }
            return View(nextgradedcourse);
        }

        //
        // POST: /NextGradedCourse/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NextGradedCourse nextgradedcourse = db.NextGradedCourses.Find(id);
            db.NextGradedCourses.Remove(nextgradedcourse);
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