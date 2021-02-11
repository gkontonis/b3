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
    public class ArtikelsController : Controller
    {
        private KontonisAGEntities db = new KontonisAGEntities();

        // GET: Artikels
        public ActionResult Index()
        {
            var artikel = db.Artikel.Include(a => a.Kategorien).Include(a => a.Lieferanten);
            return View(artikel.ToList());
        }

        // GET: Artikels/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artikel artikel = db.Artikel.Find(id);
            if (artikel == null)
            {
                return HttpNotFound();
            }
            return View(artikel);
        }

        // GET: Artikels/Create
        public ActionResult Create()
        {
            ViewBag.Kategorie_Nr = new SelectList(db.Kategorien, "Kategorie_Nr", "Kategoriename");
            ViewBag.Lieferanten_Nr = new SelectList(db.Lieferanten, "Lieferanten_Nr", "Firma");
            return View();
        }

        // POST: Artikels/Create
        // Aktivieren Sie zum Schutz vor Angriffen durch Overposting die jeweiligen Eigenschaften, mit denen eine Bindung erfolgen soll. 
        // Weitere Informationen finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Artikel_Nr,Artikelname,Lieferanten_Nr,Kategorie_Nr,Liefereinheit,Einzelpreis,Lagerbestand,BestellteEinheiten,Mindestbestand,Auslaufartikel")] Artikel artikel)
        {
            if (ModelState.IsValid)
            {
                db.Artikel.Add(artikel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Kategorie_Nr = new SelectList(db.Kategorien, "Kategorie_Nr", "Kategoriename", artikel.Kategorie_Nr);
            ViewBag.Lieferanten_Nr = new SelectList(db.Lieferanten, "Lieferanten_Nr", "Firma", artikel.Lieferanten_Nr);
            return View(artikel);
        }

        // GET: Artikels/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artikel artikel = db.Artikel.Find(id);
            if (artikel == null)
            {
                return HttpNotFound();
            }
            ViewBag.Kategorie_Nr = new SelectList(db.Kategorien, "Kategorie_Nr", "Kategoriename", artikel.Kategorie_Nr);
            ViewBag.Lieferanten_Nr = new SelectList(db.Lieferanten, "Lieferanten_Nr", "Firma", artikel.Lieferanten_Nr);
            return View(artikel);
        }

        // POST: Artikels/Edit/5
        // Aktivieren Sie zum Schutz vor Angriffen durch Overposting die jeweiligen Eigenschaften, mit denen eine Bindung erfolgen soll. 
        // Weitere Informationen finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Artikel_Nr,Artikelname,Lieferanten_Nr,Kategorie_Nr,Liefereinheit,Einzelpreis,Lagerbestand,BestellteEinheiten,Mindestbestand,Auslaufartikel")] Artikel artikel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(artikel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Kategorie_Nr = new SelectList(db.Kategorien, "Kategorie_Nr", "Kategoriename", artikel.Kategorie_Nr);
            ViewBag.Lieferanten_Nr = new SelectList(db.Lieferanten, "Lieferanten_Nr", "Firma", artikel.Lieferanten_Nr);
            return View(artikel);
        }

        // GET: Artikels/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artikel artikel = db.Artikel.Find(id);
            if (artikel == null)
            {
                return HttpNotFound();
            }
            return View(artikel);
        }

        // POST: Artikels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Artikel artikel = db.Artikel.Find(id);
            db.Artikel.Remove(artikel);
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
