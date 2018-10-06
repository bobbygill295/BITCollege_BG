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
    public class NextStudentNumberController : Controller
    {
        private BITCollege_BGContext db = new BITCollege_BGContext();

        //
        // GET: /NextStudentNumber/

        public ActionResult Index()
        {
            return View(NextStudentNumber.GetInstance());
        }

        //
        // GET: /NextStudentNumber/Details/5

        public ActionResult Details(int id = 0)
        {
            NextStudentNumber nextstudentnumber = db.NextStudentNumbers.Find(id);
            if (nextstudentnumber == null)
            {
                return HttpNotFound();
            }
            return View(nextstudentnumber);
        }

        //
        // GET: /NextStudentNumber/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /NextStudentNumber/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NextStudentNumber nextstudentnumber)
        {
            if (ModelState.IsValid)
            {
                db.NextStudentNumbers.Add(nextstudentnumber);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nextstudentnumber);
        }

        //
        // GET: /NextStudentNumber/Edit/5

        public ActionResult Edit(int id = 0)
        {
            NextStudentNumber nextstudentnumber = db.NextStudentNumbers.Find(id);
            if (nextstudentnumber == null)
            {
                return HttpNotFound();
            }
            return View(nextstudentnumber);
        }

        //
        // POST: /NextStudentNumber/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(NextStudentNumber nextstudentnumber)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nextstudentnumber).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nextstudentnumber);
        }

        //
        // GET: /NextStudentNumber/Delete/5

        public ActionResult Delete(int id = 0)
        {
            NextStudentNumber nextstudentnumber = db.NextStudentNumbers.Find(id);
            if (nextstudentnumber == null)
            {
                return HttpNotFound();
            }
            return View(nextstudentnumber);
        }

        //
        // POST: /NextStudentNumber/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NextStudentNumber nextstudentnumber = db.NextStudentNumbers.Find(id);
            db.NextStudentNumbers.Remove(nextstudentnumber);
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