using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using web.MODEL.Enums;

namespace web.MODEL.Entities
{
    public class Offer: BaseEntity
    {
        public Offer()
        {
        }
        public Offer(string companyName, string companyLogo, string explanation, decimal amount, int userId)
        {
            this.FirmName = companyName;
            this.FirmLogo = companyLogo;
            this.Explanation = explanation;
            this.Amount = amount;
            this.UserID = userId;
            CreatedDate = DateTime.Now;
            Status = DataStatus.Inserted;
        }
        public string FirmName { get; set; }

        public string FirmLogo { get; set; }

        public string Explanation { get; set; }

        public decimal Amount { get; set; }

        public int UserID { get; set; }

        public virtual User User { get; set; }

    }
}
