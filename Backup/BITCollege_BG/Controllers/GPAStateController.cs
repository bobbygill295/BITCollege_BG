using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using BITCollege_BG.Models;

namespace BITCollege_BG.Controllers
{
    public class GPAStateController : ApiController
    {
        private BITCollege_BGContext db = new BITCollege_BGContext();

        // GET api/GPAState
        public IEnumerable<GPAState> GetGPAStates()
        {
            return db.GPAStates.AsEnumerable();
        }

        // GET api/GPAState/5
        public GPAState GetGPAState(int id)
        {
            GPAState gpastate = db.GPAStates.Find(id);
            if (gpastate == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return gpastate;
        }

        // PUT api/GPAState/5
        public HttpResponseMessage PutGPAState(int id, GPAState gpastate)
        {
            if (ModelState.IsValid && id == gpastate.GPAStateId)
            {
                db.Entry(gpastate).State = EntityState.Modified;

                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // POST api/GPAState
        public HttpResponseMessage PostGPAState(GPAState gpastate)
        {
            if (ModelState.IsValid)
            {
                db.GPAStates.Add(gpastate);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, gpastate);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = gpastate.GPAStateId }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/GPAState/5
        public HttpResponseMessage DeleteGPAState(int id)
        {
            GPAState gpastate = db.GPAStates.Find(id);
            if (gpastate == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.GPAStates.Remove(gpastate);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, gpastate);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}