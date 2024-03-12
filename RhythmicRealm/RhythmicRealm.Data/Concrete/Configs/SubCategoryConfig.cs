using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RhythmicRealm.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhythmicRealm.Data.Concrete.Configs
{
	public class SubCategoryConfig : IEntityTypeConfiguration<SubCategory>
	{
		public void Configure(EntityTypeBuilder<SubCategory> builder)
		{
			builder.ToTable(nameof(SubCategory));
			builder.HasKey(s => s.Id);
			builder.Property(s => s.Id).ValueGeneratedOnAdd();
			builder.HasMany(s => s.Products).WithOne(p => p.SubCategory).HasForeignKey(p => p.SubCategoryId);
			builder.HasOne(s => s.MainCategory).WithMany(m => m.SubCategories).HasForeignKey(s => s.MainCategoryId);

			builder.Property(s => s.Name).IsRequired().HasMaxLength(100);
			builder.Property(s => s.Url).IsRequired().HasMaxLength(100);
			builder.HasData(
			new SubCategory
			{
				Id = 1,
				Name = "Piyanolar",
				Url = "piyanolar",
				MainCategoryId = 1,

			},
			new SubCategory
			{
				Id = 2,
				Name = "Klavyeler",
				Url = "klavyeler",
				MainCategoryId = 1,

			},
			new SubCategory
			{
				Id = 3,
				Name = "Akordiyonlar",
				Url = "akordiyonlar",
				MainCategoryId = 1,

			},
			new SubCategory
			{
				Id = 4,
				Name = "Elektro Gitarlar",
				Url = "elektro-gitarlar",
				MainCategoryId = 2,

			},
			new SubCategory
			{
				Id = 5,
				Name = "Akustik Gitarlar",
				Url = "akustik-gitarlar",
				MainCategoryId = 2,

			},
			new SubCategory
			{
				Id = 6,
				Name = "Mandolinler",
				Url = "mandolinler",
				MainCategoryId = 2,

			},
			new SubCategory
			{
				Id = 7,
				Name = "Ukuleleler",
				Url = "ukuleleler",
				MainCategoryId = 2,

			},
			new SubCategory
			{
				Id = 8,
				Name = "Kemanlar",
				Url = "kemanlar",
				MainCategoryId = 3,

			},
			new SubCategory
			{
				Id = 9,
				Name = "Viyolalar",
				Url = "viyolalar",
				MainCategoryId = 3,

			},
			new SubCategory
			{
				Id = 10,
				Name = "Çellolar",
				Url = "çellolar",
				MainCategoryId = 3,

			},
			new SubCategory
			{
				Id = 11,
				Name = "Saksafonlar",
				Url = "saksafonlar",
				MainCategoryId = 4,

			},
			new SubCategory
			{
				Id = 12,
				Name = "Klarnetler",
				Url = "klarnetler",
				MainCategoryId = 4,

			},
			new SubCategory
			{
				Id = 13,
				Name = "Mızıkalar",
				Url = "mızıkalar",
				MainCategoryId = 4,

			},
			new SubCategory
			{
				Id = 14,
				Name = "Yan Flütler",
				Url = "yan-flütler",
				MainCategoryId = 4,

			},
			new SubCategory
			{
				Id = 15,
				Name = "Akustik Davul",
				Url = "akustik-davullar",
				MainCategoryId = 5,

			},
			new SubCategory
			{
				Id = 16,
				Name = "Perküsyonlar",
				Url = "perküsyonlar",
				MainCategoryId = 5,

			},
			new SubCategory
			{
				Id = 17,
				Name = "Ziller",
				Url = "ziller",
				MainCategoryId = 5,

			},
			new SubCategory
			{
				Id = 18,
				Name = "Bagetler",
				Url = "bagetler",
				MainCategoryId = 5,

			}


			);

		}
	}
}
