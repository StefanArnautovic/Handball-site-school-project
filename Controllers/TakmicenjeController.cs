using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using STEF.Models;

namespace STEF.Controllers
{
    public class TakmicenjeController : Controller
    {
        private Model1 db = new Model1();

        // GET: Takmicenje
        public ActionResult Index()
        {
            return View(db.Takmicenje.ToList());
        }

        // GET: Takmicenje/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Takmicenje takmicenje = db.Takmicenje.Find(id);
            if (takmicenje == null)
            {
                return HttpNotFound();
            }
            return View(takmicenje);
        }

        // GET: Takmicenje/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Takmicenje/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TakmicenjeID,Naziv,Grupa")] Takmicenje takmicenje)
        {
            if (ModelState.IsValid)
            {
                db.Takmicenje.Add(takmicenje);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(takmicenje);
        }

        // GET: Takmicenje/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Takmicenje takmicenje = db.Takmicenje.Find(id);
            if (takmicenje == null)
            {
                return HttpNotFound();
            }
            return View(takmicenje);
        }

        // POST: Takmicenje/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TakmicenjeID,Naziv,Grupa")] Takmicenje takmicenje)
        {
            if (ModelState.IsValid)
            {
                db.Entry(takmicenje).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(takmicenje);
        }

        // GET: Takmicenje/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Takmicenje takmicenje = db.Takmicenje.Find(id);
            if (takmicenje == null)
            {
                return HttpNotFound();
            }
            return View(takmicenje);
        }

        // POST: Takmicenje/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Takmicenje takmicenje = db.Takmicenje.Find(id);
            db.Takmicenje.Remove(takmicenje);
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
