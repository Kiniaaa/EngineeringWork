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
    public class TypeOfMealsController : Controller
    {
        private DietCenterContext db = new DietCenterContext();

        // GET: TypeOfMeals
        public ActionResult Index()
        {
            return View(db.TypeOfMeals.ToList());
        }

        // GET: TypeOfMeals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeOfMeal typeOfMeal = db.TypeOfMeals.Find(id);
            if (typeOfMeal == null)
            {
                return HttpNotFound();
            }
            return View(typeOfMeal);
        }

        // GET: TypeOfMeals/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TypeOfMeals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description")] TypeOfMeal typeOfMeal)
        {
            if (ModelState.IsValid)
            {
                db.TypeOfMeals.Add(typeOfMeal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(typeOfMeal);
        }

        // GET: TypeOfMeals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeOfMeal typeOfMeal = db.TypeOfMeals.Find(id);
            if (typeOfMeal == null)
            {
                return HttpNotFound();
            }
            return View(typeOfMeal);
        }

        // POST: TypeOfMeals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description")] TypeOfMeal typeOfMeal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(typeOfMeal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(typeOfMeal);
        }

        // GET: TypeOfMeals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeOfMeal typeOfMeal = db.TypeOfMeals.Find(id);
            if (typeOfMeal == null)
            {
                return HttpNotFound();
            }
            return View(typeOfMeal);
        }

        // POST: TypeOfMeals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TypeOfMeal typeOfMeal = db.TypeOfMeals.Find(id);
            db.TypeOfMeals.Remove(typeOfMeal);
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
