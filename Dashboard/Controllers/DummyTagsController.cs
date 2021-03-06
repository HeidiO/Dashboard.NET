﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Dashboard.Models;

namespace Dashboard.Controllers
{
    public class DummyTagsController : Controller
    {
        private masterEntities db = new masterEntities();

        // GET: DummyTags
        public ActionResult Index()
        {
            var First1000Tags = db.DummyTags.Take(1000);
            return View(First1000Tags.ToList());
        }

        // GET: DummyTags/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DummyTag dummyTag = db.DummyTags.Find(id);
            if (dummyTag == null)
            {
                return HttpNotFound();
            }
            return View(dummyTag);
        }

        // GET: DummyTags/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DummyTags/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "C_TagName_,C_Average_,C_Time_,newcolumn")] DummyTag dummyTag)
        {
            if (ModelState.IsValid)
            {
                db.DummyTags.Add(dummyTag);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dummyTag);
        }

        // GET: DummyTags/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DummyTag dummyTag = db.DummyTags.Find(id);
            if (dummyTag == null)
            {
                return HttpNotFound();
            }
            return View(dummyTag);
        }

        // POST: DummyTags/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "C_TagName_,C_Average_,C_Time_,newcolumn")] DummyTag dummyTag)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dummyTag).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dummyTag);
        }

        // GET: DummyTags/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DummyTag dummyTag = db.DummyTags.Find(id);
            if (dummyTag == null)
            {
                return HttpNotFound();
            }
            return View(dummyTag);
        }

        // POST: DummyTags/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DummyTag dummyTag = db.DummyTags.Find(id);
            db.DummyTags.Remove(dummyTag);
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
