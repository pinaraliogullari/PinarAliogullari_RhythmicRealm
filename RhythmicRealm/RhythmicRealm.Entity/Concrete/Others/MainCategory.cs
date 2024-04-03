using RhythmicRealm.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhythmicRealm.Entity.Concrete
{
    public class MainCategory : BaseEntity,IMainEntity
    {
		public int Id { get; set; }
		public string Url { get; set; }
		public DateTime CreatedDate { get; set; } = DateTime.Now;
		public List<SubCategory> SubCategories { get; set; }
		
	}
}
