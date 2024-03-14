using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhythmicRealm.Shared.ViewModels.ProductViewModels
{
    public class InProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public string Properties { get; set; }
        public decimal Price { get; set; }
        public bool IsHome { get; set; }
        public bool IsActive { get; set; }
    }
}
