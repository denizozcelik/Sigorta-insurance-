using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using web.MODEL.Entities;

namespace web.MAP.Options
{
    public class OfferMap : BaseMap<Offer>
    {
        public OfferMap()
        {
            ToTable("TEKLIFLER");
            Property(x => x.FirmName).HasColumnName("FIRMAADI").IsRequired();
            Property(x => x.FirmLogo).HasColumnName("FIRMALOGO").IsRequired();
            Property(x => x.Explanation).HasColumnName("TEKLIFACIKLAMASI").IsRequired();
            Property(x => x.Amount).HasColumnName("TEKLIFTUTAR").IsRequired();
            Property(x => x.UserID).HasColumnName("USERID").IsRequired();
        }
    }
}
