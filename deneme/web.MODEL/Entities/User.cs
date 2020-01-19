using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace web.MODEL.Entities
{
    public class User : BaseEntity
    {
        public User()
        {
        }
        ///Plaka, TCKN, Ruhsat Seri Kodu ve Ruhsat Seri No

        [Required(ErrorMessage = "{0} alanı bos gecilemez"), MaxLength(12, ErrorMessage = "{0} alanı {1} karakteri asamaz")]
        [Display(Name ="Plaka")]
        public string Plate { get; set; }


        [Required(ErrorMessage = "{0} alanı bos gecilemez"), MaxLength(11, ErrorMessage = "{0} alanı {1} karakteri asamaz"),MinLength(11,ErrorMessage = "{0} alanı {1} karakterden az olamaz")]
        [Display(Name = "Tc Kimlik No")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Sadece sayısal değer giriniz")]
        public string Identity { get; set; }


        [Required(ErrorMessage = "{0} alanı bos gecilemez"), MaxLength(8, ErrorMessage = "{0} alanı {1} karakteri asamaz")]
        [Display(Name = "Ruhsat Seri Kodu")]
        public string LicenseSerialCode { get; set; }


        [Required(ErrorMessage = "{0} alanı bos gecilemez"), MaxLength(8, ErrorMessage = "{0} alanı {1} karakteri asamaz")]
        [Display(Name = "Ruhsat Seri No")]
        public string LicenseSerialNumber { get; set; }

        public virtual List<Offer> Offers { get; set; }
    }
}
