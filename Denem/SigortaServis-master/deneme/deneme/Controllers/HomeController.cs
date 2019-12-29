using deneme.Models.Request;
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
        OfferRepository Bidrepo = new OfferRepository();
        UserRepository Urepo = new UserRepository();
        OfferController ofc = new OfferController();
        OfferCalculateRequest ocR = new OfferCalculateRequest();
        public ActionResult UserList()
        {
            return View(Urepo.SelectAll());
        }
        
        public ActionResult UserAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UserAdd(User user)
        {
            if (ModelState.IsValid)
            {
                Urepo.Add(user);
                ocR.UserId = user.ID;
                ocR.TCNo = user.Identity;
                ocR.Plate = user.Plate;
                ocR.LicenceNumber = user.LicenseSerialNumber;
                ocR.LicenceCode = user.LicenseSerialCode;
                ofc.CalculateOffer(ocR);
                
                return RedirectToAction("BidList");

            }

            return View("UserAdd");

        }

        //int id = 0;
        public ActionResult BidList()
        {
            return View(Bidrepo.GetByID(ocR.UserId));
        }
    }
}