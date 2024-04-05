using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhythmicRealm.Entity.Concrete.Identity
{
	public class User:IdentityUser
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string? Gender { get; set; }
		public DateTime? DateOfBirth { get; set; }
		public string? Address { get; set; }
		public string? City { get; set; }
		public bool Statu { get; set; }
		public string RoleId { get; set; } 
        public List<ShoppingBasket> ShoppingBaskets { get; set; }
		public DateTime CreatedDate { get; set; } = DateTime.Now;

    }
}
