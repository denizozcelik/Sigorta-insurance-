using deneme.Models.Request;
using deneme.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web.BLL.RepositoryPattern.ConcreteRepository;
using web.MODEL.Entities;

namespace deneme.Controllers
{
    public class HomeController : Controller
    {
        private readonly OfferRepository offerRepository;
        private readonly CompanyRepository companyRepository;
        private readonly UserRepository userRepository;

        private List<OfferCalculateViewModel> ResponseData
        {
            get { return (List<OfferCalculateViewModel>)Session["CalculationResult"]; }
        }

        public HomeController()
        {
            offerRepository = new OfferRepository();
            companyRepository = new CompanyRepository();
            userRepository = new UserRepository();
        }
        public ActionResult UserList()
        {
            return View(userRepository.SelectAll());
        }

        [HttpGet]
        public ActionResult UserAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UserAdd(OfferCalculateRequest request)
        {
            //var user = userRepository.GetByID(request.UserId);
            var user = new User();

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
                response.Add(MapOfferCalculate(offer));
                index++;
            }

            userRepository.Add(user);

            userRepository.Save();

            response.ForEach(x => { x.Plate = user.Plate; x.UserId = user.ID; });

            Session["CalculationResult"] = response;

            return RedirectToAction("BidList", "Home");
        }

        private OfferCalculateViewModel MapOfferCalculate(Offer offer)
        {
            return new OfferCalculateViewModel
            {
                Explanation = offer.Explanation,
                OfferAmount = offer.Amount,
                CompanyLogoPath = offer.FirmLogo,
                CompanyName = offer.FirmName
            };
        }

        [HttpGet]
        public ActionResult BidList()
        {
            return View(ResponseData);
        }
    }
}