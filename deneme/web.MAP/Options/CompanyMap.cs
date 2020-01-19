using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using web.MODEL.Entities;

namespace web.MAP.Options
{
    public class CompanyMap: BaseMap<Company>
    {
        public CompanyMap()
        {
            ToTable("SIRKETLER");
            Property(x => x.CompanyName).HasColumnName("FIRMAADI");
        }
    }
}
