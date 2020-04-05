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
    public class AsiakasluokitteluController : Controller
    {
        private AsiakasrekisteriEntities db = new AsiakasrekisteriEntities();

        // GET: Asiakasluokittelu
        public ActionResult Index()
        {
            return View(db.Asiakasluokittelu.ToList());
        }

        // GET: Asiakasluokittelu/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asiakasluokittelu asiakasluokittelu = db.Asiakasluokittelu.Find(id);
            if (asiakasluokittelu == null)
            {
                return HttpNotFound();
            }
            return View(asiakasluokittelu);
        }

        // GET: Asiakasluokittelu/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Asiakasluokittelu/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LuokitteluID,Toimiala,Liitto")] Asiakasluokittelu asiakasluokittelu)
        {
            if (ModelState.IsValid)
            {
                db.Asiakasluokittelu.Add(asiakasluokittelu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(asiakasluokittelu);
        }

        // GET: Asiakasluokittelu/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asiakasluokittelu asiakasluokittelu = db.Asiakasluokittelu.Find(id);
            if (asiakasluokittelu == null)
            {
                return HttpNotFound();
            }
            return View(asiakasluokittelu);
        }

        // POST: Asiakasluokittelu/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LuokitteluID,Toimiala,Liitto")] Asiakasluokittelu asiakasluokittelu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(asiakasluokittelu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(asiakasluokittelu);
        }

        // GET: Asiakasluokittelu/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asiakasluokittelu asiakasluokittelu = db.Asiakasluokittelu.Find(id);
            if (asiakasluokittelu == null)
            {
                return HttpNotFound();
            }
            return View(asiakasluokittelu);
        }

        // POST: Asiakasluokittelu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Asiakasluokittelu asiakasluokittelu = db.Asiakasluokittelu.Find(id);
            db.Asiakasluokittelu.Remove(asiakasluokittelu);
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
