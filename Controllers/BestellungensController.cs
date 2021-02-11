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
    public class BestellungensController : Controller
    {
        private KontonisAGEntities db = new KontonisAGEntities();

        // GET: Bestellungens
        public ActionResult Index()
        {
            var bestellungen = db.Bestellungen.Include(b => b.Bestelldetails).Include(b => b.Kunden).Include(b => b.Personal).Include(b => b.Versandfirmen);
            return View(bestellungen.ToList());
        }

        // GET: Bestellungens/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bestellungen bestellungen = db.Bestellungen.Find(id);
            if (bestellungen == null)
            {
                return HttpNotFound();
            }
            return View(bestellungen);
        }

        // GET: Bestellungens/Create
        public ActionResult Create()
        {
            ViewBag.Bestell_Nr = new SelectList(db.Bestelldetails, "Bestell_Nr", "Bestell_Nr");
            ViewBag.Kunden_Code = new SelectList(db.Kunden, "Kunden_Code", "Firma");
            ViewBag.Personal_Nr = new SelectList(db.Personal, "Personal_Nr", "Nachname");
            ViewBag.Versand_Über = new SelectList(db.Versandfirmen, "Firmen_Nr", "Firma");
            return View();
        }

        // POST: Bestellungens/Create
        // Aktivieren Sie zum Schutz vor Angriffen durch Overposting die jeweiligen Eigenschaften, mit denen eine Bindung erfolgen soll. 
        // Weitere Informationen finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Bestell_Nr,Kunden_Code,Personal_Nr,Bestelldatum,Lieferdatum,Versanddatum,Versand_Über,Frachtkosten,Empfänger,Straße,Ort,Region,PLZ,Bestimmungsland")] Bestellungen bestellungen)
        {
            if (ModelState.IsValid)
            {
                db.Bestellungen.Add(bestellungen);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Bestell_Nr = new SelectList(db.Bestelldetails, "Bestell_Nr", "Bestell_Nr", bestellungen.Bestell_Nr);
            ViewBag.Kunden_Code = new SelectList(db.Kunden, "Kunden_Code", "Firma", bestellungen.Kunden_Code);
            ViewBag.Personal_Nr = new SelectList(db.Personal, "Personal_Nr", "Nachname", bestellungen.Personal_Nr);
            ViewBag.Versand_Über = new SelectList(db.Versandfirmen, "Firmen_Nr", "Firma", bestellungen.Versand_Über);
            return View(bestellungen);
        }

        // GET: Bestellungens/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bestellungen bestellungen = db.Bestellungen.Find(id);
            if (bestellungen == null)
            {
                return HttpNotFound();
            }
            ViewBag.Bestell_Nr = new SelectList(db.Bestelldetails, "Bestell_Nr", "Bestell_Nr", bestellungen.Bestell_Nr);
            ViewBag.Kunden_Code = new SelectList(db.Kunden, "Kunden_Code", "Firma", bestellungen.Kunden_Code);
            ViewBag.Personal_Nr = new SelectList(db.Personal, "Personal_Nr", "Nachname", bestellungen.Personal_Nr);
            ViewBag.Versand_Über = new SelectList(db.Versandfirmen, "Firmen_Nr", "Firma", bestellungen.Versand_Über);
            return View(bestellungen);
        }

        // POST: Bestellungens/Edit/5
        // Aktivieren Sie zum Schutz vor Angriffen durch Overposting die jeweiligen Eigenschaften, mit denen eine Bindung erfolgen soll. 
        // Weitere Informationen finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Bestell_Nr,Kunden_Code,Personal_Nr,Bestelldatum,Lieferdatum,Versanddatum,Versand_Über,Frachtkosten,Empfänger,Straße,Ort,Region,PLZ,Bestimmungsland")] Bestellungen bestellungen)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bestellungen).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Bestell_Nr = new SelectList(db.Bestelldetails, "Bestell_Nr", "Bestell_Nr", bestellungen.Bestell_Nr);
            ViewBag.Kunden_Code = new SelectList(db.Kunden, "Kunden_Code", "Firma", bestellungen.Kunden_Code);
            ViewBag.Personal_Nr = new SelectList(db.Personal, "Personal_Nr", "Nachname", bestellungen.Personal_Nr);
            ViewBag.Versand_Über = new SelectList(db.Versandfirmen, "Firmen_Nr", "Firma", bestellungen.Versand_Über);
            return View(bestellungen);
        }

        // GET: Bestellungens/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bestellungen bestellungen = db.Bestellungen.Find(id);
            if (bestellungen == null)
            {
                return HttpNotFound();
            }
            return View(bestellungen);
        }

        // POST: Bestellungens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Bestellungen bestellungen = db.Bestellungen.Find(id);
            db.Bestellungen.Remove(bestellungen);
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
