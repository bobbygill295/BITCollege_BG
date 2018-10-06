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
    public class GradedCourseController : Controller
    {
        private BITCollege_BGContext db = new BITCollege_BGContext();

        //
        // GET: /GradedCourse/

        public ActionResult Index()
        {
            var courses = db.GradedCourses.Include(g => g.Program);
            return View(courses.ToList());
        }

        //
        // GET: /GradedCourse/Details/5

        public ActionResult Details(int id = 0)
        {
            GradedCourse gradedcourse = (GradedCourse)db.Courses.Find(id);
            if (gradedcourse == null)
            {
                return HttpNotFound();
            }
            return View(gradedcourse);
        }

        //
        // GET: /GradedCourse/Create

        public ActionResult Create()
        {
            ViewBag.ProgramId = new SelectList(db.Programs, "ProgramID", "ProgramAcronym");
            return View();
        }

        //
        // POST: /GradedCourse/Create

        [HttpPost]
        public ActionResult Create(GradedCourse gradedcourse)
        {
            gradedcourse.setNextCourseNumber();
            if (ModelState.IsValid)
            {
                db.Courses.Add(gradedcourse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProgramId = new SelectList(db.Programs, "ProgramID", "ProgramAcronym", gradedcourse.ProgramId);
            return View(gradedcourse);
        }

        //
        // GET: /GradedCourse/Edit/5

        public ActionResult Edit(int id = 0)
        {
            GradedCourse gradedcourse = (GradedCourse)db.Courses.Find(id);
            if (gradedcourse == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProgramId = new SelectList(db.Programs, "ProgramID", "ProgramAcronym", gradedcourse.ProgramId);
            return View(gradedcourse);
        }

        //
        // POST: /GradedCourse/Edit/5

        [HttpPost]
        public ActionResult Edit(GradedCourse gradedcourse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gradedcourse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProgramId = new SelectList(db.Programs, "ProgramID", "ProgramAcronym", gradedcourse.ProgramId);
            return View(gradedcourse);
        }

        //
        // GET: /GradedCourse/Delete/5

        public ActionResult Delete(int id = 0)
        {
            GradedCourse gradedcourse = (GradedCourse)db.Courses.Find(id);
            if (gradedcourse == null)
            {
                return HttpNotFound();
            }
            return View(gradedcourse);
        }

        //
        // POST: /GradedCourse/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            GradedCourse gradedcourse = (GradedCourse)db.Courses.Find(id);
            db.Courses.Remove(gradedcourse);
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