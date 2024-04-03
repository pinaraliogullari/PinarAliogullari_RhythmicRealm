using RhythmicRealm.Entity.Abstract;
using RhythmicRealm.Entity.Concrete.Others;
using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhythmicRealm.Entity.Concrete
{
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Url { get; set; }
        public List<Product> Products { get; set; }
		public List<BrandMainCategory> BrandMainCategories { get; set; }

	}
}
