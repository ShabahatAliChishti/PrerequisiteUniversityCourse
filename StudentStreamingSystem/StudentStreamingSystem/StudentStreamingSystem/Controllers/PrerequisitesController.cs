using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StudentStreamingSystem.Context;

namespace StudentStreamingSystem.Controllers
{
    public class PrerequisitesController : Controller
    {
        private StudentStreamingDBEntities db = new StudentStreamingDBEntities();

        // GET: Prerequisites
        public ActionResult Index()
        {
            return View(db.Prerequisites.ToList());
        }

        // GET: Prerequisites/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prerequisite prerequisite = db.Prerequisites.Find(id);
            if (prerequisite == null)
            {
                return HttpNotFound();
            }
            return View(prerequisite);
        }

        // GET: Prerequisites/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Prerequisites/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PrerequisiteID,Name,Description,Credits")] Prerequisite prerequisite)
        {
            if (ModelState.IsValid)
            {
                db.Prerequisites.Add(prerequisite);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(prerequisite);
        }

        // GET: Prerequisites/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prerequisite prerequisite = db.Prerequisites.Find(id);
            if (prerequisite == null)
            {
                return HttpNotFound();
            }
            return View(prerequisite);
        }

        // POST: Prerequisites/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PrerequisiteID,Name,Description,Credits")] Prerequisite prerequisite)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prerequisite).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(prerequisite);
        }

        // GET: Prerequisites/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prerequisite prerequisite = db.Prerequisites.Find(id);
            if (prerequisite == null)
            {
                return HttpNotFound();
            }
            return View(prerequisite);
        }

        // POST: Prerequisites/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Prerequisite prerequisite = db.Prerequisites.Find(id);
            db.Prerequisites.Remove(prerequisite);
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
