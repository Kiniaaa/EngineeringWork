using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BeFit.DAL;
using BeFit.Models;

namespace BeFit.Controllers
{
    public class PhysicalActivitiesController : Controller
    {
        private DietCenterContext db = new DietCenterContext();

        // GET: PhysicalActivities
        public ActionResult Index()
        {
            var physicalActivities = db.PhysicalActivities.Include(p => p.Customer);
            return View(physicalActivities.ToList());
        }

        // GET: PhysicalActivities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhysicalActivity physicalActivity = db.PhysicalActivities.Find(id);
            if (physicalActivity == null)
            {
                return HttpNotFound();
            }
            return View(physicalActivity);
        }

        // GET: PhysicalActivities/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email");
            return View();
        }

        // POST: PhysicalActivities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,CaloriessBurned,DateActivity,Description,UserId")] PhysicalActivity physicalActivity)
        {
            if (ModelState.IsValid)
            {
                db.PhysicalActivities.Add(physicalActivity);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", physicalActivity.UserId);
            return View(physicalActivity);
        }

        // GET: PhysicalActivities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhysicalActivity physicalActivity = db.PhysicalActivities.Find(id);
            if (physicalActivity == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", physicalActivity.UserId);
            return View(physicalActivity);
        }

        // POST: PhysicalActivities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,CaloriessBurned,DateActivity,Description,UserId")] PhysicalActivity physicalActivity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(physicalActivity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", physicalActivity.UserId);
            return View(physicalActivity);
        }

        // GET: PhysicalActivities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhysicalActivity physicalActivity = db.PhysicalActivities.Find(id);
            if (physicalActivity == null)
            {
                return HttpNotFound();
            }
            return View(physicalActivity);
        }

        // POST: PhysicalActivities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PhysicalActivity physicalActivity = db.PhysicalActivities.Find(id);
            db.PhysicalActivities.Remove(physicalActivity);
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
