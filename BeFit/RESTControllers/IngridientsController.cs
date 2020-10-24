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
    public class IngridientsController : ApiController
    {
        private DietCenterContext db = new DietCenterContext();

        // GET: api/Ingridients
        public IQueryable<Ingridient> GetIngridients()
        {
            return db.Ingridients;
        }

        // GET: api/Ingridients/5
        [ResponseType(typeof(Ingridient))]
        public IHttpActionResult GetIngridient(int id)
        {
            Ingridient ingridient = db.Ingridients.Find(id);
            if (ingridient == null)
            {
                return NotFound();
            }

            return Ok(ingridient);
        }

        // PUT: api/Ingridients/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutIngridient(int id, Ingridient ingridient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ingridient.Id)
            {
                return BadRequest();
            }

            db.Entry(ingridient).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IngridientExists(id))
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

        // POST: api/Ingridients
        [ResponseType(typeof(Ingridient))]
        public IHttpActionResult PostIngridient(Ingridient ingridient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Ingridients.Add(ingridient);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = ingridient.Id }, ingridient);
        }

        // DELETE: api/Ingridients/5
        [ResponseType(typeof(Ingridient))]
        public IHttpActionResult DeleteIngridient(int id)
        {
            Ingridient ingridient = db.Ingridients.Find(id);
            if (ingridient == null)
            {
                return NotFound();
            }

            db.Ingridients.Remove(ingridient);
            db.SaveChanges();

            return Ok(ingridient);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool IngridientExists(int id)
        {
            return db.Ingridients.Count(e => e.Id == id) > 0;
        }
    }
}