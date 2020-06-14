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
    public class PorukaController : Controller
    {
        private Model1 db = new Model1();

        // GET: Poruka
        public ActionResult Index()
        {
            var poruka = db.Poruka.Include(p => p.Korisnik);
            return View(poruka.ToList());
        }

        // GET: Poruka/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Poruka poruka = db.Poruka.Find(id);
            if (poruka == null)
            {
                return HttpNotFound();
            }
            return View(poruka);
        }

        // GET: Poruka/Create
        public ActionResult Create()
        {
            ViewBag.KorisnikID = new SelectList(db.Korisnik, "KorisnikID", "Ime");
            return View();
        }

        // POST: Poruka/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PorukaID,KorisnikID,Sadrzaj,Datum")] Poruka poruka)
        {
            if (ModelState.IsValid)
            {
                db.Poruka.Add(poruka);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KorisnikID = new SelectList(db.Korisnik, "KorisnikID", "Ime", poruka.KorisnikID);
            return View(poruka);
        }

        // GET: Poruka/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Poruka poruka = db.Poruka.Find(id);
            if (poruka == null)
            {
                return HttpNotFound();
            }
            ViewBag.KorisnikID = new SelectList(db.Korisnik, "KorisnikID", "Ime", poruka.KorisnikID);
            return View(poruka);
        }

        // POST: Poruka/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PorukaID,KorisnikID,Sadrzaj,Datum")] Poruka poruka)
        {
            if (ModelState.IsValid)
            {
                db.Entry(poruka).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KorisnikID = new SelectList(db.Korisnik, "KorisnikID", "Ime", poruka.KorisnikID);
            return View(poruka);
        }

        // GET: Poruka/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Poruka poruka = db.Poruka.Find(id);
            if (poruka == null)
            {
                return HttpNotFound();
            }
            return View(poruka);
        }

        // POST: Poruka/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Poruka poruka = db.Poruka.Find(id);
            db.Poruka.Remove(poruka);
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
