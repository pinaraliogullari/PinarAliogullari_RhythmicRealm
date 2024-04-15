using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RhythmicRealm.Entity.Concrete;
using RhythmicRealm.Entity.Concrete.Identity;
using RhythmicRealm.Entity.Concrete.Others;

namespace RhythmicRealm.Data.Extensions
{
	public static class ModelBuilderExtension
    {
        //bir tipi extend ederken; oluşturulan sınıf ve içerisindeki metot static olmalı. metot içinde extend edilen tip this keywordü ile parametre olarak verilmeli.
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            #region Rol Bilgileri

            List<Role> roles = new List<Role>
            {
                new Role{Name="SuperAdmin", Description="Süper Yönetici haklarını taşıyan rol", NormalizedName="SUPERADMIN"},
                new Role{Name="Admin", Description="Yönetici haklarını taşıyan rol", NormalizedName="ADMIN"},
                new Role{Name="Customer", Description="Müşteri haklarını taşıyan rol", NormalizedName="CUSTOMER"}
            };
            modelBuilder.Entity<Role>().HasData(roles);

            #endregion

            #region Kullanıcı Bilgileri

            List<User> users = new List<User>
            {
				new User
				{
					FirstName="Pınar",
					LastName="Alioğulları Kaya",
					UserName="pinaraliogullarikaya",
					NormalizedUserName="PINARALIOGULLARIKAYA",
					Email="rhythmicsite@hotmail.com",
					NormalizedEmail="RHYTHMICSITE@HOTMAIL.COM",
					Gender="Kadın",
					DateOfBirth=new DateTime(1996,8,18),
					Address="Halilpaşa Konağı Caddesi Kemeraltı Sokak No:4 D:2 Üsküdar",
					City="İstanbul",
					PhoneNumber="5558779966",
					EmailConfirmed=true,
					Statu=true,

				},
				new User
                {
                    FirstName="Stanley",
                    LastName="Kubrick",
                    UserName="stanleykubrick",
                    NormalizedUserName="STANLEYKUBRICK",
                    Email="stanleykubrick@gmail.com",
                    NormalizedEmail="STANLEYKUBRICK@GMAIL.COM",
                    Gender="Erkek",
                    DateOfBirth=new DateTime(1990,5,12),
                    Address="Halilpaşa Konağı Caddesi Kemeraltı Sokak No:4 D:2 Üsküdar",
                    City="İstanbul",
                    PhoneNumber="5558779966",
                    EmailConfirmed=true,
                    Statu=true,
                   
                },
                new User
                {
                    FirstName="Andrei",
                    LastName="Tarkovsky",
                    UserName="andreitarkovsky",
                    NormalizedUserName="ANDREI TARKOVSKY",
                    Email="andreitarkovsky@gmail.com",
                    NormalizedEmail="ANDREITARKOVSKY@GMAIL.COM",
                    Gender="Erkek",
                    DateOfBirth=new DateTime(1993,7,16),
                    Address="Halilpaşa Konağı Caddesi Kemeraltı Sokak No:4 D:2 Üsküdar",
                    City="İstanbul",
                    PhoneNumber="5387996655",
                    EmailConfirmed=true,
                    Statu=true,
           
                },
            };

            modelBuilder.Entity<User>().HasData(users);
            #endregion

            #region Şifre İşlemleri

            var passwordHasher = new PasswordHasher<User>();
            users[0].PasswordHash = passwordHasher.HashPassword(users[0], "Rhythmicsite987.");
            users[1].PasswordHash = passwordHasher.HashPassword(users[1], "Rhythmicsite987.");
            users[2].PasswordHash = passwordHasher.HashPassword(users[2], "Tarkovsky987.");

            #endregion

            #region Yönetici Mesaj İşlemleri

