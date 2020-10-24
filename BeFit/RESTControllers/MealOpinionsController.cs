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
    public class MealOpinionsController : ApiController
    {
        private DietCenterContext db = new DietCenterContext();

        // GET: api/MealOpinions
        public IQueryable<MealOpinion> GetMealOpinions()
        {
            return db.MealOpinions;
        }

        // GET: api/MealOpinions/5
        [ResponseType(typeof(MealOpinion))]
        public IHttpActionResult GetMealOpinion(int id)
        {
            MealOpinion mealOpinion = db.MealOpinions.Find(id);
            if (mealOpinion == null)
            {
                return NotFound();
            }

            return Ok(mealOpinion);
        }

        // PUT: api/MealOpinions/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMealOpinion(int id, MealOpinion mealOpinion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mealOpinion.Id)
            {
                return BadRequest();
            }

            db.Entry(mealOpinion).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MealOpinionExists(id))
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

        // POST: api/MealOpinions
        [ResponseType(typeof(MealOpinion))]
        public IHttpActionResult PostMealOpinion(MealOpinion mealOpinion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MealOpinions.Add(mealOpinion);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = mealOpinion.Id }, mealOpinion);
        }

        // DELETE: api/MealOpinions/5
        [ResponseType(typeof(MealOpinion))]
        public IHttpActionResult DeleteMealOpinion(int id)
        {
            MealOpinion mealOpinion = db.MealOpinions.Find(id);
            if (mealOpinion == null)
            {
                return NotFound();
            }

            db.MealOpinions.Remove(mealOpinion);
            db.SaveChanges();

            return Ok(mealOpinion);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MealOpinionExists(int id)
        {
            return db.MealOpinions.Count(e => e.Id == id) > 0;
        }
    }
}