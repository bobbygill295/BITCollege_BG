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
    public class ProbationStateController : Controller
    {
        private BITCollege_BGContext db = new BITCollege_BGContext();

        //
        // GET: /ProbationState/

        public ActionResult Index()
        {
            return View(ProbationState.GetInstance());
        }

        //
        // GET: /ProbationState/Details/5

        public ActionResult Details(int id = 0)
        {
            ProbationState probationstate = db.ProbationStates.Find(id);
            if (probationstate == null)
            {
                return HttpNotFound();
            }
            return View(probationstate);
        }

        //
        // GET: /ProbationState/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /ProbationState/Create

        [HttpPost]
        public ActionResult Create(ProbationState probationstate)
        {
            if (ModelState.IsValid)
            {
                db.GPAStates.Add(probationstate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(probationstate);
        }

        //
        // GET: /ProbationState/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ProbationState probationstate = (ProbationState)db.GPAStates.Find(id);
            if (probationstate == null)
            {
                return HttpNotFound();
            }
            return View(probationstate);
        }

        //
        // POST: /ProbationState/Edit/5

        [HttpPost]
        public ActionResult Edit(ProbationState probationstate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(probationstate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(probationstate);
        }

        //
        // GET: /ProbationState/Delete/5

        public ActionResult Delete(int id = 0)
        {
            ProbationState probationstate = (ProbationState)db.GPAStates.Find(id);
            if (probationstate == null)
            {
                return HttpNotFound();
            }
            return View(probationstate);
        }

        //
        // POST: /ProbationState/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            ProbationState probationstate = (ProbationState)db.GPAStates.Find(id);
            db.GPAStates.Remove(probationstate);
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