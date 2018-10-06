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
    public class StudentController : Controller
    {
        private BITCollege_BGContext db = new BITCollege_BGContext();

        //
        // GET: /Student/

        public ActionResult Index()
        {
            var students = db.Students.Include(s => s.GPAState).Include(s => s.Program);
            return View(students.ToList());
        }

        //
        // GET: /Student/Details/5

        public ActionResult Details(int id = 0)
        {
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        //
        // GET: /Student/Create

        public ActionResult Create()
        {
            ViewBag.GPAStateId = new SelectList(db.GPAStates, "GPAStateId", "Description");
            ViewBag.ProgramId = new SelectList(db.Programs, "ProgramId", "Description");
            return View();
        }

        //
        // POST: /Student/Create

        [HttpPost]
        public ActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                db.Students.Add(student);
                student.changeState();
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GPAStateId = new SelectList(db.GPAStates, "GPAStateId", "Description", student.GPAStateId);
            ViewBag.ProgramId = new SelectList(db.Programs, "ProgramId", "Description");
            return View(student);
        }

        //
        // GET: /Student/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            ViewBag.GPAStateId = new SelectList(db.GPAStates, "GPAStateId", "Description", student.GPAStateId);
            ViewBag.ProgramId = new SelectList(db.Programs, "ProgramId", "Description");
            return View(student);
        }

        //
        // POST: /Student/Edit/5

        [HttpPost]
        public ActionResult Edit(Student student)
        {
            student.setNextStudentNumber();
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                student.changeState();
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GPAStateId = new SelectList(db.GPAStates, "GPAStateId", "GPAStateId", student.GPAStateId);
            ViewBag.ProgramId = new SelectList(db.Programs, "ProgramId", "Description");
            return View(student);
        }

        //
        // GET: /Student/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        //
        // POST: /Student/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = db.Students.Find(id);
            db.Students.Remove(student);
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