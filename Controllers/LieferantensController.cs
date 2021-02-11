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
    public class LieferantensController : Controller
    {
        private KontonisAGEntities db = new KontonisAGEntities();

        // GET: Lieferantens
        public ActionResult Index()
        {
            return View(db.Lieferanten.ToList());
        }

        // GET: Lieferantens/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lieferanten lieferanten = db.Lieferanten.Find(id);
            if (lieferanten == null)
            {
                return HttpNotFound();
            }
            return View(lieferanten);
        }

        // GET: Lieferantens/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Lieferantens/Create
        // Aktivieren Sie zum Schutz vor Angriffen durch Overposting die jeweiligen Eigenschaften, mit denen eine Bindung erfolgen soll. 
        // Weitere Informationen finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Lieferanten_Nr,Firma,Kontaktperson,Position,Straße,Ort,Region,PLZ,Land,Telefon,Telefax,Homepage")] Lieferanten lieferanten)
        {
            if (ModelState.IsValid)
            {
                db.Lieferanten.Add(lieferanten);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lieferanten);
        }

        // GET: Lieferantens/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lieferanten lieferanten = db.Lieferanten.Find(id);
            if (lieferanten == null)
            {
                return HttpNotFound();
            }
            return View(lieferanten);
        }

        // POST: Lieferantens/Edit/5
        // Aktivieren Sie zum Schutz vor Angriffen durch Overposting die jeweiligen Eigenschaften, mit denen eine Bindung erfolgen soll. 
        // Weitere Informationen finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Lieferanten_Nr,Firma,Kontaktperson,Position,Straße,Ort,Region,PLZ,Land,Telefon,Telefax,Homepage")] Lieferanten lieferanten)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lieferanten).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lieferanten);
        }

        // GET: Lieferantens/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lieferanten lieferanten = db.Lieferanten.Find(id);
            if (lieferanten == null)
            {
                return HttpNotFound();
            }
            return View(lieferanten);
        }

        // POST: Lieferantens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Lieferanten lieferanten = db.Lieferanten.Find(id);
            db.Lieferanten.Remove(lieferanten);
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
