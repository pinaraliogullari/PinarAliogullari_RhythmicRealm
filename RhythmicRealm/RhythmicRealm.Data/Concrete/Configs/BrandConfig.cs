using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RhythmicRealm.Entity.Concrete;

namespace RhythmicRealm.Data.Concrete.Configs
{
	public class BrandConfig : IEntityTypeConfiguration<Brand>
	{

		public void Configure(EntityTypeBuilder<Brand> builder)
		{
			builder.ToTable(nameof(Brand));
			builder.HasKey(b => b.Id);
			builder.Property(b => b.Id).ValueGeneratedOnAdd();
			builder.HasMany(b => b.Products).WithOne(p => p.Brand).HasForeignKey(p => p.BrandId);

			builder.Property(b => b.Name).IsRequired().HasMaxLength(100);
			builder.Property(b => b.ImageUrl).IsRequired().HasMaxLength(100);
			builder.Property(b => b.Url).IsRequired().HasMaxLength(100);

			builder.HasData(
				new Brand
				{
					Id = 1,
					Name = "Casio",
					Url = "casio",
					ImageUrl = "casio.png"

				},
				 new Brand
				 {
					 Id = 2,
					 Name = "Yamaha",
					 Url = "yamaha",
					 ImageUrl = "yamaha.png"

				 },
				  new Brand
				  {
					  Id = 3,
					  Name = "Schecter",
					  Url = "schecter",
					  ImageUrl = "schecter.png"

				  },
				   new Brand
				   {
					   Id = 4,
					   Name = "Antigua",
					   Url = "antigua",
					   ImageUrl = "antigua.png"

				   }
				);
		}
	}
}
