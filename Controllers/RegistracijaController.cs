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
    public class RegistracijaController : Controller
    {
        private Model1 db = new Model1();

        // GET: Registracija
        public ActionResult Index()
        {
            return View(db.Korisnik.ToList());
        }

        // GET: Registracija/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Korisnik korisnik = db.Korisnik.Find(id);
            if (korisnik == null)
            {
                return HttpNotFound();
            }
            return View(korisnik);
        }

        // GET: Registracija/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Registracija/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "KorisnikID,Ime,Prezime,Email,Sifra")] Korisnik korisnik)
        {
            if (ModelState.IsValid)
            {
               
                db.Korisnik.Add(korisnik);
                db.SaveChanges();
                return View("Index");
            }
            
                
                return View();
            
            
        }

       

       
        
    }
}
