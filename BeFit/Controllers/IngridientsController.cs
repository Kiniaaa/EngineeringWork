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
    [Authorize(Roles = "Administrator, Dietetyk")]
    public class IngridientsController : Controller
    {
        private DietCenterContext db = new DietCenterContext();

        // GET: Ingridients
        public ActionResult Index()
        {
            return View(db.Ingridients.ToList());
        }

        // GET: Ingridients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ingridient ingridient = db.Ingridients.Find(id);
            if (ingridient == null)
            {
                return HttpNotFound();
            }
            return View(ingridient);
        }

        // GET: Ingridients/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ingridients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,EnergeticValue,Fat,Protein,CarboHydrates,MeasureRate")] Ingridient ingridient)
        {
            if (ModelState.IsValid)
            {
                db.Ingridients.Add(ingridient);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ingridient);
        }

        // GET: Ingridients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ingridient ingridient = db.Ingridients.Find(id);
            if (ingridient == null)
            {
                return HttpNotFound();
            }
            return View(ingridient);
        }

        // POST: Ingridients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,EnergeticValue,Fat,Protein,CarboHydrates,MeasureRate")] Ingridient ingridient)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ingridient).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ingridient);
        }

        // GET: Ingridients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ingridient ingridient = db.Ingridients.Find(id);
            if (ingridient == null)
            {
                return HttpNotFound();
            }
            return View(ingridient);
        }

        // POST: Ingridients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ingridient ingridient = db.Ingridients.Find(id);
            db.Ingridients.Remove(ingridient);
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
