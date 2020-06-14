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
    
    public class TimController : Controller
    {
        private Model1 db = new Model1();

        // GET: Tim
        public ActionResult Index()
        {
            var tim = db.Tim.Include(t => t.Takmicenje);
            if (SessionData.IsAuthenticated && SessionData.IsAdmin)
            {
                return View(tim.ToList());
            }
            else
            {
                return View("../Home/Ekipa", tim.ToList());
            }

        }

        // GET: Tim/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tim tim = db.Tim.Find(id);
            if (tim == null)
            {
                return HttpNotFound();
            }
            return View(tim);
        }

        // GET: Tim/Create
        public ActionResult Create()
        {
            ViewBag.TakmicenjeID = new SelectList(db.Takmicenje, "TakmicenjeID", "Naziv");
            return View();
        }

        // POST: Tim/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TimID,TakmicenjeID,Naziv,BrojBodova")] Tim tim)
        {
            if (ModelState.IsValid)
            {
                db.Tim.Add(tim);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TakmicenjeID = new SelectList(db.Takmicenje, "TakmicenjeID", "Naziv", tim.TakmicenjeID);
            return View(tim);
        }

        // GET: Tim/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tim tim = db.Tim.Find(id);
            if (tim == null)
            {
                return HttpNotFound();
            }
            ViewBag.TakmicenjeID = new SelectList(db.Takmicenje, "TakmicenjeID", "Naziv", tim.TakmicenjeID);
            return View(tim);
        }

        // POST: Tim/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TimID,TakmicenjeID,Naziv,BrojBodova")] Tim tim)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tim).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TakmicenjeID = new SelectList(db.Takmicenje, "TakmicenjeID", "Naziv", tim.TakmicenjeID);
            return View(tim);
        }

        // GET: Tim/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tim tim = db.Tim.Find(id);
            if (tim == null)
            {
                return HttpNotFound();
            }
            return View(tim);
        }

        // POST: Tim/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tim tim = db.Tim.Find(id);
            db.Tim.Remove(tim);
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
