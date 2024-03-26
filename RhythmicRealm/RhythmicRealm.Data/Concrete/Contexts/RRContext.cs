using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RhythmicRealm.Data.Concrete.Configs;
using RhythmicRealm.Entity.Concrete.Identity;
using RhythmicRealm.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RhythmicRealm.Data.Extensions;

namespace RhythmicRealm.Data.Concrete.Contexts
{
    public class RRContext : IdentityDbContext<User, Role, string>
	{
		public RRContext(DbContextOptions<RRContext> options) : base(options)
		{

		}
		public DbSet<Brand> Brands { get; set; }
		public DbSet<MainCategory> Categories { get; set; }
		public DbSet<SubCategory> MainCategories { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<BrandMainCategory> BrandMainCategories { get; set; }
        public DbSet<ShoppingBasket> ShoppingBaskets { get; set; }
        public DbSet<ShoppingBasketItem> ShoppingBasketItems { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Order>()
				.HasKey(o => o.Id);
			modelBuilder.Entity<ShoppingBasket>()
				.HasOne(s => s.Order)
				.WithOne(o => o.ShoppingBasket)
				.HasForeignKey<Order>(o => o.Id);

			modelBuilder.SeedData();
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(BrandConfig).Assembly);
			base.OnModelCreating(modelBuilder);
		}
	}
}
