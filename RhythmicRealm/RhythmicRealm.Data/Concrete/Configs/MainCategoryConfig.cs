using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RhythmicRealm.Entity.Concrete;

namespace RhythmicRealm.Data.Concrete.Configs
{
	public class MainCategoryConfig : IEntityTypeConfiguration<MainCategory>
	{
		public void Configure(EntityTypeBuilder<MainCategory> builder)
		{
			builder.ToTable(nameof(MainCategory));
			builder.HasKey(m => m.Id);
			builder.Property(m => m.Id).ValueGeneratedOnAdd();
			builder.HasMany(m => m.SubCategories).WithOne(s => s.MainCategory).HasForeignKey(s => s.MainCategoryId);

			builder.Property(m => m.Name).IsRequired().HasMaxLength(50);
			builder.Property(m => m.Url).IsRequired().HasMaxLength(50);
			;
			builder.HasData(
				    new MainCategory
				    {
					Id = 1,
					Name = "Tuşlular",
					Url = "tuslular"
				    },
					new MainCategory
					{
						Id = 2,
						Name = "Telliler",
						Url = "telliler"
					},
					new MainCategory
					{
						Id = 3,
						Name = "Yaylılar",
						Url = "yaylilar"
					},
					new MainCategory
					{
						Id = 4,
						Name = "Nefesliler",
						Url = "nefesliler"
					},
					new MainCategory
					{
						Id = 5,
						Name = "Davul Perküsyon",
						Url = "davul-perkusyon"
					}
				);
		}
	}
}
