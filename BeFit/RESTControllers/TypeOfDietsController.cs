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
    public class TypeOfDietsController : ApiController
    {
        private DietCenterContext db = new DietCenterContext();

        // GET: api/TypeOfDiets
        public IQueryable<TypeOfDiet> GetTypeOfDiets()
        {
            return db.TypeOfDiets;
        }

        // GET: api/TypeOfDiets/5
        [ResponseType(typeof(TypeOfDiet))]
        public IHttpActionResult GetTypeOfDiet(int id)
        {
            TypeOfDiet typeOfDiet = db.TypeOfDiets.Find(id);
            if (typeOfDiet == null)
            {
                return NotFound();
            }

            return Ok(typeOfDiet);
        }

        // PUT: api/TypeOfDiets/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTypeOfDiet(int id, TypeOfDiet typeOfDiet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != typeOfDiet.Id)
            {
                return BadRequest();
            }

            db.Entry(typeOfDiet).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypeOfDietExists(id))
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

        // POST: api/TypeOfDiets
        [ResponseType(typeof(TypeOfDiet))]
        public IHttpActionResult PostTypeOfDiet(TypeOfDiet typeOfDiet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TypeOfDiets.Add(typeOfDiet);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = typeOfDiet.Id }, typeOfDiet);
        }

        // DELETE: api/TypeOfDiets/5
        [ResponseType(typeof(TypeOfDiet))]
        public IHttpActionResult DeleteTypeOfDiet(int id)
        {
            TypeOfDiet typeOfDiet = db.TypeOfDiets.Find(id);
            if (typeOfDiet == null)
            {
                return NotFound();
            }

            db.TypeOfDiets.Remove(typeOfDiet);
            db.SaveChanges();

            return Ok(typeOfDiet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TypeOfDietExists(int id)
        {
            return db.TypeOfDiets.Count(e => e.Id == id) > 0;
        }
    }
}