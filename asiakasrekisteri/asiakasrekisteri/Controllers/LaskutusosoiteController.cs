using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using asiakasrekisteri.Models;

namespace asiakasrekisteri.Controllers
{
    public class LaskutusosoiteController : Controller
    {
        private AsiakasrekisteriEntities1 db = new AsiakasrekisteriEntities1();

        // GET: Laskutusosoite
        public ActionResult Index()
        {
            var laskutusosoite = db.Laskutusosoite.Include(l => l.Asiakastiedot);
            return View(laskutusosoite.ToList());
        }

        // GET: Laskutusosoite/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Laskutusosoite laskutusosoite = db.Laskutusosoite.Find(id);
            if (laskutusosoite == null)
            {
                return HttpNotFound();
            }
            return View(laskutusosoite);
        }

        // GET: Laskutusosoite/Create
        public ActionResult Create()
        {
            ViewBag.Asiakasnumero = new SelectList(db.Asiakastiedot, "Asiakasnumero", "Nimi");
            return View();
        }

        // POST: Laskutusosoite/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LaskutustietoID,Asiakasnumero,Nimi,Ytunnus,Osoite,Postinumero,Postitoimipaikka,Sähköposti")] Laskutusosoite laskutusosoite)
        {
            if (ModelState.IsValid)
            {
                db.Laskutusosoite.Add(laskutusosoite);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Asiakasnumero = new SelectList(db.Asiakastiedot, "Asiakasnumero", "Nimi", laskutusosoite.Asiakasnumero);
            return View(laskutusosoite);
        }

        // GET: Laskutusosoite/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Laskutusosoite laskutusosoite = db.Laskutusosoite.Find(id);
            if (laskutusosoite == null)
            {
                return HttpNotFound();
            }
            ViewBag.Asiakasnumero = new SelectList(db.Asiakastiedot, "Asiakasnumero", "Nimi", laskutusosoite.Asiakasnumero);
            return View(laskutusosoite);
        }

        // POST: Laskutusosoite/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LaskutustietoID,Asiakasnumero,Nimi,Ytunnus,Osoite,Postinumero,Postitoimipaikka,Sähköposti")] Laskutusosoite laskutusosoite)
        {
            if (ModelState.IsValid)
            {
                db.Entry(laskutusosoite).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Asiakasnumero = new SelectList(db.Asiakastiedot, "Asiakasnumero", "Nimi", laskutusosoite.Asiakasnumero);
            return View(laskutusosoite);
        }

        // GET: Laskutusosoite/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Laskutusosoite laskutusosoite = db.Laskutusosoite.Find(id);
            if (laskutusosoite == null)
            {
                return HttpNotFound();
            }
            return View(laskutusosoite);
        }

        // POST: Laskutusosoite/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Laskutusosoite laskutusosoite = db.Laskutusosoite.Find(id);
            db.Laskutusosoite.Remove(laskutusosoite);
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
