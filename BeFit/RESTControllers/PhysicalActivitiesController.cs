using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using BeFit.DAL;
using BeFit.Models;

namespace BeFit.RESTControllers
{
    public class PhysicalActivitiesController : ApiController
    {
        private DietCenterContext db = new DietCenterContext();

        // GET: api/PhysicalActivities
        public IQueryable<PhysicalActivity> GetPhysicalActivities()
        {
            return db.PhysicalActivities;
        }

        // GET: api/PhysicalActivities/5
        [ResponseType(typeof(PhysicalActivity))]
        public IHttpActionResult GetPhysicalActivity(int id)
        {
            PhysicalActivity physicalActivity = db.PhysicalActivities.Find(id);
            if (physicalActivity == null)
            {
                return NotFound();
            }

            return Ok(physicalActivity);
        }

        // PUT: api/PhysicalActivities/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPhysicalActivity(int id, PhysicalActivity physicalActivity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != physicalActivity.Id)
            {
                return BadRequest();
            }

            db.Entry(physicalActivity).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhysicalActivityExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/PhysicalActivities
        [ResponseType(typeof(PhysicalActivity))]
        public IHttpActionResult PostPhysicalActivity(PhysicalActivity physicalActivity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PhysicalActivities.Add(physicalActivity);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = physicalActivity.Id }, physicalActivity);
        }

        // DELETE: api/PhysicalActivities/5
        [ResponseType(typeof(PhysicalActivity))]
        public IHttpActionResult DeletePhysicalActivity(int id)
        {
            PhysicalActivity physicalActivity = db.PhysicalActivities.Find(id);
            if (physicalActivity == null)
            {
                return NotFound();
            }

            db.PhysicalActivities.Remove(physicalActivity);
            db.SaveChanges();

            return Ok(physicalActivity);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PhysicalActivityExists(int id)
        {
            return db.PhysicalActivities.Count(e => e.Id == id) > 0;
        }
    }
}