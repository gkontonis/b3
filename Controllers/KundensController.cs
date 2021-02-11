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
    public class KundensController : Controller
    {
        private KontonisAGEntities db = new KontonisAGEntities();

        // GET: Kundens
        public ActionResult Index()
        {
            return View(db.Kunden.ToList());
        }

        // GET: Kundens/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kunden kunden = db.Kunden.Find(id);
            if (kunden == null)
            {
                return HttpNotFound();
            }
            return View(kunden);
        }

        // GET: Kundens/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Kundens/Create
        // Aktivieren Sie zum Schutz vor Angriffen durch Overposting die jeweiligen Eigenschaften, mit denen eine Bindung erfolgen soll. 
        // Weitere Informationen finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Kunden_Code,Firma,Kontaktperson,Position,Straße,Ort,Region,PLZ,Land,Telefon,Telefax")] Kunden kunden)
        {
            if (ModelState.IsValid)
            {
                db.Kunden.Add(kunden);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kunden);
        }

        // GET: Kundens/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kunden kunden = db.Kunden.Find(id);
            if (kunden == null)
            {
                return HttpNotFound();
            }
            return View(kunden);
        }

        // POST: Kundens/Edit/5
        // Aktivieren Sie zum Schutz vor Angriffen durch Overposting die jeweiligen Eigenschaften, mit denen eine Bindung erfolgen soll. 
        // Weitere Informationen finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Kunden_Code,Firma,Kontaktperson,Position,Straße,Ort,Region,PLZ,Land,Telefon,Telefax")] Kunden kunden)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kunden).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kunden);
        }

        // GET: Kundens/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kunden kunden = db.Kunden.Find(id);
            if (kunden == null)
            {
                return HttpNotFound();
            }
            return View(kunden);
        }

        // POST: Kundens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Kunden kunden = db.Kunden.Find(id);
            db.Kunden.Remove(kunden);
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
