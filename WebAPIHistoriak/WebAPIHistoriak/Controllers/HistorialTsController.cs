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
using WebAPIHistoriak.Models;

namespace WebAPIHistoriak.Controllers
{
    public class HistorialTsController : ApiController
    {
        private DataProductsEntities db = new DataProductsEntities();

        // GET: api/HistorialTs
        public IEnumerable<HistorialT> GetHistorialTs()
        {
            IEnumerable<Models.HistorialT> lst;
            using (Models.DataProductsEntities db = new Models.DataProductsEntities())
            {
                lst = db.HistorialTs.ToList();
            }
            return db.HistorialTs;
        }

        // GET: api/HistorialTs/5
        [ResponseType(typeof(HistorialT))]
        public IHttpActionResult GetHistorialT(int id)
        {
            HistorialT historialT = db.HistorialTs.Find(id);
            if (historialT == null)
            {
                return NotFound();
            }

            return Ok(historialT);
        }

        // PUT: api/HistorialTs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutHistorialT(int id, HistorialT historialT)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != historialT.id)
            {
                return BadRequest();
            }

            db.Entry(historialT).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HistorialTExists(id))
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

        // POST: api/HistorialTs
        [ResponseType(typeof(HistorialT))]
        public IHttpActionResult PostHistorialT(HistorialT historialT)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.HistorialTs.Add(historialT);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = historialT.id }, historialT);
        }

        // DELETE: api/HistorialTs/5
        [ResponseType(typeof(HistorialT))]
        public IHttpActionResult DeleteHistorialT(int id)
        {
            HistorialT historialT = db.HistorialTs.Find(id);
            if (historialT == null)
            {
                return NotFound();
            }

            db.HistorialTs.Remove(historialT);
            db.SaveChanges();

            return Ok(historialT);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HistorialTExists(int id)
        {
            return db.HistorialTs.Count(e => e.id == id) > 0;
        }
    }
}