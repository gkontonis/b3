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
    public class KategoriensController : Controller
    {
        private KontonisAGEntities db = new KontonisAGEntities();

        // GET: Kategoriens
        public ActionResult Index()
        {
            return View(db.Kategorien.ToList());
        }

        // GET: Kategoriens/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kategorien kategorien = db.Kategorien.Find(id);
            if (kategorien == null)
            {
                return HttpNotFound();
            }
            return View(kategorien);
        }

        // GET: Kategoriens/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Kategoriens/Create
        // Aktivieren Sie zum Schutz vor Angriffen durch Overposting die jeweiligen Eigenschaften, mit denen eine Bindung erfolgen soll. 
        // Weitere Informationen finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Kategorie_Nr,Kategoriename,Beschreibung,Abbildung")] Kategorien kategorien)
        {
            if (ModelState.IsValid)
            {
                db.Kategorien.Add(kategorien);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kategorien);
        }

        // GET: Kategoriens/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kategorien kategorien = db.Kategorien.Find(id);
            if (kategorien == null)
            {
                return HttpNotFound();
            }
            return View(kategorien);
        }

        // POST: Kategoriens/Edit/5
        // Aktivieren Sie zum Schutz vor Angriffen durch Overposting die jeweiligen Eigenschaften, mit denen eine Bindung erfolgen soll. 
        // Weitere Informationen finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Kategorie_Nr,Kategoriename,Beschreibung,Abbildung")] Kategorien kategorien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kategorien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kategorien);
        }

        // GET: Kategoriens/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kategorien kategorien = db.Kategorien.Find(id);
            if (kategorien == null)
            {
                return HttpNotFound();
            }
            return View(kategorien);
        }

        // POST: Kategoriens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Kategorien kategorien = db.Kategorien.Find(id);
            db.Kategorien.Remove(kategorien);
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
