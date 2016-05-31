using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MyWedding.Models;
using System.Data.Entity;
using MyWedding.Repository;

namespace MyWedding.Controllers.Api
{
    public class GuestbookMessagesController : ApiController
    {
        private MyWeddingbContext _db = new MyWeddingbContext();

        public List<Message> GetMessages()
        {
            // the guestbook only shows public messages
            return _db.Messages.Where(o => o.Public == true).OrderByDescending(o => o.Date).ToList();
        }

        [HttpGet]
        public IHttpActionResult GetMessage(int Id)
        {
            Message m = _db.Messages.Find(Id);
            if (m == null)
            {
                return NotFound();
            }
            return Ok(m);
        }

        [HttpPost]
        public IHttpActionResult CreateMessage(Message message)
        {
            if (ModelState.IsValid)
            {
                _db.Messages.Add(message);
                _db.SaveChanges();
                return CreatedAtRoute("DefaultApi", new { id = message.Id }, message);
            }
            return BadRequest(ModelState);
        }

        [HttpPut]
        public IHttpActionResult UpdateMessage(Message message)
        {
            if (ModelState.IsValid)
            {

                _db.Entry(message).State = EntityState.Modified;

                _db.SaveChanges();
                return CreatedAtRoute("DefaultApi", new { id = message.Id }, message);
            }
            return BadRequest(ModelState);
        }

        [HttpDelete]
        public IHttpActionResult DeleteMessage(int id)
        {
            Message m = _db.Messages.Find(id);
            if (m == null)
            {
                return NotFound();
            }
            _db.Messages.Remove(m);
            _db.SaveChanges();
            return Ok(m);
        }
    }
}

