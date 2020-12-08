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
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BeFit.Controllers
{
    [Authorize]
    public class MessagesController : Controller
    {
        private DietCenterContext db = new DietCenterContext();

        // GET: Messages
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var context = new IdentityDbContext();
            var userEmail = context.Users.Find(userId).UserName;
            var user = db.Users.FirstOrDefault(u => u.Email == userEmail);

            return View(db.Messages.Where(u => u.Receiver.Id == user.Id).ToList());
        }

        public ActionResult Sent()
        {
            var userId = User.Identity.GetUserId();
            var context = new IdentityDbContext();
            var userEmail = context.Users.Find(userId).UserName;
            var user = db.Users.FirstOrDefault(u => u.Email == userEmail);

            return View(db.Messages.Where(u => u.Sender.Id == user.Id).ToList());
        }

        // GET: Messages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Message message = db.Messages.Find(id);
            if (message == null)
            {
                return HttpNotFound();
            }
            return View(message);
        }

        // GET: Messages/Create
        public ActionResult Create()
        {
            ViewBag.Receiver = new SelectList(db.Users.Where(u => u.roleName.Contains("Klient")), "Id", "Email");
            return View();
        }

        // POST: Messages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Content, Receiver")] Message message)
        {
            ModelState["Receiver.Id"].Errors.Clear();
            ModelState["Receiver.Email"].Errors.Clear();
            ModelState["Receiver.FirstName"].Errors.Clear();
            ModelState["Receiver.Surname"].Errors.Clear();
            if (ModelState.IsValid)
            {
                var receiver = db.Users.Find(message.Receiver.Id);
                message.Receiver = receiver;

                var userId = User.Identity.GetUserId();
                var context = new IdentityDbContext();
                var userEmail = context.Users.Find(userId).UserName;
                var sender = db.Users.FirstOrDefault(u => u.Email == userEmail);
                message.Sender = sender;

                message.Date = DateTime.Now;

                db.Messages.Add(message);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Receiver = new SelectList(db.Users.Where(u => u.roleName.Contains("Klient")), "Id", "Email", message.Receiver.Id);
            return View(message);
        }

        // GET: Messages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Message message = db.Messages.Find(id);
            if (message == null)
            {
                return HttpNotFound();
            }
            return View(message);
        }

        // POST: Messages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Content")] Message message)
        {
            if (ModelState.IsValid)
            {
                db.Entry(message).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(message);
        }

        // GET: Messages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Message message = db.Messages.Find(id);
            if (message == null)
            {
                return HttpNotFound();
            }
            return View(message);
        }

        // POST: Messages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Message message = db.Messages.Find(id);
            db.Messages.Remove(message);
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
