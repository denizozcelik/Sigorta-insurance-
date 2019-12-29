using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using web.MODEL.Entities;
using System.Data.Entity.ModelConfiguration;

namespace web.MAP.Options
{
    public abstract class BaseMap<T> : EntityTypeConfiguration<T> where T : BaseEntity
    {
        public BaseMap()
        {
            HasKey(x => x.ID);
            Property(x => x.CreatedDate).HasColumnName("Olusturma Tarihi").HasColumnType("datetime2").IsOptional();
            Property(x => x.ModifiedDate).HasColumnName("Guncelleme tarihi").HasColumnType("datetime2").IsOptional();
            Property(x => x.CreatedBy).HasColumnName("Olusturan kisi").HasMaxLength(30).IsOptional();
            Property(x => x.ModifiedBy).HasColumnName("Güncelleyen").HasMaxLength(30).IsOptional(); ;
            Property(x => x.Status).HasColumnName("Veri Durumu").IsOptional();
        }
    }
}
