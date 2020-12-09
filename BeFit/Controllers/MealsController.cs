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
using BeFit.ViewModel;

namespace BeFit.Controllers
{
    public class MealsController : Controller
    {
        private DietCenterContext db = new DietCenterContext();
        // GET: Meals
        public ActionResult Index()
        {
            return View(db.Meals.ToList());
        }

        // GET: Meals/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Meal meal = db.Meals.Find(id);
            if (meal == null)
            {
                return HttpNotFound();
            }
            return View(meal);
        }

        // GET: Meals/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.MealIngridients = new MultiSelectList(db.MealIngridients.Distinct().ToList(), "Id", "Name");
            return View();
        }

        // POST: Meals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MealViewModel mealView)
        {
            if (ModelState.IsValid)
            {
                var meal = new Meal() { Name = mealView.Name, Description = mealView.Description };
                db.Meals.Add(meal);
                db.SaveChanges();
                foreach (var m in mealView.MealsIngridientsId)
                    db.MealIngridientMeals.Add(new MealIngridientMeal() { MealId = meal.Id, MealIngridientId = m });
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mealView);
        }

        // GET: Meals/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Meal meal = db.Meals.Find(id);
            if (meal == null)
            {
                return HttpNotFound();
            }
            var mealView = new MealViewModel()
            {
                Id = meal.Id,
                Name = meal.Name,
                Description = meal.Description
            };
            var multiList = new MultiSelectList(db.MealIngridients.ToList(), "Id", "Name", meal.MealIngridientMeals.Where(x => x.MealId == meal.Id).Select(x => x.MealIngridientId).ToList());
            ViewBag.MealIngridients = multiList;
            return View(mealView);
        }

        // POST: Meals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MealViewModel mealView)
        {
            if (ModelState.IsValid)
            {
                var meal = db.Meals.FirstOrDefault(m => m.Id == mealView.Id);
                meal.Id = mealView.Id;
                meal.Name = mealView.Name;
                meal.Description = mealView.Description;
                var mealIngridientMealToRemove = new List<MealIngridientMeal>();
                foreach (var m in meal.MealIngridientMeals.Where(x => x.MealId == meal.Id))
                    mealIngridientMealToRemove.Add(m);
                foreach (var m in mealIngridientMealToRemove)
                    db.MealIngridientMeals.Remove(m);
                foreach (var m in mealView.MealsIngridientsId)
                    db.MealIngridientMeals.Add(new MealIngridientMeal() { MealId = meal.Id, MealIngridientId = m });
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mealView);
        }

        // GET: Meals/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Meal meal = db.Meals.Find(id);
            if (meal == null)
            {
                return HttpNotFound();
            }
            return View(meal);
        }

        // POST: Meals/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Meal meal = db.Meals.Find(id);
            db.Meals.Remove(meal);
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
