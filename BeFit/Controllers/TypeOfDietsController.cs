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
    public class TypeOfDietsController : Controller
    {
        private DietCenterContext db = new DietCenterContext();

        // GET: TypeOfDiets
        public ActionResult Index()
        {
            return View(db.TypeOfDiets.ToList());
        }

        // GET: TypeOfDiets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeOfDiet typeOfDiet = db.TypeOfDiets.Find(id);
            if (typeOfDiet == null)
            {
                return HttpNotFound();
            }
            return View(typeOfDiet);
        }

        // GET: TypeOfDiets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TypeOfDiets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description")] TypeOfDiet typeOfDiet)
        {
            if (ModelState.IsValid)
            {
                db.TypeOfDiets.Add(typeOfDiet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(typeOfDiet);
        }

        // GET: TypeOfDiets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeOfDiet typeOfDiet = db.TypeOfDiets.Find(id);
            if (typeOfDiet == null)
            {
                return HttpNotFound();
            }
            return View(typeOfDiet);
        }

        // POST: TypeOfDiets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description")] TypeOfDiet typeOfDiet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(typeOfDiet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(typeOfDiet);
        }

        // GET: TypeOfDiets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeOfDiet typeOfDiet = db.TypeOfDiets.Find(id);
            if (typeOfDiet == null)
            {
                return HttpNotFound();
            }
            return View(typeOfDiet);
        }

        // POST: TypeOfDiets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TypeOfDiet typeOfDiet = db.TypeOfDiets.Find(id);
            db.TypeOfDiets.Remove(typeOfDiet);
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
