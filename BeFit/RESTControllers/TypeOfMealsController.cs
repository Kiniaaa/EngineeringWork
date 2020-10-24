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
    public class TypeOfMealsController : ApiController
    {
        private DietCenterContext db = new DietCenterContext();

        // GET: api/TypeOfMeals
        public IQueryable<TypeOfMeal> GetTypeOfMeals()
        {
            return db.TypeOfMeals;
        }

        // GET: api/TypeOfMeals/5
        [ResponseType(typeof(TypeOfMeal))]
        public IHttpActionResult GetTypeOfMeal(int id)
        {
            TypeOfMeal typeOfMeal = db.TypeOfMeals.Find(id);
            if (typeOfMeal == null)
            {
                return NotFound();
            }

            return Ok(typeOfMeal);
        }

        // PUT: api/TypeOfMeals/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTypeOfMeal(int id, TypeOfMeal typeOfMeal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != typeOfMeal.Id)
            {
                return BadRequest();
            }

            db.Entry(typeOfMeal).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypeOfMealExists(id))
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

        // POST: api/TypeOfMeals
        [ResponseType(typeof(TypeOfMeal))]
        public IHttpActionResult PostTypeOfMeal(TypeOfMeal typeOfMeal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TypeOfMeals.Add(typeOfMeal);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = typeOfMeal.Id }, typeOfMeal);
        }

        // DELETE: api/TypeOfMeals/5
        [ResponseType(typeof(TypeOfMeal))]
        public IHttpActionResult DeleteTypeOfMeal(int id)
        {
            TypeOfMeal typeOfMeal = db.TypeOfMeals.Find(id);
            if (typeOfMeal == null)
            {
                return NotFound();
            }

            db.TypeOfMeals.Remove(typeOfMeal);
            db.SaveChanges();

            return Ok(typeOfMeal);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TypeOfMealExists(int id)
        {
            return db.TypeOfMeals.Count(e => e.Id == id) > 0;
        }
    }
}