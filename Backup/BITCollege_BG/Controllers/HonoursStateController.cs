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
    public class HonoursStateController : Controller
    {
        private BITCollege_BGContext db = new BITCollege_BGContext();

        //
        // GET: /HonoursState/

        public ActionResult Index()
        {
            return View(HonoursState.getInstance());
        }

        //
        // GET: /HonoursState/Details/5

        public ActionResult Details(int id = 0)
        {
            HonoursState honoursstate = (HonoursState)db.GPAStates.Find(id);
            if (honoursstate == null)
            {
                return HttpNotFound();
            }
            return View(honoursstate);
        }

        //
        // GET: /HonoursState/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /HonoursState/Create

        [HttpPost]
        public ActionResult Create(HonoursState honoursstate)
        {
            if (ModelState.IsValid)
            {
                db.GPAStates.Add(honoursstate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(honoursstate);
        }

        //
        // GET: /HonoursState/Edit/5

        public ActionResult Edit(int id = 0)
        {
            HonoursState honoursstate = (HonoursState)db.GPAStates.Find(id);
            if (honoursstate == null)
            {
                return HttpNotFound();
            }
            return View(honoursstate);
        }

        //
        // POST: /HonoursState/Edit/5

        [HttpPost]
        public ActionResult Edit(HonoursState honoursstate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(honoursstate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(honoursstate);
        }

        //
        // GET: /HonoursState/Delete/5

        public ActionResult Delete(int id = 0)
        {
            HonoursState honoursstate = (HonoursState)db.GPAStates.Find(id);
            if (honoursstate == null)
            {
                return HttpNotFound();
            }
            return View(honoursstate);
        }

        //
        // POST: /HonoursState/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            HonoursState honoursstate = (HonoursState)db.GPAStates.Find(id);
            db.GPAStates.Remove(honoursstate);
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