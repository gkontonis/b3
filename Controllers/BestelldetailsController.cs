using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KontonisAG.Models;

namespace KontonisAG.Controllers
{
    public class BestelldetailsController : Controller
    {
        private KontonisAGEntities db = new KontonisAGEntities();

        // GET: Bestelldetails
        public ActionResult Index()
        {
            var bestelldetails = db.Bestelldetails.Include(b => b.Artikel).Include(b => b.Bestellungen);
            return View(bestelldetails.ToList());
        }

        // GET: Bestelldetails/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bestelldetails bestelldetails = db.Bestelldetails.Find(id);
            if (bestelldetails == null)
            {
                return HttpNotFound();
            }
            return View(bestelldetails);
        }

        // GET: Bestelldetails/Create
        public ActionResult Create()
        {
            ViewBag.Artikel_Nr = new SelectList(db.Artikel, "Artikel_Nr", "Artikelname");
            ViewBag.Bestell_Nr = new SelectList(db.Bestellungen, "Bestell_Nr", "Bestelldatum");
            return View();
        }

        // POST: Bestelldetails/Create
        // Aktivieren Sie zum Schutz vor Angriffen durch Overposting die jeweiligen Eigenschaften, mit denen eine Bindung erfolgen soll. 
        // Weitere Informationen finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Bestell_Nr,Artikel_Nr,Einzelpreis,Anzahl,Rabatt")] Bestelldetails bestelldetails)
        {
            if (ModelState.IsValid)
            {
                db.Bestelldetails.Add(bestelldetails);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Artikel_Nr = new SelectList(db.Artikel, "Artikel_Nr", "Artikelname", bestelldetails.Artikel_Nr);
            ViewBag.Bestell_Nr = new SelectList(db.Bestellungen, "Bestell_Nr", "Bestelldatum", bestelldetails.Bestell_Nr);
            return View(bestelldetails);
        }

        // GET: Bestelldetails/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bestelldetails bestelldetails = db.Bestelldetails.Find(id);
            if (bestelldetails == null)
            {
                return HttpNotFound();
            }
            ViewBag.Artikel_Nr = new SelectList(db.Artikel, "Artikel_Nr", "Artikelname", bestelldetails.Artikel_Nr);
            ViewBag.Bestell_Nr = new SelectList(db.Bestellungen, "Bestell_Nr", "Bestelldatum", bestelldetails.Bestell_Nr);
            return View(bestelldetails);
        }

        // POST: Bestelldetails/Edit/5
        // Aktivieren Sie zum Schutz vor Angriffen durch Overposting die jeweiligen Eigenschaften, mit denen eine Bindung erfolgen soll. 
        // Weitere Informationen finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Bestell_Nr,Artikel_Nr,Einzelpreis,Anzahl,Rabatt")] Bestelldetails bestelldetails)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bestelldetails).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Artikel_Nr = new SelectList(db.Artikel, "Artikel_Nr", "Artikelname", bestelldetails.Artikel_Nr);
            ViewBag.Bestell_Nr = new SelectList(db.Bestellungen, "Bestell_Nr", "Bestelldatum", bestelldetails.Bestell_Nr);
            return View(bestelldetails);
        }

        // GET: Bestelldetails/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bestelldetails bestelldetails = db.Bestelldetails.Find(id);
            if (bestelldetails == null)
            {
                return HttpNotFound();
            }
            return View(bestelldetails);
        }

        // POST: Bestelldetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Bestelldetails bestelldetails = db.Bestelldetails.Find(id);
            db.Bestelldetails.Remove(bestelldetails);
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
