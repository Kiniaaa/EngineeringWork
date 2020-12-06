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
    public class CustomersDataController : Controller
    {
        private DietCenterContext db = new DietCenterContext();

        // GET: CustomersData
        public ActionResult Index()
        {
            var customerDatas = db.CustomerDatas.Include(c => c.Customer);
            return View(customerDatas.ToList());
        }

        // GET: CustomersData/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerData customerData = db.CustomerDatas.Find(id);
            if (customerData == null)
            {
                return HttpNotFound();
            }
            return View(customerData);
        }

        // GET: CustomersData/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email");
            return View();
        }

        // POST: CustomersData/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Weight,Growth,DateOfMeasurement,UserId")] CustomerData customerData)
        {
            if (ModelState.IsValid)
            {
                db.CustomerDatas.Add(customerData);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", customerData.UserId);
            return View(customerData);
        }

        // GET: CustomersData/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerData customerData = db.CustomerDatas.Find(id);
            if (customerData == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", customerData.UserId);
            return View(customerData);
        }

        // POST: CustomersData/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Weight,Growth,DateOfMeasurement,UserId")] CustomerData customerData)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customerData).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", customerData.UserId);
            return View(customerData);
        }

        // GET: CustomersData/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerData customerData = db.CustomerDatas.Find(id);
            if (customerData == null)
            {
                return HttpNotFound();
            }
            return View(customerData);
        }

        // POST: CustomersData/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CustomerData customerData = db.CustomerDatas.Find(id);
            db.CustomerDatas.Remove(customerData);
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
