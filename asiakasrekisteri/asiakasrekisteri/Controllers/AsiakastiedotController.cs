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
        public ActionResult Index(string searching)
        {

            if (Session["Username"] == null)
            {
                return RedirectToAction("Login", "Logins");
            }
            else
            {
                AsiakasrekisteriEntities1 db = new AsiakasrekisteriEntities1();
                List<Asiakastiedot> model = db.Asiakastiedot.ToList();                
                var asiakastiedot = db.Asiakastiedot.Include(a => a.Asiakasluokittelu).Include(a => a.Postitoimipaikat);
                return View(db.Asiakastiedot.Where(x => x.Asiakasluokittelu.Toimiala.Contains(searching) ||
                x.Nimi.Contains(searching) ||
                x.Yhteyshenkilö.Contains(searching) ||
                x.Sähköposti.Contains(searching) ||
                x.Puhelin.Contains(searching) ||
                x.Postitoimipaikat.Postitoimipaikka.Contains(searching) ||
                searching == null).ToList());
                //db.Dispose();
            }
            //var asiakastiedot = db.Asiakastiedot.Include(a => a.Asiakasluokittelu).Include(a => a.Postitoimipaikat);
            ////return View(asiakastiedot.ToList());
            //return View(db.Asiakastiedot.Where(x => x.Asiakasluokittelu.Toimiala.Contains(searching) ||
            //x.Nimi.Contains(searching) ||
            //x.Yhteyshenkilö.Contains(searching) ||
            //x.Sähköposti.Contains(searching) ||
            //x.Puhelin.Contains(searching) ||
            //x.Postitoimipaikat.Postitoimipaikka.Contains(searching) ||
            //searching == null).ToList());
        }

        // GET: Asiakastiedot/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["Username"] == null)
            {
                return RedirectToAction("Login", "Logins");
            }
            //else
            //{
            //    AsiakasrekisteriEntities1 db = new AsiakasrekisteriEntities1();
            //    List<Asiakastiedot> model = db.Asiakastiedot.ToList();
            //    db.Dispose();
            //}
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
            if (Session["Username"] == null)
            {
                return RedirectToAction("Login", "Logins");
            }
            //else
            //{
            //    AsiakasrekisteriEntities1 db = new AsiakasrekisteriEntities1();
            //    List<Asiakastiedot> model = db.Asiakastiedot.ToList();
            //    db.Dispose();
            //}
            ViewData["Liitto"] = new SelectList(db.Asiakasluokittelu,"LuokitteluID", "Liitto");
            //ViewData["Liitto"] = new SelectList(db.Asiakasluokittelu, "Liitto");
            ViewBag.LuokitteluID = new SelectList(db.Asiakasluokittelu, "LuokitteluID", "Toimiala");
            ViewBag.PaikkakuntaID = new SelectList(db.Postitoimipaikat, "PaikkakuntaID", "Postitoimipaikka");
            return View();
        }

        // POST: Asiakastiedot/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Asiakasnumero,Nimi,Yhteyshenkilö,LuokitteluID,Liitto,Ytunnus,Osoite,PaikkakuntaID,Postinumero,Postitoimipaikka,Puhelin,Sähköposti,EriLaskutusosoite")] Asiakastiedot asiakastiedot)
        {
            if (ModelState.IsValid)
            {
                db.Asiakastiedot.Add(asiakastiedot);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["Liitto"] = new SelectList(db.Asiakasluokittelu, "LuokitteluID","Liitto", asiakastiedot.Asiakasluokittelu.Liitto );
            ViewBag.LuokitteluID = new SelectList(db.Asiakasluokittelu, "LuokitteluID", "Toimiala",asiakastiedot.LuokitteluID);
            ViewBag.PaikkakuntaID = new SelectList(db.Postitoimipaikat, "PaikkakuntaID", "Postitoimipaikka", asiakastiedot.PaikkakuntaID);
            return View(asiakastiedot);
        }

        // GET: Asiakastiedot/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["Username"] == null)
            {
                return RedirectToAction("Login", "Logins");
            }
            else
            //{
            //    AsiakasrekisteriEntities1 db = new AsiakasrekisteriEntities1();
            //    List<Asiakastiedot> model = db.Asiakastiedot.ToList();
            //    db.Dispose();
            //}
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asiakastiedot asiakastiedot = db.Asiakastiedot.Find(id);
            if (asiakastiedot == null)
            {
                return HttpNotFound();
            }
            ViewData["Liitto"] = new SelectList(db.Asiakasluokittelu, "LuokitteluID","Liitto");
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
            ViewData["Liitto"] = new SelectList(db.Asiakasluokittelu, "LuokitteluID", "Liitto", asiakastiedot.Asiakasluokittelu.Liitto);
            ViewBag.LuokitteluID = new SelectList(db.Asiakasluokittelu, "LuokitteluID", "Toimiala", asiakastiedot.LuokitteluID);
            ViewBag.PaikkakuntaID = new SelectList(db.Postitoimipaikat, "PaikkakuntaID", "Postitoimipaikka", asiakastiedot.PaikkakuntaID);
            return View(asiakastiedot);
        }

        // GET: Asiakastiedot/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["Username"] == null)
            {
                return RedirectToAction("Login", "Logins");
            }
            //else
            //{
            //    AsiakasrekisteriEntities1 db = new AsiakasrekisteriEntities1();
            //    List<Asiakastiedot> model = db.Asiakastiedot.ToList();
            //    db.Dispose();
            //}
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
