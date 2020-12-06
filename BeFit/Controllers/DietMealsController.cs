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
    [Authorize]
    public class DietMealsController : Controller
    {
        private DietCenterContext db = new DietCenterContext();

        // GET: DietMeals
        public ActionResult Index()
        {
            var dietMeals = db.DietMeals.Include(d => d.Diet).Include(d => d.Meal).Include(d => d.TypeOfMeal);
            return View(dietMeals.ToList());
        }

        // GET: DietMeals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DietMeal dietMeal = db.DietMeals.Find(id);
            if (dietMeal == null)
            {
                return HttpNotFound();
            }
            return View(dietMeal);
        }

        // GET: DietMeals/Create
        public ActionResult Create()
        {
            ViewBag.DietId = new SelectList(db.Diets, "Id", "Name");
            ViewBag.MealId = new SelectList(db.Meals, "Id", "Name");
            ViewBag.TypeOfMealId = new SelectList(db.TypeOfMeals, "Id", "Name");
            return View();
        }

        // POST: DietMeals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DateOfEating,DietId,MealId,TypeOfMealId")] DietMeal dietMeal)
        {
            if (ModelState.IsValid)
            {
                db.DietMeals.Add(dietMeal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DietId = new SelectList(db.Diets, "Id", "Name", dietMeal.DietId);
            ViewBag.MealId = new SelectList(db.Meals, "Id", "Name", dietMeal.MealId);
            ViewBag.TypeOfMealId = new SelectList(db.TypeOfMeals, "Id", "Name", dietMeal.TypeOfMealId);
            return View(dietMeal);
        }

        // GET: DietMeals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DietMeal dietMeal = db.DietMeals.Find(id);
            if (dietMeal == null)
            {
                return HttpNotFound();
            }
            ViewBag.DietId = new SelectList(db.Diets, "Id", "Name", dietMeal.DietId);
            ViewBag.MealId = new SelectList(db.Meals, "Id", "Name", dietMeal.MealId);
            ViewBag.TypeOfMealId = new SelectList(db.TypeOfMeals, "Id", "Name", dietMeal.TypeOfMealId);
            return View(dietMeal);
        }

        // POST: DietMeals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DateOfEating,DietId,MealId,TypeOfMealId")] DietMeal dietMeal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dietMeal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DietId = new SelectList(db.Diets, "Id", "Name", dietMeal.DietId);
            ViewBag.MealId = new SelectList(db.Meals, "Id", "Name", dietMeal.MealId);
            ViewBag.TypeOfMealId = new SelectList(db.TypeOfMeals, "Id", "Name", dietMeal.TypeOfMealId);
            return View(dietMeal);
        }

        // GET: DietMeals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DietMeal dietMeal = db.DietMeals.Find(id);
            if (dietMeal == null)
            {
                return HttpNotFound();
            }
            return View(dietMeal);
        }

        // POST: DietMeals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DietMeal dietMeal = db.DietMeals.Find(id);
            db.DietMeals.Remove(dietMeal);
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
