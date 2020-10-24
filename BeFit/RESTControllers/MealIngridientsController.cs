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
    public class MealIngridientsController : ApiController
    {
        private DietCenterContext db = new DietCenterContext();

        // GET: api/MealIngridients
        public IQueryable<MealIngridient> GetMealIngridients()
        {
            return db.MealIngridients;
        }

        // GET: api/MealIngridients/5
        [ResponseType(typeof(MealIngridient))]
        public IHttpActionResult GetMealIngridient(int id)
        {
            MealIngridient mealIngridient = db.MealIngridients.Find(id);
            if (mealIngridient == null)
            {
                return NotFound();
            }

            return Ok(mealIngridient);
        }

        // PUT: api/MealIngridients/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMealIngridient(int id, MealIngridient mealIngridient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mealIngridient.Id)
            {
                return BadRequest();
            }

            db.Entry(mealIngridient).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MealIngridientExists(id))
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

        // POST: api/MealIngridients
        [ResponseType(typeof(MealIngridient))]
        public IHttpActionResult PostMealIngridient(MealIngridient mealIngridient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MealIngridients.Add(mealIngridient);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = mealIngridient.Id }, mealIngridient);
        }

        // DELETE: api/MealIngridients/5
        [ResponseType(typeof(MealIngridient))]
        public IHttpActionResult DeleteMealIngridient(int id)
        {
            MealIngridient mealIngridient = db.MealIngridients.Find(id);
            if (mealIngridient == null)
            {
                return NotFound();
            }

            db.MealIngridients.Remove(mealIngridient);
            db.SaveChanges();

            return Ok(mealIngridient);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MealIngridientExists(int id)
        {
            return db.MealIngridients.Count(e => e.Id == id) > 0;
        }
    }
}