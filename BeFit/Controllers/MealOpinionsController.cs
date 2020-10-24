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
    public class MealOpinionsController : Controller
    {
        private DietCenterContext db = new DietCenterContext();

        // GET: MealOpinions
        public ActionResult Index()
        {
            var mealOpinions = db.MealOpinions.Include(m => m.Customer).Include(m => m.Meal);
            return View(mealOpinions.ToList());
        }

        // GET: MealOpinions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MealOpinion mealOpinion = db.MealOpinions.Find(id);
            if (mealOpinion == null)
            {
                return HttpNotFound();
            }
            return View(mealOpinion);
        }

        // GET: MealOpinions/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.Users, "Id", "UserName");
            ViewBag.MealId = new SelectList(db.Meals, "Id", "Name");
            return View();
        }

        // POST: MealOpinions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,MealRate,DateOpinion,Description,MealId,UserId")] MealOpinion mealOpinion)
        {
            if (ModelState.IsValid)
            {
                db.MealOpinions.Add(mealOpinion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.Users, "Id", "UserName", mealOpinion.UserId);
            ViewBag.MealId = new SelectList(db.Meals, "Id", "Name", mealOpinion.MealId);
            return View(mealOpinion);
        }

        // GET: MealOpinions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MealOpinion mealOpinion = db.MealOpinions.Find(id);
            if (mealOpinion == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "UserName", mealOpinion.UserId);
            ViewBag.MealId = new SelectList(db.Meals, "Id", "Name", mealOpinion.MealId);
            return View(mealOpinion);
        }

        // POST: MealOpinions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,MealRate,DateOpinion,Description,MealId,UserId")] MealOpinion mealOpinion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mealOpinion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "UserName", mealOpinion.UserId);
            ViewBag.MealId = new SelectList(db.Meals, "Id", "Name", mealOpinion.MealId);
            return View(mealOpinion);
        }

        // GET: MealOpinions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MealOpinion mealOpinion = db.MealOpinions.Find(id);
            if (mealOpinion == null)
            {
                return HttpNotFound();
            }
            return View(mealOpinion);
        }

        // POST: MealOpinions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MealOpinion mealOpinion = db.MealOpinions.Find(id);
            db.MealOpinions.Remove(mealOpinion);
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
