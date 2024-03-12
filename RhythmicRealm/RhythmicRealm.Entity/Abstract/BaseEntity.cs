using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhythmicRealm.Entity.Abstract
{
	public abstract class BaseEntity
	{
		public string Name { get; set; }
		public DateTime UpdatedDate { get; set; } = DateTime.Now;
		public bool IsActive { get; set; } = true;
		public bool IsDeleted { get; set; }
	}
}
