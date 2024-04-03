using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhythmicRealm.Entity.Concrete.Others
{
	public class Favorite
	{
		public int Id { get; set; }
		public string UserId { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; } 
		public DateTime CreatedDate { get; set; }
	}
}
