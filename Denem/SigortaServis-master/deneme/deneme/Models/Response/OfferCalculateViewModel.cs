using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace deneme.Models.Response
{
    public class OfferCalculateViewModel
    {
        public string CompanyName { get; set; }
        public string CompanyLogoPath { get; set; }
        public string Explanation { get; set; }
        public decimal OfferAmount { get; set; }
        public string Plate { get; set; }
        public int UserId { get; set; }
    }
}