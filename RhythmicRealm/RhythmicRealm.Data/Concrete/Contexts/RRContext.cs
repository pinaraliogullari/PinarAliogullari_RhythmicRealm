﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RhythmicRealm.Data.Concrete.Configs;
using RhythmicRealm.Entity.Concrete.Identity;
using RhythmicRealm.Entity.Concrete;
using RhythmicRealm.Data.Extensions;
using RhythmicRealm.Entity.Concrete.Others;

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
		public DbSet<BrandMainCategory> BrandMainCategories { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<Contact> Contacts { get; set; }
		public DbSet<Message> Messages { get; set; }
        public DbSet<ShoppingBasket> ShoppingBaskets { get; set; }
        public DbSet<ShoppingBasketItem> ShoppingBasketItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<ImageFile> ImageFiles { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
		{

			modelBuilder.SeedData();
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(BrandConfig).Assembly);
			base.OnModelCreating(modelBuilder);
		}
	}
}
