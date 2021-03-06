﻿using System;
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
        private AsiakasrekisteriEntities1 db = new AsiakasrekisteriEntities1();

        // GET: Asiakasluokittelu
        public ActionResult Index(string searching)
        {
            if (Session["Username"] == null)
            {
                return RedirectToAction("Login", "Logins");
            }
            else
            {
                AsiakasrekisteriEntities1 db = new AsiakasrekisteriEntities1();
                List<Asiakasluokittelu> model = db.Asiakasluokittelu.ToList();
                //db.Dispose();
            }
            //return View(db.Asiakasluokittelu.ToList());
            return View(db.Asiakasluokittelu.Where(x => x.Toimiala.Contains(searching) ||
            x.Liitto.Contains(searching) ||
            x.Liitto.Contains(searching) ||
            searching == null).ToList());
        }

        // GET: Asiakasluokittelu/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["Username"] == null)
            {
                return RedirectToAction("Login", "Logins");
            }
            //else
            //{
            //    AsiakasrekisteriEntities1 db = new AsiakasrekisteriEntities1();
            //    List<Asiakasluokittelu> model = db.Asiakasluokittelu.ToList();
            //    //db.Dispose();
                
            //}
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
            if (Session["Username"] == null)
            {
                return RedirectToAction("Login", "Logins");
            }
            //else
            //{
            //    AsiakasrekisteriEntities1 db = new AsiakasrekisteriEntities1();
            //    //List<Asiakasluokittelu> model = db.Asiakasluokittelu.ToList();
            //    //db.Dispose();
            //}
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
            if (Session["Username"] == null)
            {
                return RedirectToAction("Login", "Logins");
            }


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
            if (Session["Username"] == null)
            {
                return RedirectToAction("Login", "Logins");
            }
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
