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
    public class SuspendedStateController : Controller
    {
        private BITCollege_BGContext db = new BITCollege_BGContext();

        //
        // GET: /SuspendedState/

        public ActionResult Index()
        {
            return View(SuspendedState.getInstance());
        }

        //
        // GET: /SuspendedState/Details/5

        public ActionResult Details(int id = 0)
        {
            SuspendedState suspendedstate = (SuspendedState)db.GPAStates.Find(id);
            if (suspendedstate == null)
            {
                return HttpNotFound();
            }
            return View(suspendedstate);
        }

        //
        // GET: /SuspendedState/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /SuspendedState/Create

        [HttpPost]
        public ActionResult Create(SuspendedState suspendedstate)
        {
            if (ModelState.IsValid)
            {
                db.GPAStates.Add(suspendedstate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(suspendedstate);
        }

        //
        // GET: /SuspendedState/Edit/5

        public ActionResult Edit(int id = 0)
        {
            SuspendedState suspendedstate = (SuspendedState)db.GPAStates.Find(id);
            if (suspendedstate == null)
            {
                return HttpNotFound();
            }
            return View(suspendedstate);
        }

        //
        // POST: /SuspendedState/Edit/5

        [HttpPost]
        public ActionResult Edit(SuspendedState suspendedstate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(suspendedstate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(suspendedstate);
        }

        //
        // GET: /SuspendedState/Delete/5

        public ActionResult Delete(int id = 0)
        {
            SuspendedState suspendedstate = (SuspendedState)db.GPAStates.Find(id);
            if (suspendedstate == null)
            {
                return HttpNotFound();
            }
            return View(suspendedstate);
        }

        //
        // POST: /SuspendedState/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            SuspendedState suspendedstate = (SuspendedState)db.GPAStates.Find(id);
            db.GPAStates.Remove(suspendedstate);
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