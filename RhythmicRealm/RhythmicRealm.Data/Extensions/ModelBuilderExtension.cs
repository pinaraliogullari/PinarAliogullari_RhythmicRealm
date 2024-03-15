using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RhythmicRealm.Entity.Concrete.Identity;
using RhythmicRealm.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    FirstName="Nisa",
                    LastName="Kırcalı",
                    UserName="nisakircali",
                    NormalizedUserName="NISAKIRCALI",
                    Email="nisakircali@gmail.com",
                    NormalizedEmail="NISAKIRCALI@GMAIL.COM",
                    Gender="Kadın",
                    DateOfBirth=new DateTime(1990,5,12),
                    Address="Halilpaşa Konağı Caddesi Kemeraltı Sokak No:4 D:2 Üsküdar",
                    City="İstanbul",
                    PhoneNumber="5558779966",
                    EmailConfirmed=true
                },
                new User
                {
                    FirstName="Mehmet",
                    LastName="Aksu",
                    UserName="mehmetaksu",
                    NormalizedUserName="MEHMETAKSU",
                    Email="mehmetaksu@gmail.com",
                    NormalizedEmail="MEHMETAKSU@GMAIL.COM",
                    Gender="Erkek",
                    DateOfBirth=new DateTime(1993,7,16),
                    Address="Halilpaşa Konağı Caddesi Kemeraltı Sokak No:4 D:2 Üsküdar",
                    City="İstanbul",
                    PhoneNumber="5387996655",
                    EmailConfirmed=true
                },
                new User
                {
                    FirstName="Ertan",
                    LastName="Kemaloğlu",
                    UserName="ertankemaloglu",
                    NormalizedUserName="ERTANKEMALOGLU",
                    Email="ertankemaloglu@gmail.com",
                    NormalizedEmail="ERTANKEMALOGLU@GMAIL.COM",
                    Gender="Erkek",
                    DateOfBirth=new DateTime(1993,7,16),
                    Address="Halilpaşa Konağı Caddesi Kemeraltı Sokak No:4 D:2 Üsküdar",
                    City="İstanbul",
                    PhoneNumber="5387996655",
                    EmailConfirmed=true
                },
                new User
                {
                    FirstName="İdil",
                    LastName="Gökçek",
                    UserName="idilgökcek",
                    NormalizedUserName="IDILGOKCEK",
                    Email="idilgokcek@gmail.com",
                    NormalizedEmail="IDILGOKCEK@GMAIL.COM",
                    Gender="Kadın",
                    DateOfBirth=new DateTime(1993,7,16),
                    Address="Halilpaşa Konağı Caddesi Kemeraltı Sokak No:4 D:2 Üsküdar",
                    City="İstanbul",
                    PhoneNumber="5387996655",
                    EmailConfirmed=true
                }
            };

            modelBuilder.Entity<User>().HasData(users);
            #endregion

            #region Şifre İşlemleri

            var passwordHasher = new PasswordHasher<User>();
            users[0].PasswordHash = passwordHasher.HashPassword(users[0], "Qsc987.");
            users[1].PasswordHash = passwordHasher.HashPassword(users[1], "Qsc987.");
            users[2].PasswordHash = passwordHasher.HashPassword(users[2], "Qsc987.");
            users[3].PasswordHash = passwordHasher.HashPassword(users[3], "Qsc987.");

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
                    RoleId=roles.Where(r=>r.Name=="Admin").FirstOrDefault().Id,
                },
                new IdentityUserRole<string>
                {
                    UserId=users[3].Id,
                    RoleId=roles.Where(r=>r.Name=="Customer").FirstOrDefault().Id,
                }
            };
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(userRoles);
            #endregion

            #region Alışveriş Sepeti İşlemleri

            List<ShoppingBasket> shoppingBaskets = new List<ShoppingBasket>
            {
                new ShoppingBasket{ Id=1, UserId=users[0].Id } ,
                new ShoppingBasket{ Id=2, UserId=users[1].Id } ,
                new ShoppingBasket{ Id=3, UserId=users[2].Id } ,
                new ShoppingBasket{ Id=4, UserId=users[3].Id }
            };
            modelBuilder.Entity<ShoppingBasket>().HasData(shoppingBaskets);

            #endregion
        }
    }
}
