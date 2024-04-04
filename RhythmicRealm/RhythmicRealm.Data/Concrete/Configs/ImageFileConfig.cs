using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RhythmicRealm.Entity.Concrete.Others;

namespace RhythmicRealm.Data.Concrete.Configs
{
    public class ImageFileConfig : IEntityTypeConfiguration<ImageFile>
	{
		public void Configure(EntityTypeBuilder<ImageFile> builder)
		{
			builder.ToTable(nameof(ImageFile));
			builder.HasKey(i => i.Id);
			builder.Property(i => i.Id).ValueGeneratedOnAdd();

			builder.Property(i => i.ImageName).IsRequired().HasMaxLength(100);
			builder.Property(i => i.ImagePath).IsRequired().HasMaxLength(250);
			builder.HasData(
			new ImageFile
			{
				Id = 1,
				ImageName = "Akordiyon",
				ImagePath = "/images/products/akordiyon1.png"

			},
            new ImageFile
            {
                Id = 2,
                ImageName = "Akustik Davul",
                ImagePath = "/images/products/akustikdavul1.png"	

            },
            new ImageFile
            {
                Id = 3,
                ImageName = "Akustik Gitar-1",
                ImagePath = "/images/products/akustikgitar1.png"

            },
            new ImageFile
            {
                Id = 4,
                ImageName = "Akustik Gitar-2",
                ImagePath = "/images/products/akustikgitar2.png"

            },
            new ImageFile
            {
                Id = 5,
                ImageName = "Akustik Gitar-3",
                ImagePath = "/images/products/akustikgitar3.png"

            },
            new ImageFile
            {
                Id = 6,
                ImageName = "Baget-1",
                ImagePath = "/images/products/baget1.png"

            },
            new ImageFile
            {
                Id = 7,
                ImageName = "Baget-2",
                ImagePath = "/images/products/baget2.png"

            },
            new ImageFile
            {
                Id = 8,
                ImageName = "Çello",
                ImagePath = "/images/products/cello1.png"

            },
            new ImageFile
            {
                Id = 9,
                ImageName = "Elektro Gitar-1",
                ImagePath = "/images/products/elektrogitar1.png"

            },
            new ImageFile
            {
                Id = 10,
                ImageName = "Elektro Gitar-2",
                ImagePath = "/images/products/elektrogitar2.png"

            },
            new ImageFile
            {
                Id = 11,
                ImageName = "Keman-1",
                ImagePath = "/images/products/keman1.png"

            },
            new ImageFile
            {
                Id = 12,
                ImageName = "Keman-2",
                ImagePath = "/images/products/keman2.png"

            },
            new ImageFile
            {
                Id = 13,
                ImageName = "Keman-3",
                ImagePath = "/images/products/keman3.png"

            },
            new ImageFile
            {
                Id = 14,
                ImageName = "Klarnet-1",
                ImagePath = "/images/products/klarnet1.png"

            },
             new ImageFile
             {
                 Id = 15,
                 ImageName = "Klarnet-2",
                 ImagePath = "/images/products/klarnet2.png"

             },
             new ImageFile
             {
                 Id = 16,
                 ImageName = "Klarnet-3",
                 ImagePath = "/images/products/klarnet3.png"

             },
            new ImageFile
            {
                Id = 17,
                ImageName = "Klavye-1",
                ImagePath = "/images/products/klavye1.png"

            }, 
            new ImageFile
            {
                Id = 18,
                ImageName = "Klavye-2",
                ImagePath = "/images/products/klavye2.png"

            }, 
            new ImageFile
            {
                Id = 19,
                ImageName = "Klavye-3",
                ImagePath = "/images/products/klavye3.png"

            },
            new ImageFile
            {
                Id = 20,
                ImageName = "Mandolin-1",
                ImagePath = "/images/products/mandolin1.png"

            }, 
            new ImageFile
            {
                Id = 21,
                ImageName = "Mandolin-2",
                ImagePath = "/images/products/mandolin2.png"

            }, 
            new ImageFile
            {
                Id = 22,
                ImageName = "Mızıka",
                ImagePath = "/images/products/mızıka1.png"

            },
            new ImageFile
            {
                Id = 23,
                ImageName = "Perküsyon-1",
                ImagePath = "/images/products/perkusyon1.png"

            }, 
            new ImageFile
            {
                Id = 24,
                ImageName = "Perküsyon-2",
                ImagePath = "/images/products/perkusyon2.png"

            },
            new ImageFile
            {
                Id = 25,
                ImageName = "Piyano-1",
                ImagePath = "/images/products/piyano1.png"

            }, 
            new ImageFile
            {
                Id = 26,
                ImageName = "Piyano-2",
                ImagePath = "/images/products/piyano2.png"

            }, 
            new ImageFile
            {
                Id = 27,
                ImageName = "Piyano-3",
                ImagePath = "/images/products/piyano3.png"

            }, 
            new ImageFile
            {
                Id = 28,
                ImageName = "Saksafon-1",
                ImagePath = "/images/products/saksafon1.png"

            }, 
            new ImageFile
            {
                Id = 29,
                ImageName = "Saksafon-2",
                ImagePath = "/images/products/saksafon2.png"

            },
            new ImageFile
            {
                Id = 30,
                ImageName = "Ukulele-1",
                ImagePath = "/images/products/ukulele1.png"

            }, 
            new ImageFile
            {
                Id = 31,
                ImageName = "Ukulele-2",
                ImagePath = "/images/products/ukulele2.png"

            }, 
            new ImageFile
            {
                Id = 32,
                ImageName = "Viyola-1",
                ImagePath = "/images/products/viyola1.png"

            }, 
            new ImageFile
            {
                Id = 33,
                ImageName = "Viyola-2",
                ImagePath = "/images/products/viyola2.png"

            }, 
            new ImageFile
            {
                Id = 34,
                ImageName = "Yan Flüt-1",
                ImagePath = "/images/products/yanflut1.png"

            }, 
            new ImageFile
            {
                Id = 35,
                ImageName = "Yan Flüt-2",
                ImagePath = "/images/products/viyola1.png"

            },
            new ImageFile
            {
                Id = 36,
                ImageName = "Yan Flüt-3",
                ImagePath = "/images/products/yanflut3.png"

            }, 
            new ImageFile
            {
                Id = 37,
                ImageName = "Zil-1",
                ImagePath = "/images/products/zil1.png"

            }, 
            new ImageFile
            {
                Id = 38,
                ImageName = "Zil-2",
                ImagePath = "/images/products/zil2.png"

            });

		}
	}
}
