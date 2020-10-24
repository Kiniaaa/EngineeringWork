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
    public class MealIngridientsController : Controller
    {
        private DietCenterContext db = new DietCenterContext();

        // GET: MealIngridients
        public ActionResult Index()
        {
            var mealIngridients = db.MealIngridients.Include(m => m.Ingridient).Include(m => m.Meal);
            return View(mealIngridients.ToList());
        }

        // GET: MealIngridients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MealIngridient mealIngridient = db.MealIngridients.Find(id);
            if (mealIngridient == null)
            {
                return HttpNotFound();
            }
            return View(mealIngridient);
        }

        // GET: MealIngridients/Create
        public ActionResult Create()
        {
            ViewBag.IngridientId = new SelectList(db.Ingridients, "Id", "Name");
            ViewBag.MealId = new SelectList(db.Meals, "Id", "Name");
            return View();
        }

        // POST: MealIngridients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Quantity,MealId,IngridientId")] MealIngridient mealIngridient)
        {
            if (ModelState.IsValid)
            {
                db.MealIngridients.Add(mealIngridient);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IngridientId = new SelectList(db.Ingridients, "Id", "Name", mealIngridient.IngridientId);
            ViewBag.MealId = new SelectList(db.Meals, "Id", "Name", mealIngridient.MealId);
            return View(mealIngridient);
        }

        // GET: MealIngridients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MealIngridient mealIngridient = db.MealIngridients.Find(id);
            if (mealIngridient == null)
            {
                return HttpNotFound();
            }
            ViewBag.IngridientId = new SelectList(db.Ingridients, "Id", "Name", mealIngridient.IngridientId);
            ViewBag.MealId = new SelectList(db.Meals, "Id", "Name", mealIngridient.MealId);
            return View(mealIngridient);
        }

        // POST: MealIngridients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Quantity,MealId,IngridientId")] MealIngridient mealIngridient)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mealIngridient).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IngridientId = new SelectList(db.Ingridients, "Id", "Name", mealIngridient.IngridientId);
            ViewBag.MealId = new SelectList(db.Meals, "Id", "Name", mealIngridient.MealId);
            return View(mealIngridient);
        }

        // GET: MealIngridients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MealIngridient mealIngridient = db.MealIngridients.Find(id);
            if (mealIngridient == null)
            {
                return HttpNotFound();
            }
            return View(mealIngridient);
        }

        // POST: MealIngridients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MealIngridient mealIngridient = db.MealIngridients.Find(id);
            db.MealIngridients.Remove(mealIngridient);
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
