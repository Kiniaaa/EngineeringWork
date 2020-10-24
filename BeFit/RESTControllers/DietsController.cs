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
    public class DietsController : ApiController
    {
        private DietCenterContext db = new DietCenterContext();

        // GET: api/Diets
        public IQueryable<Diet> GetDiets()
        {
            return db.Diets;
        }

        // GET: api/Diets/5
        [ResponseType(typeof(Diet))]
        public IHttpActionResult GetDiet(int id)
        {
            Diet diet = db.Diets.Find(id);
            if (diet == null)
            {
                return NotFound();
            }

            return Ok(diet);
        }

        // PUT: api/Diets/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDiet(int id, Diet diet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != diet.Id)
            {
                return BadRequest();
            }

            db.Entry(diet).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DietExists(id))
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

        // POST: api/Diets
        [ResponseType(typeof(Diet))]
        public IHttpActionResult PostDiet(Diet diet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Diets.Add(diet);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = diet.Id }, diet);
        }

        // DELETE: api/Diets/5
        [ResponseType(typeof(Diet))]
        public IHttpActionResult DeleteDiet(int id)
        {
            Diet diet = db.Diets.Find(id);
            if (diet == null)
            {
                return NotFound();
            }

            db.Diets.Remove(diet);
            db.SaveChanges();

            return Ok(diet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DietExists(int id)
        {
            return db.Diets.Count(e => e.Id == id) > 0;
        }
    }
}