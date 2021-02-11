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
    public class VersandfirmenController : Controller
    {
        private KontonisAGEntities db = new KontonisAGEntities();

        // GET: Versandfirmen
        public ActionResult Index()
        {
            return View(db.Versandfirmen.ToList());
        }

        // GET: Versandfirmen/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Versandfirmen versandfirmen = db.Versandfirmen.Find(id);
            if (versandfirmen == null)
            {
                return HttpNotFound();
            }
            return View(versandfirmen);
        }

        // GET: Versandfirmen/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Versandfirmen/Create
        // Aktivieren Sie zum Schutz vor Angriffen durch Overposting die jeweiligen Eigenschaften, mit denen eine Bindung erfolgen soll. 
        // Weitere Informationen finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Firmen_Nr,Firma,Telefon")] Versandfirmen versandfirmen)
        {
            if (ModelState.IsValid)
            {
                db.Versandfirmen.Add(versandfirmen);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(versandfirmen);
        }

        // GET: Versandfirmen/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Versandfirmen versandfirmen = db.Versandfirmen.Find(id);
            if (versandfirmen == null)
            {
                return HttpNotFound();
            }
            return View(versandfirmen);
        }

        // POST: Versandfirmen/Edit/5
        // Aktivieren Sie zum Schutz vor Angriffen durch Overposting die jeweiligen Eigenschaften, mit denen eine Bindung erfolgen soll. 
        // Weitere Informationen finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Firmen_Nr,Firma,Telefon")] Versandfirmen versandfirmen)
        {
            if (ModelState.IsValid)
            {
                db.Entry(versandfirmen).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(versandfirmen);
        }

        // GET: Versandfirmen/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Versandfirmen versandfirmen = db.Versandfirmen.Find(id);
            if (versandfirmen == null)
            {
                return HttpNotFound();
            }
            return View(versandfirmen);
        }

        // POST: Versandfirmen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Versandfirmen versandfirmen = db.Versandfirmen.Find(id);
            db.Versandfirmen.Remove(versandfirmen);
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
