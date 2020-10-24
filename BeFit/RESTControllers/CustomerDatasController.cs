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
    public class CustomerDatasController : ApiController
    {
        private DietCenterContext db = new DietCenterContext();

        // GET: api/CustomerDatas
        public IQueryable<CustomerData> GetCustomerDatas()
        {
            return db.CustomerDatas;
        }

        // GET: api/CustomerDatas/5
        [ResponseType(typeof(CustomerData))]
        public IHttpActionResult GetCustomerData(int id)
        {
            CustomerData customerData = db.CustomerDatas.Find(id);
            if (customerData == null)
            {
                return NotFound();
            }

            return Ok(customerData);
        }

        // PUT: api/CustomerDatas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCustomerData(int id, CustomerData customerData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != customerData.Id)
            {
                return BadRequest();
            }

            db.Entry(customerData).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerDataExists(id))
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

        // POST: api/CustomerDatas
        [ResponseType(typeof(CustomerData))]
        public IHttpActionResult PostCustomerData(CustomerData customerData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CustomerDatas.Add(customerData);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = customerData.Id }, customerData);
        }

        // DELETE: api/CustomerDatas/5
        [ResponseType(typeof(CustomerData))]
        public IHttpActionResult DeleteCustomerData(int id)
        {
            CustomerData customerData = db.CustomerDatas.Find(id);
            if (customerData == null)
            {
                return NotFound();
            }

            db.CustomerDatas.Remove(customerData);
            db.SaveChanges();

            return Ok(customerData);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CustomerDataExists(int id)
        {
            return db.CustomerDatas.Count(e => e.Id == id) > 0;
        }
    }
}