using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace web.MODEL.Entities
{
    public class Company : BaseEntity
    {
        public string CompanyName { get; set; }
        public string CompanyLogo { get; set; }
        public string CompanyOfferCalculateWebServiceUrl { get; set; }

        
    }
}
