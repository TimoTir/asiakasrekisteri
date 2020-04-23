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
    public class AccesLevelsController : Controller
    {
        private AsiakasrekisteriEntities1 db = new AsiakasrekisteriEntities1();

        // GET: AccesLevels
        public ActionResult Index()
        {
            return View(db.AccesLevels.ToList());
        }

        // GET: AccesLevels/Details/5
        public ActionResult Details(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccesLevels accesLevels = db.AccesLevels.Find(id);
            if (accesLevels == null)
            {
                return HttpNotFound();
            }
            return View(accesLevels);
        }

        // GET: AccesLevels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AccesLevels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AccesslevelID,AccessName,ALevel")] AccesLevels accesLevels)
        {
            if (ModelState.IsValid)
            {
                db.AccesLevels.Add(accesLevels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(accesLevels);
        }

        // GET: AccesLevels/Edit/5
        public ActionResult Edit(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccesLevels accesLevels = db.AccesLevels.Find(id);
            if (accesLevels == null)
            {
                return HttpNotFound();
            }
            return View(accesLevels);
        }

        // POST: AccesLevels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AccesslevelID,AccessName,ALevel")] AccesLevels accesLevels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(accesLevels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(accesLevels);
        }

        // GET: AccesLevels/Delete/5
        public ActionResult Delete(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccesLevels accesLevels = db.AccesLevels.Find(id);
            if (accesLevels == null)
            {
                return HttpNotFound();
            }
            return View(accesLevels);
        }

        // POST: AccesLevels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(short id)
        {
            AccesLevels accesLevels = db.AccesLevels.Find(id);
            db.AccesLevels.Remove(accesLevels);
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
