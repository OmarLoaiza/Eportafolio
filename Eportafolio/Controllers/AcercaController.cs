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
    public class AcercaController : Controller
    {
        private oloaizaEntities db = new oloaizaEntities();

        // GET: Acerca
        public ActionResult Index()
        {
            return View(db.Acerca.ToList());
        }

        // GET: Acerca/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Acerca acerca = db.Acerca.Find(id);
            if (acerca == null)
            {
                return HttpNotFound();
            }
            return View(acerca);
        }

        // GET: Acerca/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Acerca/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Acerca1")] Acerca acerca)
        {
            if (ModelState.IsValid)
            {
                db.Acerca.Add(acerca);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(acerca);
        }

        // GET: Acerca/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Acerca acerca = db.Acerca.Find(id);
            if (acerca == null)
            {
                return HttpNotFound();
            }
            return View(acerca);
        }

        // POST: Acerca/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Acerca1")] Acerca acerca)
        {
            if (ModelState.IsValid)
            {
                db.Entry(acerca).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(acerca);
        }

        // GET: Acerca/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Acerca acerca = db.Acerca.Find(id);
            if (acerca == null)
            {
                return HttpNotFound();
            }
            return View(acerca);
        }

        // POST: Acerca/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Acerca acerca = db.Acerca.Find(id);
            db.Acerca.Remove(acerca);
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
