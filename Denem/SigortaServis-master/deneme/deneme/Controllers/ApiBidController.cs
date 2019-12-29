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
using web.BLL.RepositoryPattern.ConcreteRepository;
using web.DAL.Context;
using web.MODEL.Entities;

namespace deneme.Controllers
{
    public class ApiBidController : ApiController
    {
        User user = new User();
        OfferRepository birepo = new OfferRepository();
        Offer bid = new Offer();
        Random rnd = new Random();

        public IHttpActionResult PostBid1(int id ,string plaka, string tckn, string seri, string kod)
        {
            bid.FirmName = "Şirket 1";
            bid.FirmLogo = "Logo 1";
            bid.Explanation = "Şirket 1 sigortası";
            bid.Amount = rnd.Next(500, 1000);
            bid.UserID = id;
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                birepo.Add(bid);
                return Ok("Başarılı");
            }
            catch (Exception)
            {
                return Ok("Daha sonra tekrar deneyiniz");
            }
        }

        public IHttpActionResult PostBid2(int id, string plaka, string tckn, string seri, string kod)
        {
            bid.FirmName = "Şirket 2";
            bid.FirmLogo = "Logo 2";
            bid.Explanation = "Şirket 2 sigortası";
            bid.Amount = rnd.Next(500, 1000);
            bid.UserID = id;
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                birepo.Add(bid);
                return Ok("Başarılı");
            }
            catch (Exception)
            {
                return Ok("Daha sonra tekrar deneyiniz");
            }
        }

        public IHttpActionResult PostBid3(int id, string plaka, string tckn, string seri, string kod)
        {
            bid.FirmName = "Şirket 3";
            bid.FirmLogo = "Logo 3";
            bid.Explanation = "Şirket 3 sigortası";
            bid.Amount = rnd.Next(500, 1000);
            bid.UserID = id;
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                birepo.Add(bid);
                return Ok("Başarılı");
            }
            catch (Exception)
            {
                return Ok("Daha sonra tekrar deneyiniz");
            }
        }

        #region MyRegion
        // POST: api/ApiBid
        [ResponseType(typeof(User))]
        public IHttpActionResult PostUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Users.Add(user);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = user.ID }, user);
        }

        private MyDBContext db = new MyDBContext();

        // GET: api/ApiBid
        public IQueryable<User> GetUsers()
        {
            return db.Users;
        }

        // GET: api/ApiBid/5
        [ResponseType(typeof(User))]
        public IHttpActionResult GetUser(int id)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // PUT: api/ApiBid/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUser(int id, User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user.ID)
            {
                return BadRequest();
            }

            db.Entry(user).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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


        // DELETE: api/ApiBid/5
        [ResponseType(typeof(User))]
        public IHttpActionResult DeleteUser(int id)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            db.Users.Remove(user);
            db.SaveChanges();

            return Ok(user);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserExists(int id)
        {
            return db.Users.Count(e => e.ID == id) > 0;
        }
        #endregion

    }
}