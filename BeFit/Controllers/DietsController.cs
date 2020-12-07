using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using BeFit.DAL;
using BeFit.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BeFit.Controllers
{
    //[Authorize(Roles = "Administrator, Dietetyk")]
    public class DietsController : Controller
    {
        private DietCenterContext db = new DietCenterContext();

        // GET: Diets
        public ActionResult Index()
        {
            var diets = db.Diets.Include(d => d.TypeOfDiet).Include(d => d.Customer);
            return View(diets.ToList());
        }

        // GET: Diets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Diet diet = db.Diets.Find(id);
            if (diet == null)
            {
                return HttpNotFound();
            }
            ViewBag.TypeOfMeal = db.TypeOfMeals.ToList();
            return View(diet);
        }

        // GET: Diets/Create
        public ActionResult Create()
        {
            ViewBag.TypeOfDietId = new SelectList(db.TypeOfDiets, "Id", "Name");
            ViewBag.CustomerId = new SelectList(db.Users.Where(u => u.roleName.Contains("Klient")), "Id", "Email");
            return View();
        }

        // POST: Diets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,EnergeticValue,DateStart,Duration,DieticianOpinion,DieticianRate,DietOpinion,DietRate,AdditionalWarning,TypeOfDietId,Customer")] Diet diet)
        {
            ModelState["Customer.Id"].Errors.Clear();
            ModelState["Customer.Email"].Errors.Clear();
            ModelState["Customer.FirstName"].Errors.Clear();
            ModelState["Customer.Surname"].Errors.Clear();
            if (ModelState.IsValid)
            {
                var customer = db.Users.Find(diet.Customer.Id);
                diet.Customer = customer;
                var userId = User.Identity.GetUserId();
                var context = new IdentityDbContext();
                var userEmail = context.Users.Find(userId).UserName;
                var dietician = db.Users.FirstOrDefault(u => u.Email == userEmail);
                diet.Dietician = dietician;
                db.Diets.Add(diet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TypeOfDietId = new SelectList(db.TypeOfDiets, "Id", "Name", diet.TypeOfDietId);
            ViewBag.CustomerId = new SelectList(db.Users.Where(u => u.roleName.Contains("Klient")), "Id", "Email", diet.Customer.Id);
            return View(diet);
        }

        // GET: Diets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Diet diet = db.Diets.Find(id);
            if (diet == null)
            {
                return HttpNotFound();
            }
            ViewBag.TypeOfDietId = new SelectList(db.TypeOfDiets, "Id", "Name", diet.TypeOfDietId);
            ViewBag.CustomerId = new SelectList(db.Users.Where(u => u.roleName.Contains("Klient")), "Id", "Email", diet.Customer);
            return View(diet);
        }

        // POST: Diets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,EnergeticValue,DateStart,Duration,DieticianOpinion,DieticianRate,DietOpinion,DietRate,AdditionalWarning,TypeOfDietId,UserId")] Diet diet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(diet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TypeOfDietId = new SelectList(db.TypeOfDiets, "Id", "Name", diet.TypeOfDietId);
            ViewBag.CustomerId = new SelectList(db.Users.Where(u => u.roleName.Contains("Klient")), "Id", "Email", diet.Customer);
            return View(diet);
        }

        // GET: Diets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Diet diet = db.Diets.Find(id);
            if (diet == null)
            {
                return HttpNotFound();
            }
            return View(diet);
        }

        // POST: Diets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Diet diet = db.Diets.Find(id);
            db.Diets.Remove(diet);
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
