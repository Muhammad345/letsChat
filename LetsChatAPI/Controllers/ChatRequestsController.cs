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
using LetsChatAPI.Models;

namespace LetsChatAPI.Controllers
{
    public class ChatRequestsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/ChatRequests
        public IQueryable<PreChatRequest> GetChatRequests()
        {
            return db.ChatRequests;
        }

        // GET: api/ChatRequests/5
        [ResponseType(typeof(PreChatRequest))]
        public IHttpActionResult GetChatRequest(Guid id)
        {
            PreChatRequest preChatRequest = db.ChatRequests.Find(id);
            if (preChatRequest == null)
            {
                return NotFound();
            }

            return Ok(preChatRequest);
        }

        // PUT: api/ChatRequests/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutChatRequest(Guid id, PreChatRequest preChatRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != preChatRequest.ChatRequestId)
            {
                return BadRequest();
            }

            db.Entry(preChatRequest).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChatRequestExists(id))
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

        // POST: api/ChatRequests
        [ResponseType(typeof(PreChatRequest))]
        public IHttpActionResult PostChatRequest(PreChatRequest preChatRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ChatRequests.Add(preChatRequest);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ChatRequestExists(preChatRequest.ChatRequestId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = preChatRequest.ChatRequestId }, preChatRequest);
        }

        // DELETE: api/ChatRequests/5
        [ResponseType(typeof(PreChatRequest))]
        public IHttpActionResult DeleteChatRequest(Guid id)
        {
            PreChatRequest preChatRequest = db.ChatRequests.Find(id);
            if (preChatRequest == null)
            {
                return NotFound();
            }

            db.ChatRequests.Remove(preChatRequest);
            db.SaveChanges();

            return Ok(preChatRequest);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ChatRequestExists(Guid id)
        {
            return db.ChatRequests.Count(e => e.ChatRequestId == id) > 0;
        }
    }
}