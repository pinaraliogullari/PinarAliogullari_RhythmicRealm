using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace RhythmicRealm.Shared.ViewModels.ProductViewModels
{
    public class AddProductViewModel
    {


        [DisplayName("Ürün Adı")]
        [Required(ErrorMessage = "{0} alanı boş bırakılmamalıdır.")]
        [MinLength(5, ErrorMessage = "{0} alanı uzunluğu {1} karakterden az girilmemelidir.")]
        [MaxLength(100, ErrorMessage = "{0} alanı uzunluğu {1} karakterden çok girilmemelidir.")]
        public string Name { get; set; }

        public string ImageUrl { get; set; } 


        [DisplayName("Url")]
        [Required(ErrorMessage = "{0} alanı boş bırakılmamalıdır.")]
        public string Url { get; set; }


        [DisplayName("Ürün Açıklaması")]
        [Required(ErrorMessage = "{0} alanı boş bırakılmamalıdır.")]
        public string Description { get; set; }


        [DisplayName("Ürün Özellikleri")]
        [Required(ErrorMessage = "{0} alanı boş bırakılmamalıdır.")]
        public string Properties { get; set; }


        [DisplayName("Fiyat")]
        [Required(ErrorMessage = "{0} alanı boş bırakılmamalıdır.")]
        //[RegularExpression(@"^[0-9]+(\.[0-9]{1,2})",ErrorMessage ="Bu alanda virgülden sonra en fazla 2 basamak olmalıdır.")]
        public decimal Price { get; set; }


        [DisplayName("Ana Sayfa")]
        public bool IsHome { get; set; }


        [DisplayName("Aktif")]
        public bool IsActive { get; set; }

        public int BrandId { get; set; }
        public int SubCategoryId { get; set; }



    }
}
