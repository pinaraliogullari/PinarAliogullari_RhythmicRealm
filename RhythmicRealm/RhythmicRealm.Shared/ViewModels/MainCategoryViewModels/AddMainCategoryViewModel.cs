using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RhythmicRealm.Shared.ViewModels.MainCategoryViewModels
{
    public class AddMainCategoryViewModel
    {
        [DisplayName("Ana Kategori Adı")]
        [Required(ErrorMessage = "{0} alanı boş bırakılmamalıdır.")]
        [MinLength(5, ErrorMessage = "{0} alanı uzunluğu {1} karakterden az girilmemelidir.")]
        [MaxLength(100, ErrorMessage = "{0} alanı uzunluğu {1} karakterden çok girilmemelidir.")]
       
        public string Name { get; set; }
        public bool IsActive { get; set; }

        [DisplayName("Url")]
        [Required(ErrorMessage = "{0} alanı boş bırakılmamalıdır.")]
        [MinLength(5, ErrorMessage = "{0} alanı uzunluğu {1} karakterden az girilmemelidir.")]
        [MaxLength(100, ErrorMessage = "{0} alanı uzunluğu {1} karakterden çok girilmemelidir.")]
        public string Url { get; set; }
    }
}
