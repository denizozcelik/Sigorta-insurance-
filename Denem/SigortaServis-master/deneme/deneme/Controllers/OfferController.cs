using deneme.Models.Request;
using System.Web.Http;
using web.BLL.RepositoryPattern.ConcreteRepository;
using web.MODEL.Entities;
using System.Net;
using System.Net.Http;
using System.Linq;
using System.Collections;
using System.Web.Http.Description;
using System.Collections.Generic;
using deneme.Models.Response;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;
using System;

namespace deneme.Controllers
{
    public class OfferController : ApiController
    {
        private readonly OfferRepository birepo;
        private readonly UserRepository userRepository;
        private readonly CompanyRepository companyRepository;
        public OfferController()
        {
            birepo = new OfferRepository();
            userRepository = new UserRepository();
            companyRepository = new CompanyRepository();
        }

        [Route("calculateOffer")]
        [HttpPost]
        [ResponseType(typeof(List<OfferCalculateViewModel>))]
        public IHttpActionResult CalculateOffer(OfferCalculateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = userRepository.GetByID(request.UserId);
            user.ID = request.UserId;
            user.Identity = request.TCNo;
            user.Plate = request.Plate;
            user.LicenseSerialCode = request.LicenceCode;
            user.LicenseSerialNumber = request.LicenceNumber;

            // Not : Burada kaçtane firmanın web servislerine post atılacağı bilinmiyor. Bunun için öncelikle tekliflerin hesaplanacağı web servislerin url listesi bir tabloda tutulması gerekiyor.
            // static olarak 3 web service atayacağız. daha sonrasında ise bu webservice lere call atacağız her response yi bir listeye atacağız daha sonra da bu listeyi ekrada göstereceğiz.
            // Response ları atacağımız listeyi de database e kaydedeceğiz.
            var companiewList = companyRepository.SelectAll();

            var response = new List<OfferCalculateViewModel>(); // ön yüz e döneceğimiz liste
            var index = 0;
            var random = new Random();
            user.Offers = new List<Offer>();
            
            foreach (var item in companiewList)
            {
                //TO DO : BUrada HttpClient class ı ile ilgili wes service url lere post atılıp response ları almak gerekiyor. Bu kısmı pas geçiyorum.
                // burada responsaların döndüğünü farz edelim
                var description = $"response : description {index}";
                var offer = new Offer(item.CompanyName, item.CompanyLogo, description, random.Next(500, 1000), user.ID);

                user.Offers.Add(offer);

                response.Add(MapOfferCalculate(offer, user.Plate, user.ID));
                index++;
            }
            userRepository.Save();
            return Ok(response);
        }
        private OfferCalculateViewModel MapOfferCalculate(Offer offer, string plate, int userId)
        {
            return new OfferCalculateViewModel
            {
                Explanation = offer.Explanation,
                OfferAmount = offer.Amount,
                CompanyLogoPath = offer.FirmLogo,
                CompanyName = offer.FirmName,
                Plate = plate,
                UserId = userId
            };
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

            userRepository.Add(user);
            userRepository.Save();

            return CreatedAtRoute("DefaultApi", new { id = user.ID }, user);
        }

        // GET: api/ApiBid
        public IQueryable<User> GetUsers()
        {
            return userRepository.SelectAll().AsQueryable();
        }

        // GET: api/ApiBid/5
        [ResponseType(typeof(User))]
        public IHttpActionResult GetUser(int id)
        {
            var user = userRepository.GetByID(id);

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

            try
            {
                userRepository.Update(user);
                userRepository.Save();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw new DbUpdateConcurrencyException(ex.Message);
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }


        // DELETE: api/ApiBid/5
        [ResponseType(typeof(User))]
        public IHttpActionResult DeleteUser(int id)
        {
            var user = userRepository.GetByID(id);
            if (user == null)
            {
                return NotFound();
            }

            userRepository.Delete(user);
            userRepository.Save();

            return Ok(user);
        }

        private bool UserExists(int id)
        {
            return userRepository.SelectAll().Count(e => e.ID == id) > 0;
        }
        #endregion
    }
}
