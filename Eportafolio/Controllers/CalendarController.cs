using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Eportafolio.Models;

namespace Eportafolio.Controllers
{
    public class CalendarController : Controller
    {
        private oloaizaEntities db = new oloaizaEntities();

        // GET: Calendar
        public ActionResult Index()
        {
            return View(db.Calendar.ToList());
        }

        // GET: Calendar/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Calendar calendar = db.Calendar.Find(id);
            if (calendar == null)
            {
                return HttpNotFound();
            }
            return View(calendar);
        }

        // GET: Calendar/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Calendar/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Description,StartDate,EndDate,Location")] Calendar calendar)
        {
            if (ModelState.IsValid)
            {
                db.Calendar.Add(calendar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(calendar);
        }

        // GET: Calendar/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Calendar calendar = db.Calendar.Find(id);
            if (calendar == null)
            {
                return HttpNotFound();
            }
            return View(calendar);
        }

        // POST: Calendar/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Description,StartDate,EndDate,Location")] Calendar calendar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(calendar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(calendar);
        }

        // GET: Calendar/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Calendar calendar = db.Calendar.Find(id);
            if (calendar == null)
            {
                return HttpNotFound();
            }
            return View(calendar);
        }

        // POST: Calendar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Calendar calendar = db.Calendar.Find(id);
            db.Calendar.Remove(calendar);
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
