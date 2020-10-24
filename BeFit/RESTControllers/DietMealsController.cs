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
    public class DietMealsController : ApiController
    {
        private DietCenterContext db = new DietCenterContext();

        // GET: api/DietMeals
        public IQueryable<DietMeal> GetDietMeals()
        {
            return db.DietMeals;
        }

        // GET: api/DietMeals/5
        [ResponseType(typeof(DietMeal))]
        public IHttpActionResult GetDietMeal(int id)
        {
            DietMeal dietMeal = db.DietMeals.Find(id);
            if (dietMeal == null)
            {
                return NotFound();
            }

            return Ok(dietMeal);
        }

        // PUT: api/DietMeals/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDietMeal(int id, DietMeal dietMeal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dietMeal.Id)
            {
                return BadRequest();
            }

            db.Entry(dietMeal).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DietMealExists(id))
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

        // POST: api/DietMeals
        [ResponseType(typeof(DietMeal))]
        public IHttpActionResult PostDietMeal(DietMeal dietMeal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DietMeals.Add(dietMeal);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = dietMeal.Id }, dietMeal);
        }

        // DELETE: api/DietMeals/5
        [ResponseType(typeof(DietMeal))]
        public IHttpActionResult DeleteDietMeal(int id)
        {
            DietMeal dietMeal = db.DietMeals.Find(id);
            if (dietMeal == null)
            {
                return NotFound();
            }

            db.DietMeals.Remove(dietMeal);
            db.SaveChanges();

            return Ok(dietMeal);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DietMealExists(int id)
        {
            return db.DietMeals.Count(e => e.Id == id) > 0;
        }
    }
}