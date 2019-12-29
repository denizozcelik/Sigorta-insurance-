using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using web.MODEL.Entities;

namespace web.MAP.Options
{

    public class UserMap : BaseMap<User>
    {
        public UserMap()
        {
            ToTable("KULLANICILAR");
            Property(x => x.Plate).HasColumnName("PLAKA").IsRequired();
            Property(x => x.Identity).HasColumnName("TCKIMLIKNO").IsRequired();
            Property(x => x.LicenseSerialCode).HasColumnName("RUHSATSERIKODU").IsRequired();
            Property(x => x.LicenseSerialNumber).HasColumnName("RUHSATSERINO").IsRequired();

            #region #Relationship

            HasMany(x => x.Offers).WithRequired().HasForeignKey(o => o.UserID);

            #endregion
        }
    }
}
