using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using STEF.Models;
using PagedList;

namespace STEF.Controllers
{
    public class IgracController : Controller
    {
        private Model1 db = new Model1();

        // GET: Igrac
        public ViewResult Index(string sortOrder, string search,string filter,int? page)
        {
            ViewBag.CurentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "Ime_desc" : "";
            ViewBag.DateSortParm = sortOrder == "GodinaRodjenja" ? "gr_desc" : "GodinaRodjenja";
            if (search != null)
            {
                page = 1;
            }
            else
            {
                search = filter;
            }
            ViewBag.CurentFilter = search;
            var igrac = from i in db.Igrac
                        select i;
            
            if (!String.IsNullOrEmpty(search))
            {
                igrac = igrac.Where(i => i.Ime.Contains(search) || i.Prezime.Contains(search)||i.Pozicija.Contains(search));
            }
            switch (sortOrder)
            {
                case "Ime_desc":
                    igrac = igrac.OrderByDescending(i => i.Ime);
                    break;
                case "GodinaRodjenja":
                    igrac = igrac.OrderBy(i => i.GodinaRodjenja);
                    break;
                case "gr_desc":
                    igrac = igrac.OrderByDescending(i => i.GodinaRodjenja);
                    break;
                default:
                    igrac = igrac.OrderBy(i => i.Ime);
                    break;
            }
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            
            return View(igrac.ToPagedList(pageNumber, pageSize));
        }

        // GET: Igrac/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Igrac igrac = db.Igrac.Find(id);
            if (igrac == null)
            {
                return HttpNotFound();
            }
            return View(igrac);
        }

        // GET: Igrac/Create
        public ActionResult Create()
        {
            ViewBag.TimID = new SelectList(db.Tim, "TimID", "Naziv");
            return View();
        }

        // POST: Igrac/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IgracID,TimID,Ime,Prezime,GodinaRodjenja,Pozicija")] Igrac igrac)
        {
            if (ModelState.IsValid)
            {
                db.Igrac.Add(igrac);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TimID = new SelectList(db.Tim, "TimID", "Naziv", igrac.TimID);
            return View(igrac);
        }

        // GET: Igrac/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Igrac igrac = db.Igrac.Find(id);
            if (igrac == null)
            {
                return HttpNotFound();
            }
            ViewBag.TimID = new SelectList(db.Tim, "TimID", "Naziv", igrac.TimID);
            return View(igrac);
        }

        // POST: Igrac/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IgracID,TimID,Ime,Prezime,GodinaRodjenja,Pozicija")] Igrac igrac)
        {
            if (ModelState.IsValid)
            {
                db.Entry(igrac).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TimID = new SelectList(db.Tim, "TimID", "Naziv", igrac.TimID);
            return View(igrac);
        }

        // GET: Igrac/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Igrac igrac = db.Igrac.Find(id);
            if (igrac == null)
            {
                return HttpNotFound();
            }
            return View(igrac);
        }

        // POST: Igrac/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Igrac igrac = db.Igrac.Find(id);
            db.Igrac.Remove(igrac);
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
