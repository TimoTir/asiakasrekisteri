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
    public class AsiakastiedotController : Controller
    {
        private AsiakasrekisteriEntities1 db = new AsiakasrekisteriEntities1();

        // GET: Asiakastiedot
        public ActionResult Index()
        {
            var asiakastiedot = db.Asiakastiedot.Include(a => a.Asiakasluokittelu).Include(a => a.Postitoimipaikat);
            return View(asiakastiedot.ToList());
        }

        // GET: Asiakastiedot/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asiakastiedot asiakastiedot = db.Asiakastiedot.Find(id);
            if (asiakastiedot == null)
            {
                return HttpNotFound();
            }
            return View(asiakastiedot);
        }

        // GET: Asiakastiedot/Create
        public ActionResult Create()
        {
            ViewBag.LuokitteluID = new SelectList(db.Asiakasluokittelu, "LuokitteluID", "Toimiala");
            ViewBag.PaikkakuntaID = new SelectList(db.Postitoimipaikat, "PaikkakuntaID", "Postitoimipaikka");
            return View();
        }

        // POST: Asiakastiedot/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Asiakasnumero,Nimi,Yhteyshenkilö,LuokitteluID,Ytunnus,Osoite,PaikkakuntaID,Postinumero,Postitoimipaikka,Puhelin,Sähköposti,EriLaskutusosoite")] Asiakastiedot asiakastiedot)
        {
            if (ModelState.IsValid)
            {
                db.Asiakastiedot.Add(asiakastiedot);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LuokitteluID = new SelectList(db.Asiakasluokittelu, "LuokitteluID", "Toimiala", asiakastiedot.LuokitteluID);
            ViewBag.PaikkakuntaID = new SelectList(db.Postitoimipaikat, "PaikkakuntaID", "Postitoimipaikka", asiakastiedot.PaikkakuntaID);
            return View(asiakastiedot);
        }

        // GET: Asiakastiedot/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asiakastiedot asiakastiedot = db.Asiakastiedot.Find(id);
            if (asiakastiedot == null)
            {
                return HttpNotFound();
            }
            ViewBag.LuokitteluID = new SelectList(db.Asiakasluokittelu, "LuokitteluID", "Toimiala", asiakastiedot.LuokitteluID);
            ViewBag.PaikkakuntaID = new SelectList(db.Postitoimipaikat, "PaikkakuntaID", "Postitoimipaikka", asiakastiedot.PaikkakuntaID);
            return View(asiakastiedot);
        }

        // POST: Asiakastiedot/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Asiakasnumero,Nimi,Yhteyshenkilö,LuokitteluID,Ytunnus,Osoite,PaikkakuntaID,Postinumero,Postitoimipaikka,Puhelin,Sähköposti,EriLaskutusosoite")] Asiakastiedot asiakastiedot)
        {
            if (ModelState.IsValid)
            {
                db.Entry(asiakastiedot).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LuokitteluID = new SelectList(db.Asiakasluokittelu, "LuokitteluID", "Toimiala", asiakastiedot.LuokitteluID);
            ViewBag.PaikkakuntaID = new SelectList(db.Postitoimipaikat, "PaikkakuntaID", "Postitoimipaikka", asiakastiedot.PaikkakuntaID);
            return View(asiakastiedot);
        }

        // GET: Asiakastiedot/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asiakastiedot asiakastiedot = db.Asiakastiedot.Find(id);
            if (asiakastiedot == null)
            {
                return HttpNotFound();
            }
            return View(asiakastiedot);
        }

        // POST: Asiakastiedot/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Asiakastiedot asiakastiedot = db.Asiakastiedot.Find(id);
            db.Asiakastiedot.Remove(asiakastiedot);
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
