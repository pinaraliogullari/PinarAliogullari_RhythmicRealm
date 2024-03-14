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
        [MaxLength(100, ErrorMessage = "{0} alanı uzunluğu {1} karakterden bçok girilmemelidir.")]
        [JsonPropertyName("Name")]
        public string Name { get; set; }


        [DisplayName("Görsel Url")]
        [Required(ErrorMessage = "{0} alanı boş bırakılmamalıdır.")]
        [JsonPropertyName("ImageUrl")]
        public string ImageUrl { get; set; }


        [DisplayName("Url")]
        [Required(ErrorMessage = "{0} alanı boş bırakılmamalıdır.")]
        [JsonPropertyName("Url")]
        public string Url { get; set; }


        [DisplayName("Ürün Açıklaması")]
        [Required(ErrorMessage = "{0} alanı boş bırakılmamalıdır.")]
        [JsonPropertyName("Description")]
        public string Description { get; set; }


        [DisplayName("Ürün Özellikleri")]
        [Required(ErrorMessage = "{0} alanı boş bırakılmamalıdır.")]
        [JsonPropertyName("Properties")]
        public string Properties { get; set; }


        [DisplayName("Fiyat")]
        [Required(ErrorMessage = "{0} alanı boş bırakılmamalıdır.")]
        [JsonPropertyName("Price")]
        public decimal Price { get; set; }


        [DisplayName("Ana Sayfa")]
        [JsonPropertyName("IsHome")]
        public bool IsHome { get; set; }


        [DisplayName("Aktif")]
        [JsonPropertyName("IsActive")]
        public bool IsActive { get; set; }


      
    }
}