            List<Message> adminMessages= new List<Message>()
            {
                new Message { 
                    Id=1,
                    SenderMail= "rhythmicsite@hotmail.com",
                    ReceiverMail= "stanleykubrick@gmail.com",
					Subject="Destek talebi",
                    Content="Merhaba,Admin şifremi değiştirmem gerekiyor. DEstek rica ederim",
                },
                new Message
                {
                    Id = 2,
                    SenderMail = "rhythmicsite@hotmail.com",
                    ReceiverMail = "stanleykubrick@gmail.com",
                    Subject = "Destek talebi",
                    Content = "Merhaba,Güncel fiyat listesini gönderebilir misin?"
                },
                new Message
                {
                    Id = 3,
                    SenderMail = "rhythmicsite@hotmail.com",
                    ReceiverMail = "stanleykubrick@gmail.com",
                    Subject = "Şubeler hk",
                    Content = "Merhaba, Şube listesinin güncel versiyonunu gönderebilir misin?"
                },
            
                 new Message
                {
                    Id = 4,
                    SenderMail = "stanleykubrick@gmail.com",
                    ReceiverMail = "rhythmicsite@hotmail.com",
                    Subject = "Stok hk",
                    Content = "Merhaba, Piyano stoğu bu hafta güncelleniyor."
                },
                 new Message
                {
                    Id = 5,
                    SenderMail = "stanleykubrick@gmail.com",
                    ReceiverMail = "rhythmicsite@hotmail.com",
                    Subject = "Giriş hatası",
                    Content = "Merhaba, Hata çözüldü."
                },
                    new Message
                {
                    Id = 6,
				    SenderMail = "stanleykubrick@gmail.com",
					ReceiverMail = "rhythmicsite@hotmail.com",
					Subject = "Ürün listeleri hk",
                    Content = "Merhaba, Ürün listelerinin son hali pazartesi günü iltilecektir."
                },
                       new Message
                {
                    Id = 7,
                    SenderMail = "stanleykubrick@gmail.com",
                    ReceiverMail = "rhythmicsite@hotmail.com",
                    Subject = "Ürün görselleri hk",
                    Content = "Merhaba, Yeni ürün görselleri için çekimler devam ediyor."
                },
                 new Message
                {
                    Id = 8,
                    SenderMail = "stanleykubrick@gmail.com",
					ReceiverMail = "rhythmicsite@hotmail.com",
                    Subject = "Ürün görselleri hk",
                    Content = "Merhaba, Kategori düzenlemesi tamamlandı.."
                },
                  new Message
                {
                    Id = 9,
					SenderMail = "stanleykubrick@gmail.com",
					ReceiverMail = "rhythmicsite@hotmail.com",
					Subject = "Teslimat hk",
                    Content = "Merhaba, Hava koşullarından dolayı aksayan teslimatlar var.Kargolar ile görüşüyoruz."
                },
                  new Message
                {
                    Id = 10,
				    SenderMail = "stanleykubrick@gmail.com",
					ReceiverMail = "rhythmicsite@hotmail.com",
					Subject = "Destek talebi",
                    Content = "Merhaba, Yetkilendirmeler tamalandı, kontrol edebilir misin?."
                },
            };
            modelBuilder.Entity<Message>().HasData(adminMessages);
			#endregion

			#region Kullanıcı Mesaj İşlemleri

			List<Contact> userMessages = new List<Contact>()
			{
				new Contact {
					Id=1,
					SenderMail= "andreitarkovsky@gmail.com",
					ReceiverMail= "rhythmicsite@hotmail.com",
					Subject="Teslimat hk",
					Content="Merhaba,Uzun süredir siparişimi bekliyorum. Ne zaman ulaşacağı konusunda bilgi rica ederim.",
				},
			
			};
			modelBuilder.Entity<Contact>().HasData(userMessages);
			#endregion

			#region Rol Atama İşlemleri
			List<IdentityUserRole<string>> userRoles = new List<IdentityUserRole<string>>
            {
                new IdentityUserRole<string>
                {
                     UserId=users[0].Id,
                     RoleId=roles.Where(r=>r.Name=="SuperAdmin").FirstOrDefault().Id,
                },
                new IdentityUserRole<string>
                {
                    UserId=users[1].Id,
                    RoleId=roles.Where(r=>r.Name=="Admin").FirstOrDefault().Id,
                }
                ,
                new IdentityUserRole<string>
                {
                    UserId=users[2].Id,
                    RoleId=roles.Where(r=>r.Name=="Customer").FirstOrDefault().Id,
                },

            };
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(userRoles);
            #endregion

            #region Alışveriş Sepeti İşlemleri

            List<ShoppingBasket> shoppingBaskets = new List<ShoppingBasket>
            {
                new ShoppingBasket{ Id=1, UserId=users[0].Id } ,
                new ShoppingBasket{ Id=2, UserId=users[1].Id } ,
                new ShoppingBasket{ Id=3, UserId=users[2].Id } ,
         
            };
            modelBuilder.Entity<ShoppingBasket>().HasData(shoppingBaskets);

            #endregion
        }
    }
}
