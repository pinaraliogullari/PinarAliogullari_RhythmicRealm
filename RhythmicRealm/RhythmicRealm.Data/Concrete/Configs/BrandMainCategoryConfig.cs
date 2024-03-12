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
	public class BrandMainCategoryConfig : IEntityTypeConfiguration<BrandMainCategory>
	{
		public void Configure(EntityTypeBuilder<BrandMainCategory> builder)
		{
			builder.HasKey(bm => new { bm.BrandId, bm.MainCategoryId });
			builder.ToTable(nameof(BrandMainCategory));
			builder.HasData(

				new BrandMainCategory { BrandId = 1, MainCategoryId = 1 },
				new BrandMainCategory { BrandId = 1, MainCategoryId = 2 },
				new BrandMainCategory { BrandId = 1, MainCategoryId = 3 },

				new BrandMainCategory { BrandId = 2, MainCategoryId = 1 },
				new BrandMainCategory { BrandId = 2, MainCategoryId = 3 },

				new BrandMainCategory { BrandId = 3, MainCategoryId = 3 },
				new BrandMainCategory { BrandId = 3, MainCategoryId = 4 },

				new BrandMainCategory { BrandId = 4, MainCategoryId = 5 });
		}
	}
}
