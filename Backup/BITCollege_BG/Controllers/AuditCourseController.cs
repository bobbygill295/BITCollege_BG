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
    public class AuditCourseController : Controller
    {
        private BITCollege_BGContext db = new BITCollege_BGContext();

        //
        // GET: /AuditCourse/

        public ActionResult Index()
        {
            var courses = db.AuditCourses.Include(a => a.Program);
            return View(courses.ToList());
        }

        //
        // GET: /AuditCourse/Details/5

        public ActionResult Details(int id = 0)
        {
            AuditCourse auditcourse = (AuditCourse)db.Courses.Find(id);
            if (auditcourse == null)
            {
                return HttpNotFound();
            }
            return View(auditcourse);
        }

        //
        // GET: /AuditCourse/Create

        public ActionResult Create()
        {
            ViewBag.ProgramId = new SelectList(db.Programs, "ProgramID", "ProgramAcronym");
            return View();
        }

        //
        // POST: /AuditCourse/Create

        [HttpPost]
        public ActionResult Create(AuditCourse auditcourse)
        {
            auditcourse.setNextCourseNumber();
            if (ModelState.IsValid)
            {
                db.Courses.Add(auditcourse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProgramId = new SelectList(db.Programs, "ProgramID", "ProgramAcronym", auditcourse.ProgramId);
            return View(auditcourse);
        }

        //
        // GET: /AuditCourse/Edit/5

        public ActionResult Edit(int id = 0)
        {
            AuditCourse auditcourse = (AuditCourse)db.Courses.Find(id);
            if (auditcourse == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProgramId = new SelectList(db.Programs, "ProgramID", "ProgramAcronym", auditcourse.ProgramId);
            return View(auditcourse);
        }

        //
        // POST: /AuditCourse/Edit/5

        [HttpPost]
        public ActionResult Edit(AuditCourse auditcourse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(auditcourse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProgramId = new SelectList(db.Programs, "ProgramID", "ProgramAcronym", auditcourse.ProgramId);
            return View(auditcourse);
        }

        //
        // GET: /AuditCourse/Delete/5

        public ActionResult Delete(int id = 0)
        {
            AuditCourse auditcourse = (AuditCourse)db.Courses.Find(id);
            if (auditcourse == null)
            {
                return HttpNotFound();
            }
            return View(auditcourse);
        }

        //
        // POST: /AuditCourse/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            AuditCourse auditcourse = (AuditCourse)db.Courses.Find(id);
            db.Courses.Remove(auditcourse);
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