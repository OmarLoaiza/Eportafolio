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
    public class CurriculumController : Controller
    {
        private oloaizaEntities db = new oloaizaEntities();

        // GET: Curriculum
        public ActionResult Index()
        {
            return View(db.Curriculum.ToList());
        }

        // GET: Curriculum/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Curriculum curriculum = db.Curriculum.Find(id);
            if (curriculum == null)
            {
                return HttpNotFound();
            }
            return View(curriculum);
        }

        // GET: Curriculum/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Curriculum/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Area,linkedin,website,Phone,Email,Skills,Tools")] Curriculum curriculum)
        {
            if (ModelState.IsValid)
            {
                db.Curriculum.Add(curriculum);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(curriculum);
        }

        // GET: Curriculum/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Curriculum curriculum = db.Curriculum.Find(id);
            if (curriculum == null)
            {
                return HttpNotFound();
            }
            return View(curriculum);
        }

        // POST: Curriculum/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Area,linkedin,website,Phone,Email,Skills,Tools")] Curriculum curriculum)
        {
            if (ModelState.IsValid)
            {
                db.Entry(curriculum).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(curriculum);
        }

        // GET: Curriculum/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Curriculum curriculum = db.Curriculum.Find(id);
            if (curriculum == null)
            {
                return HttpNotFound();
            }
            return View(curriculum);
        }

        // POST: Curriculum/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Curriculum curriculum = db.Curriculum.Find(id);
            db.Curriculum.Remove(curriculum);
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
