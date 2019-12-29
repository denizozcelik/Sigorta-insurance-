using System;
using System.Runtime.Serialization;

namespace deneme.Models.Request
{
    public class OfferCalculateRequest
    {
        public int UserId { get; set; }
        public string Plate { get; set; }
        public string TCNo { get; set; }
        public string LicenceCode { get; set; }
        public string LicenceNumber { get; set; }
    }
}