using RhythmicRealm.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhythmicRealm.Entity.Concrete
{
    public class Product:BaseEntity,IMainEntity
    {
		public int Id {get; set;}
		public string ImageUrl { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public string Properties { get; set; }
        public decimal Price { get; set; }
		public DateTime CreatedDate { get; set; } = DateTime.Now;
		public bool IsHome { get; set; }
        public SubCategory SubCategory { get; set; }
        public int SubCategoryId { get; set; }
        public Brand Brand { get; set; }
        public int BrandId { get; set; }
        public List<ShoppingBasketItem> ShoppingBasketItems { get; set; }

    }
}
