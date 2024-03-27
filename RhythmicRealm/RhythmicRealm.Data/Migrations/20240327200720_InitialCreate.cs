using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RhythmicRealm.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    Gender = table.Column<string>(type: "TEXT", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Address = table.Column<string>(type: "TEXT", nullable: true),
                    City = table.Column<string>(type: "TEXT", nullable: true),
                    Statu = table.Column<bool>(type: "INTEGER", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: true),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Brand",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Url = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserName = table.Column<string>(type: "TEXT", nullable: true),
                    UserMail = table.Column<string>(type: "TEXT", nullable: true),
                    Subject = table.Column<string>(type: "TEXT", nullable: true),
                    Content = table.Column<string>(type: "TEXT", nullable: true),
                    IsRead = table.Column<bool>(type: "INTEGER", nullable: false),
                    MessageDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MainCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Url = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SenderMail = table.Column<string>(type: "TEXT", nullable: true),
                    ReceiverMail = table.Column<string>(type: "TEXT", nullable: true),
                    Subject = table.Column<string>(type: "TEXT", nullable: true),
                    Content = table.Column<string>(type: "TEXT", nullable: true),
                    IsRead = table.Column<bool>(type: "INTEGER", nullable: false),
                    MessageDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingBaskets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingBaskets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingBaskets_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BrandMainCategory",
                columns: table => new
                {
                    BrandId = table.Column<int>(type: "INTEGER", nullable: false),
                    MainCategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrandMainCategory", x => new { x.BrandId, x.MainCategoryId });
                    table.ForeignKey(
                        name: "FK_BrandMainCategory_Brand_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brand",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BrandMainCategory_MainCategory_MainCategoryId",
                        column: x => x.MainCategoryId,
                        principalTable: "MainCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Url = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    MainCategoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubCategory_MainCategory_MainCategoryId",
                        column: x => x.MainCategoryId,
                        principalTable: "MainCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Address = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Order_ShoppingBaskets_Id",
                        column: x => x.Id,
                        principalTable: "ShoppingBaskets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ImageUrl = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Url = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Properties = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: false),
                    Price = table.Column<decimal>(type: "real", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsHome = table.Column<bool>(type: "INTEGER", nullable: false),
                    SubCategoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    BrandId = table.Column<int>(type: "INTEGER", nullable: false),
                    OrderId = table.Column<int>(type: "INTEGER", nullable: true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Brand_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brand",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Product_SubCategory_SubCategoryId",
                        column: x => x.SubCategoryId,
                        principalTable: "SubCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingBasketItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ShoppingBasketId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingBasketItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingBasketItems_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShoppingBasketItems_ShoppingBaskets_ShoppingBasketId",
                        column: x => x.ShoppingBasketId,
                        principalTable: "ShoppingBaskets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7668cc38-e9ea-4b9a-8d7f-fd6f16f4f126", null, "Müşteri haklarını taşıyan rol", "Customer", "CUSTOMER" },
                    { "c9eccf86-c605-4677-aa85-33854916dd78", null, "Yönetici haklarını taşıyan rol", "Admin", "ADMIN" },
                    { "d77d4ec3-6522-48c3-ba78-a27539075c47", null, "Süper Yönetici haklarını taşıyan rol", "SuperAdmin", "SUPERADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "City", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "Gender", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RoleId", "SecurityStamp", "Statu", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "52116a0f-e099-4a61-b791-53f77c224f29", 0, "Halilpaşa Konağı Caddesi Kemeraltı Sokak No:4 D:2 Üsküdar", "İstanbul", "f30b5f86-99b5-4ef6-8cec-de11c5587880", new DateTime(1993, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "ertankemaloglu@gmail.com", true, "Ertan", "Erkek", "Kemaloğlu", false, null, "ERTANKEMALOGLU@GMAIL.COM", "ERTANKEMALOGLU", "AQAAAAIAAYagAAAAEKkOcda+3kkWLdE14nQSGErgWkTjkkP2tL3QjvE3lgPYapbbWBCDDWA53NuuoXplTw==", "5387996655", false, "6e44e7ec-40b5-4464-b1eb-c2d02a499726", "1f25539a-df5c-4016-9a79-223e198b4446", true, false, "ertankemaloglu" },
                    { "620a2696-cc1a-4efb-a285-462a0c15c7ba", 0, "Halilpaşa Konağı Caddesi Kemeraltı Sokak No:4 D:2 Üsküdar", "İstanbul", "43202c76-bc31-41ae-9dc8-7de8c447f2c7", new DateTime(1990, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "nisakircali@gmail.com", true, "Nisa", "Kadın", "Kırcalı", false, null, "NISAKIRCALI@GMAIL.COM", "NISAKIRCALI", "AQAAAAIAAYagAAAAENBAWwATEXV/dNirYg7R0iDwcUpblMsA88P3Tt8sWdzeyquKSpYAysXbR7EbozZyNw==", "5558779966", false, "6e44e7ec-40b5-4464-b1eb-c2d02a499726", "c2fe0483-ddfa-4e38-b079-7e409057ec28", true, false, "nisakircali" },
                    { "b1fc1935-665d-40ae-b693-dacb98a39813", 0, "Halilpaşa Konağı Caddesi Kemeraltı Sokak No:4 D:2 Üsküdar", "İstanbul", "1dd3be1e-cd71-4457-9eff-d9fbc1546769", new DateTime(1993, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "mehmetaksu@gmail.com", true, "Mehmet", "Erkek", "Aksu", false, null, "MEHMETAKSU@GMAIL.COM", "MEHMETAKSU", "AQAAAAIAAYagAAAAEO7rE3s93Rc2nNXQYNMVMcy71CpIqi+vuIMmpLgrasql1dIH0ebuPx9P/+ylM99aIA==", "5387996655", false, "6e44e7ec-40b5-4464-b1eb-c2d02a499726", "b9622509-f346-4f63-ad17-b5e9448741f0", true, false, "mehmetaksu" }
                });

            migrationBuilder.InsertData(
                table: "Brand",
                columns: new[] { "Id", "ImageUrl", "Name", "Url" },
                values: new object[,]
                {
                    { 1, "casio.png", "Casio", "casio" },
                    { 2, "yamaha.png", "Yamaha", "yamaha" },
                    { 3, "schecter.png", "Schecter", "schecter" },
                    { 4, "antigua.png", "Antigua", "antigua" }
                });

            migrationBuilder.InsertData(
                table: "MainCategory",
                columns: new[] { "Id", "CreatedDate", "IsActive", "IsDeleted", "Name", "UpdatedDate", "Url" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 27, 23, 7, 20, 688, DateTimeKind.Local).AddTicks(7964), true, false, "Tuşlular", new DateTime(2024, 3, 27, 23, 7, 20, 688, DateTimeKind.Local).AddTicks(7979), "tuslular" },
                    { 2, new DateTime(2024, 3, 27, 23, 7, 20, 688, DateTimeKind.Local).AddTicks(7982), true, false, "Telliler", new DateTime(2024, 3, 27, 23, 7, 20, 688, DateTimeKind.Local).AddTicks(7982), "telliler" },
                    { 3, new DateTime(2024, 3, 27, 23, 7, 20, 688, DateTimeKind.Local).AddTicks(7983), true, false, "Yaylılar", new DateTime(2024, 3, 27, 23, 7, 20, 688, DateTimeKind.Local).AddTicks(7984), "yaylilar" },
                    { 4, new DateTime(2024, 3, 27, 23, 7, 20, 688, DateTimeKind.Local).AddTicks(7985), true, false, "Nefesliler", new DateTime(2024, 3, 27, 23, 7, 20, 688, DateTimeKind.Local).AddTicks(7985), "nefesliler" },
                    { 5, new DateTime(2024, 3, 27, 23, 7, 20, 688, DateTimeKind.Local).AddTicks(7986), true, false, "Davul Perküsyon", new DateTime(2024, 3, 27, 23, 7, 20, 688, DateTimeKind.Local).AddTicks(7986), "davul-perkusyon" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "7668cc38-e9ea-4b9a-8d7f-fd6f16f4f126", "52116a0f-e099-4a61-b791-53f77c224f29" },
                    { "d77d4ec3-6522-48c3-ba78-a27539075c47", "620a2696-cc1a-4efb-a285-462a0c15c7ba" },
                    { "c9eccf86-c605-4677-aa85-33854916dd78", "b1fc1935-665d-40ae-b693-dacb98a39813" }
                });

            migrationBuilder.InsertData(
                table: "BrandMainCategory",
                columns: new[] { "BrandId", "MainCategoryId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 2, 1 },
                    { 2, 3 },
                    { 3, 3 },
                    { 3, 4 },
                    { 4, 5 }
                });

            migrationBuilder.InsertData(
                table: "ShoppingBaskets",
                columns: new[] { "Id", "CreatedDate", "UpdatedDate", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 27, 23, 7, 20, 687, DateTimeKind.Local).AddTicks(3428), new DateTime(2024, 3, 27, 23, 7, 20, 687, DateTimeKind.Local).AddTicks(3451), "620a2696-cc1a-4efb-a285-462a0c15c7ba" },
                    { 2, new DateTime(2024, 3, 27, 23, 7, 20, 687, DateTimeKind.Local).AddTicks(3454), new DateTime(2024, 3, 27, 23, 7, 20, 687, DateTimeKind.Local).AddTicks(3454), "b1fc1935-665d-40ae-b693-dacb98a39813" },
                    { 3, new DateTime(2024, 3, 27, 23, 7, 20, 687, DateTimeKind.Local).AddTicks(3456), new DateTime(2024, 3, 27, 23, 7, 20, 687, DateTimeKind.Local).AddTicks(3456), "52116a0f-e099-4a61-b791-53f77c224f29" }
                });

            migrationBuilder.InsertData(
                table: "SubCategory",
                columns: new[] { "Id", "CreatedDate", "IsActive", "IsDeleted", "MainCategoryId", "Name", "UpdatedDate", "Url" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 27, 23, 7, 20, 689, DateTimeKind.Local).AddTicks(4722), true, false, 1, "Piyanolar", new DateTime(2024, 3, 27, 23, 7, 20, 689, DateTimeKind.Local).AddTicks(4728), "piyanolar" },
                    { 2, new DateTime(2024, 3, 27, 23, 7, 20, 689, DateTimeKind.Local).AddTicks(4730), true, false, 1, "Klavyeler", new DateTime(2024, 3, 27, 23, 7, 20, 689, DateTimeKind.Local).AddTicks(4731), "klavyeler" },
                    { 3, new DateTime(2024, 3, 27, 23, 7, 20, 689, DateTimeKind.Local).AddTicks(4732), true, false, 1, "Akordiyonlar", new DateTime(2024, 3, 27, 23, 7, 20, 689, DateTimeKind.Local).AddTicks(4732), "akordiyonlar" },
                    { 4, new DateTime(2024, 3, 27, 23, 7, 20, 689, DateTimeKind.Local).AddTicks(4733), true, false, 2, "Elektro Gitarlar", new DateTime(2024, 3, 27, 23, 7, 20, 689, DateTimeKind.Local).AddTicks(4733), "elektro-gitarlar" },
                    { 5, new DateTime(2024, 3, 27, 23, 7, 20, 689, DateTimeKind.Local).AddTicks(4734), true, false, 2, "Akustik Gitarlar", new DateTime(2024, 3, 27, 23, 7, 20, 689, DateTimeKind.Local).AddTicks(4735), "akustik-gitarlar" },
                    { 6, new DateTime(2024, 3, 27, 23, 7, 20, 689, DateTimeKind.Local).AddTicks(4736), true, false, 2, "Mandolinler", new DateTime(2024, 3, 27, 23, 7, 20, 689, DateTimeKind.Local).AddTicks(4736), "mandolinler" },
                    { 7, new DateTime(2024, 3, 27, 23, 7, 20, 689, DateTimeKind.Local).AddTicks(4737), true, false, 2, "Ukuleleler", new DateTime(2024, 3, 27, 23, 7, 20, 689, DateTimeKind.Local).AddTicks(4737), "ukuleleler" },
                    { 8, new DateTime(2024, 3, 27, 23, 7, 20, 689, DateTimeKind.Local).AddTicks(4738), true, false, 3, "Kemanlar", new DateTime(2024, 3, 27, 23, 7, 20, 689, DateTimeKind.Local).AddTicks(4738), "kemanlar" },
                    { 9, new DateTime(2024, 3, 27, 23, 7, 20, 689, DateTimeKind.Local).AddTicks(4739), true, false, 3, "Viyolalar", new DateTime(2024, 3, 27, 23, 7, 20, 689, DateTimeKind.Local).AddTicks(4740), "viyolalar" },
                    { 10, new DateTime(2024, 3, 27, 23, 7, 20, 689, DateTimeKind.Local).AddTicks(4740), true, false, 3, "Çellolar", new DateTime(2024, 3, 27, 23, 7, 20, 689, DateTimeKind.Local).AddTicks(4741), "çellolar" },
                    { 11, new DateTime(2024, 3, 27, 23, 7, 20, 689, DateTimeKind.Local).AddTicks(4742), true, false, 4, "Saksafonlar", new DateTime(2024, 3, 27, 23, 7, 20, 689, DateTimeKind.Local).AddTicks(4742), "saksafonlar" },
                    { 12, new DateTime(2024, 3, 27, 23, 7, 20, 689, DateTimeKind.Local).AddTicks(4743), true, false, 4, "Klarnetler", new DateTime(2024, 3, 27, 23, 7, 20, 689, DateTimeKind.Local).AddTicks(4743), "klarnetler" },
                    { 13, new DateTime(2024, 3, 27, 23, 7, 20, 689, DateTimeKind.Local).AddTicks(4744), true, false, 4, "Mızıkalar", new DateTime(2024, 3, 27, 23, 7, 20, 689, DateTimeKind.Local).AddTicks(4744), "mızıkalar" },
                    { 14, new DateTime(2024, 3, 27, 23, 7, 20, 689, DateTimeKind.Local).AddTicks(4745), true, false, 4, "Yan Flütler", new DateTime(2024, 3, 27, 23, 7, 20, 689, DateTimeKind.Local).AddTicks(4746), "yan-flütler" },
                    { 15, new DateTime(2024, 3, 27, 23, 7, 20, 689, DateTimeKind.Local).AddTicks(4747), true, false, 5, "Akustik Davul", new DateTime(2024, 3, 27, 23, 7, 20, 689, DateTimeKind.Local).AddTicks(4747), "akustik-davullar" },
                    { 16, new DateTime(2024, 3, 27, 23, 7, 20, 689, DateTimeKind.Local).AddTicks(4748), true, false, 5, "Perküsyonlar", new DateTime(2024, 3, 27, 23, 7, 20, 689, DateTimeKind.Local).AddTicks(4748), "perküsyonlar" },
                    { 17, new DateTime(2024, 3, 27, 23, 7, 20, 689, DateTimeKind.Local).AddTicks(4749), true, false, 5, "Ziller", new DateTime(2024, 3, 27, 23, 7, 20, 689, DateTimeKind.Local).AddTicks(4749), "ziller" },
                    { 18, new DateTime(2024, 3, 27, 23, 7, 20, 689, DateTimeKind.Local).AddTicks(4750), true, false, 5, "Bagetler", new DateTime(2024, 3, 27, 23, 7, 20, 689, DateTimeKind.Local).AddTicks(4750), "bagetler" }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "BrandId", "CreatedDate", "Description", "ImageUrl", "IsActive", "IsDeleted", "IsHome", "Name", "OrderId", "Price", "Properties", "SubCategoryId", "UpdatedDate", "Url" },
                values: new object[,]
                {
                    { 1, 2, new DateTime(2024, 3, 27, 23, 7, 20, 689, DateTimeKind.Local).AddTicks(2217), "102011060204 / PEARL RIVER / V-05 WH", "piyano1.png", true, false, false, "Pearl River V-05 Dijital Piyano", null, 25000m, "Teknik Özellikler : \r\n\r\nTuş Sistemi :   İtalyan üretimi  Fatar Grand-Response™ 88 Tuşlu Tuş yapısı -  Çekiç Aksiyon Sistemi - Dinamik Eğrili Sensör Sistemi - 4 Farklı Hassasiyet ayarı \r\n\r\nPolifoni : 512\r\n\r\nSes Sayısı :  26 farklı Ses -  Avrupa Konser tipi Kuyruklu Piyano  örneklemesi ile yapılmış ana piyano sesi  - Ritm Perküsyon Ses Dizilimli  Ses Örneklemeleri \r\n\r\nKullanım Özelikleri :  Çift Ses birleştirme,   Klayyede bölerek iki ses kullanımı ( Split ) \r\n\r\nMetronom : Mevcut \r\n\r\nTranspose : Mevcut \r\n\r\nBluetooth : Mevcut\r\n\r\nEfekt Özellikleri : Reverb ve Chorus Efektleri \r\n\r\nKayıt Özellikleri :  22000 Nota uzunluğuna kadar Kayıt imkanı \r\n\r\nKayıtlı Eserler :  75 farklı   Demo şarkıları \r\n\r\nBağlantılar : USB, Kulaklık Çıkışı ( 2 adet ) , Line in ve Line Out Bağlantıları  \r\n\r\nBluetooth Audio Bağlantısı : Mevcut\r\n\r\nSes Çıkışı :  25 Watt x 2 \r\n\r\nGenişlik : 137cm\r\n\r\nYükseklik : 81,5cm \r\n\r\nDerinlik : 42cm \r\n\r\nAğırlık : 46,5 Kg \r\n\r\nElektrik Bağlantısı :  DC 12V Adaptör ile Çalışır ", 1, new DateTime(2024, 3, 27, 23, 7, 20, 689, DateTimeKind.Local).AddTicks(2225), "pearl-river-v-05-dijital-piyano" },
                    { 2, 2, new DateTime(2024, 3, 27, 23, 7, 20, 689, DateTimeKind.Local).AddTicks(2235), "102021910201 / KURZWEIL / KAG100WHP\r\n", "piyano2.png", true, false, true, "Kurzweil Dijital Kuyruklu Piyano", null, 80000m, "Klavye: 88 standard-ölçülü hammer tuşlar (A0~C8) \r\nTuş hassasiyeti: 3 farklı descede seçilebilir tuş hassasiyeti\r\nEkran: 2*16 alphanumeric LCD Ekran\r\nPolifoni: 64 Ses\r\nHazır Programlar: 200\r\nKullanıcı Hazır Sesleri: 20\r\nGenel MIDI: Yok\r\nDemos Şarkılar: 71\r\nÖğrenilen Şarkılar 55\r\nSplits/Layers: Quick Split/Layer, easy access with adjustable relative volume\r\nTranspoze: Full transposition to any key, +/- one octave\r\nAkort: +/- 1 semitone\r\nEfektler: 8 reverb types (plus level); 8 chorus types (plus level); Treble/Bass EQ\r\nAuto-Accompaniment: 100 styles plus 1 user\r\nMetronom: Var\r\nRecorder/Sequencer: 2-Track\r\nSes Sistemş: 4-Hoparlör, 20W+15W, stereo\r\nSes Çıkışları: Stereo left/right RCA line outs (for connecting to external amplification)\r\nSes Girişleri: Stereo left/right RCA line ins (for connecting external sound sources)\r\nLine Çıkışı: Var\r\nKulaklık Girişi: (2) 1/4″ stereo kulaklık çıkışı\r\nUSB: (1) port;  MIDI ve audio over USBBluetooth:    Yes (incl. blue tooth receiver)\r\nPedals:    (3) Dahili switch-type: sustain, sostenuto, soft\r\nGüç: Internal Power Supply", 1, new DateTime(2024, 3, 27, 23, 7, 20, 689, DateTimeKind.Local).AddTicks(2235), "kurzveil-dijital-kuyruklu-piyano" },
                    { 3, 1, new DateTime(2024, 3, 27, 23, 7, 20, 689, DateTimeKind.Local).AddTicks(2238), "102010290110 / CASIO / AP270BK", "piyano3.png", true, false, false, "AP270BK Celviano Dijital Piyano ", null, 29999m, "TEKNİK ÖZELLİKLER\r\nKlavye: 88 tuş, Üç Sensörlü Ölçekli Çekiç Aksiyonlu Klavye II, benzetilmiş abanoz ve fildişi kaplama tuşlar\r\nDokunuş Tepkisi: 3 hassasiyet seviyesi, Kapalı\r\nSes Kaynağı: AiR ses kaynağı, damper rezonansı, çekiç tepkisi, damper parazit\r\nMaksimum Polifoni: 192\r\nTonlar: Kuyruklu Piyano 1, Kuyruklu Piyano 2 tonları dahil toplam 22 ton\r\nKatman / Bölme: Katman (Bas tonları hariç), Bölme (Yalnızca alt aralıktaki bas tonları)\r\nDijital Efektler: Reverb (4 tür), Chorus (4 tür), Brilliance (-3 - 0 - 3), DSP (bazı tonlarda dahilidir)\r\nDahili Şarkılar: 10 (Konser Çalma), 60 (Müzik Kitaplığı)\r\nŞarkı Genişletme: 10 şarkı (maks.) Şarkı başına en fazla yaklaşık 90 KB\r\nDers İşlevi: Bölüm AÇIK / KAPALI (Ders bölümü: Sağ el/Sol el)\r\nMetronom: Vuruş: 0 - 9 (Tempo aralığı: dörtlük = 20 - 255)\r\nMIDI Kaydedici: 2 kanal x 1 şarkı, maksimum yaklaşık 5.000 nota, gerçek zamanlı kayıt/playback\r\nNotaya Aktarma: 2 oktav (-12 yarı ton ~ 0 ~ +12 yarı ton)\r\nAkortlama Kontrolü: A4 = 415,5 Hz ~ 440,0 Hz ~ 465,9 Hz\r\nPedallar: 3 pedal (damper, yumuşak, sostenuto)\r\n*damper = açık/kapalı\r\nMIDI: Bu üründe MIDI terminalleri bulunmaz. Ürün ve bilgisayar arasındaki MIDI iletişimi, USB bağlantı noktası aracılığıyla yapılır.\r\nHoparlörler: 12 cm x 2\r\nAmp Çıkışı: 8W + 8W\r\n\r\nGiriş/Çıkış Uçları: KULAKLIK/ÇIKIŞ x 2 (Stereo standart)\r\n\r\nUSB: Tip B\r\n\r\nHarici güç (12V DC)\r\n\r\n* Bilgisayara bağlanmak amacıyla USB terminalini kullanmak için USB kablosu (A-B tipi) gereklidir.\r\nGüç Gereksinimleri: AC adaptör: AD-A12150LW\r\nBoyutlar (G x D x Y): 1.417 x 432 x 821mm (nota sehpası hariç)\r\nAğırlık: 36,6kg\r\nBirlikte Verilen Aksesuarlar: Piyano Taburesi, AC Adaptör (AD-A12150LW), Nota Sehpası ", 1, new DateTime(2024, 3, 27, 23, 7, 20, 689, DateTimeKind.Local).AddTicks(2238), "casio-ap20bk-celviano-dijital-piyano" },
                    { 4, 2, new DateTime(2024, 3, 27, 23, 7, 20, 689, DateTimeKind.Local).AddTicks(2240), "103011500112 / YAMAHA / NP15B", "klavye1.png", true, false, true, "Piaggero Tuşlu Eğitim Klavyesi", null, 14500m, "Teknik Özellikler\r\n\r\nTipi: Eğitim Klavyesi\r\nSes Teknoojisi: AWN Stereo Sampling\r\nTuş Sayısı: 61\r\nTuş Tipi: Yarı-Ağırlıklı\r\nTouch Sensitivity: Hard, Medium, Soft, Fixed\r\nPolifoni: 64 Nota\r\nHazır Sesler: 15 Ses\r\nEfektler: 6 x Reverb\r\nSes Kayıt: 1 parça (7,000 nota'ya kadar.)\r\nSes Çıkışları: 1 x 1/4\" (phones/output)\r\nUSB: 1 x Type B\r\nMIDI I/O: USB\r\nPedal Girişkerş: 1 x 1/4\" (sustain)\r\nDahili Hoparlör: 2 x (4.75\" x 3.14\")\r\nAmpfi: 2 x 2.5W\r\nGüç Desteği: 6 x AA, 12V DC (1A) power supply ", 2, new DateTime(2024, 3, 27, 23, 7, 20, 689, DateTimeKind.Local).AddTicks(2240), "yamaha-piaggero-tuslu-egitim-klavyesi" },
                    { 5, 2, new DateTime(2024, 3, 27, 23, 7, 20, 689, DateTimeKind.Local).AddTicks(2241), "103010290039/CASIO/MZX500", "klavye2.png", true, false, false, "MZ-61 Tuşlu Klavye", null, 32800m, "Teknik Özellikler\r\n\r\nTipi: Eğitim Klavyesi\r\nSes Teknoojisi: AWN Stereo Sampling\r\nTuş Sayısı: 61\r\nTuş Tipi: Yarı-Ağırlıklı\r\nTouch Sensitivity: Hard, Medium, Soft, Fixed\r\nPolifoni: 64 Nota\r\nHazır Sesler: 15 Ses\r\nEfektler: 6 x Reverb\r\nSes Kayıt: 1 parça (7,000 nota'ya kadar.)\r\nSes Çıkışları: 1 x 1/4\" (phones/output)\r\nUSB: 1 x Type B\r\nMIDI I/O: USB\r\nPedal Girişkerş: 1 x 1/4\" (sustain)\r\nDahili Hoparlör: 2 x (4.75\" x 3.14\")\r\nAmpfi: 2 x 2.5W\r\nGüç Desteği: 6 x AA, 12V DC (1A) power supply ", 2, new DateTime(2024, 3, 27, 23, 7, 20, 689, DateTimeKind.Local).AddTicks(2242), "casio-mz61-tuslu-klavye" },
                    { 6, 1, new DateTime(2024, 3, 27, 23, 7, 20, 689, DateTimeKind.Local).AddTicks(2243), "102011060204 / PEARL RIVER / V-05 WH", "klavye3.png", true, false, false, "Tuşlu Klavye", null, 25000m, "CASIO'nun gelişmiş dijital teknolojileri, rock ve caz hayranları arasında popüler olan eski mekanik ton dişli org seslerini aslına uygun olarak üretir. Orgun yalnızca döner hoparlörlerine özel sarsıntılar değil, aynı zamanda gürültü kaçakları da doğru şekilde üretilir. Geliştiricilerin geleneksel ton dişli orgdaki derin, ağır rezonansı elde etme konusundaki kararlılığı sayesinde hoş seslerden oluşan zengin bir ses grubu ortaya çıkmıştır.\r\n\r\nHex Layer ve Synth\r\n\r\nDahili bir Hex Layer (yalnızca MZ-X500) altı adede kadar farklı tonu birleştirerek müziğin güçlü ifade şekline katkıda bulunan polifonik ses üretir. Ayrıca dahili Bass Synth işlevi de bulunur. Bu işlev, monofonik ses ve geleneksel analog synthesizer'ları anımsatan portamento efekti üretir.", 2, new DateTime(2024, 3, 27, 23, 7, 20, 689, DateTimeKind.Local).AddTicks(2244), "casio-61-tuslu-klavye" },
                    { 7, 1, new DateTime(2024, 3, 27, 23, 7, 20, 689, DateTimeKind.Local).AddTicks(2245), "103030640208 / HOHNER / A16812", "akordiyon1.png", true, false, true, "Hohner A16812 Bravo 120 Akordiyon ", null, 32000m, "Teknik Özellikler\r\n\r\nTuş Sayısı: 41\r\nNota Sayısı: 41, F - A\r\nSınıfı: Kromatik\r\nKamış Plaka Seti: 3\r\nRegister Sayısı: 7\r\nTon Sayısı: 5\r\nStandart Baslar: 120\r\nStandart Bas (Kamış Plaka Seti): 4\r\nStandart Bas Register: 3\r\nÖlçüleri: 44 x 18,5 cm\r\nKamış Plaka Seti Kalitesi: Standart\r\nAğırlığı: 9,2 kg\r\nİlave İçerik: Askılı Taşıma Çantası.\"", 3, new DateTime(2024, 3, 27, 23, 7, 20, 689, DateTimeKind.Local).AddTicks(2252), "hohner-a16812-bravo-120-akordiyon" },
                    { 8, 1, new DateTime(2024, 3, 27, 23, 7, 20, 689, DateTimeKind.Local).AddTicks(2271), "104081122078 / PRS - PAUL REED SMITH / ST844TB", "elektrogitar1.png", true, false, true, "PRS SE Standard Elektro Gitar", null, 35000m, "Teknik Özellikler\r\n\r\nÖn Gövde: Maun\r\nGövde: Maun\r\nGövde Carve: Shallow Violin Carve\r\nPerde Sayısı: 24\r\nUzunluk: 25”\r\nSap (Neck): Akçaağaç\r\nSap (Neck) Şekli: Wide Thin\r\nKlavye: Gülağacı\r\nKlavye İşaretleri: “Old School” Birds\r\nKöprü (Bridge): PRS Patented Tremolo, Molded\r\nBurgular: PRS-Designed Tuners\r\nAksamlar: Nikel\r\nTruss Rod Cover: “Custom”\r\nKöprü (Bridge) Manyetiği: TCI “S” Treble\r\nSap (Neck) Manyetiği: TCI “S” Bass\r\nKontroller: Volume and Tone Control with 3-Way Toggle Pickup Switch and Two Mini-Toggle Coil-Tap Switches\r\nTeller: PRS Classic, 9-42\r\nTaşıma Çantası: PRS Gig Bag ", 4, new DateTime(2024, 3, 27, 23, 7, 20, 689, DateTimeKind.Local).AddTicks(2271), "prs-se-standart-elektro-gitar" },
                    { 9, 1, new DateTime(2024, 3, 27, 23, 7, 20, 689, DateTimeKind.Local).AddTicks(2273), "104081121601 / PRS - PAUL REED SMITH / SEC844TU", "elektrogitar2.png", true, false, false, "PRS SE Custom  Elektro Gitar", null, 43000m, "Teknik Özellikler\r\n\r\nÖn Gövde: Akçaağaç w/ Flame Akçaağaç Veneer\r\nGövde: Maun\r\nGövde Carve: Shallow Violin Carve\r\nPerde Sayısı: 24\r\nUzunluk: 25”\r\nSap (Neck): Akçaağaç\r\nSap (Neck) Şekli: Wide Thin\r\nKlavye: Gülağacı\r\nKlavye İşaretleri: “Old School” Birds\r\nKöprü (Bridge): PRS Patented Tremolo, Molded\r\nBurgular: PRS-Designed Tuners\r\nAksamlar: Nikel\r\nTruss Rod Cover: “Custom”\r\nKöprü (Bridge) Manyetiği: TCI “S” Treble\r\nSap (Neck) Manyetiği: TCI “S” Bass\r\nKontroller: Volume and Tone Control with 3-Way Toggle Pickup Switch and Two Mini-Toggle Coil-Tap Switches\r\nTeller: PRS Classic, 9-42\r\nTaşıma Çantası: PRS Gig Bag ", 4, new DateTime(2024, 3, 27, 23, 7, 20, 689, DateTimeKind.Local).AddTicks(2273), "prs-se-custom-elektro-gitar" },
                    { 10, 1, new DateTime(2024, 3, 27, 23, 7, 20, 689, DateTimeKind.Local).AddTicks(2275), "104041230601/SEAGULL/052431", "akustikgitar1.png", true, false, true, "Seagull S6 Collection  Akustik Gitar", null, 30600m, "Teknik Özellikler\r\n\r\nTel Tipi: Çelik\r\nTel Sayısı: 6\r\nÇalım: Sağ El\r\nGövde Şekli: Dreadnought\r\nÖn Gövde: Sedir\r\nFinish: Yarı Parlak\r\nRenk: Natural\r\nBody Bracing: Fan bracing\r\nSap (Neck): Silver Leaf Akçaağaç\r\nSap (Neck) Şekli: D\r\nKlavye: Gülağacı\r\nKlavye İşaretleri: Circular Plastic\r\nPerde Sayısı: 22, Nickel Silver\r\nUzunluk: 24.84\"\r\nEşik Genişiği: 1.8\"\r\nEşik/Saddle: Graph Tech\r\nKöprü (Bridge): Gülağacı\r\nBurgular: Sealed Chrome, 14:1 ratio\r\nTeller: Godin A6 LT, .012-.053 ", 5, new DateTime(2024, 3, 27, 23, 7, 20, 689, DateTimeKind.Local).AddTicks(2275), "seagull-s6-collection-akustik-gitar" },
                    { 11, 1, new DateTime(2024, 3, 27, 23, 7, 20, 689, DateTimeKind.Local).AddTicks(2280), "104051231201/SEAGULL/052424", "akustikgitar2.png", true, false, false, "Seagull M6 Akustik Gitar", null, 42600m, "Tel Tipi: Çelik\r\nTel Sayısı: 6\r\nÇalım: Sağ El\r\nGövde Şekli: Concert\r\nÖn Gövde: Sedir\r\nFinish: Parlak\r\nRenk: Ruby Red\r\nBody Bracing: X-bracing\r\nSap (Neck): Silver Leaf Akçaağaç\r\nSap (Neck) Şekli: D\r\nRadius: 16\"\r\nKlavye: Gülağacı\r\nKlavye İşaretleri: Noktalar\r\nPerde Sayısı: 21\r\nUzunluk: 25.5\"\r\nEşik Genişiği: 1.8\"\r\nEşik/Saddle: Tusq/Tusq\r\nKöprü (Bridge): Gülağacı\r\nBurgular: Open-gear\r\nPreamp: Fishman Sonitone\r\nTeller: Godin A6 LT, .012-.053\r\nTaşıma Çantasu: Gig Bag ", 5, new DateTime(2024, 3, 27, 23, 7, 20, 689, DateTimeKind.Local).AddTicks(2280), "seagull-m6-akustik-gitar" },
                    { 12, 1, new DateTime(2024, 3, 27, 23, 7, 20, 689, DateTimeKind.Local).AddTicks(2282), "104050570703 / GIBSON / MCRS45CH", "akustikgitar3.png", true, false, false, "Gibson Standard Akustik Gitar", null, 33000m, "Teknik Özellikler\r\n\r\nTel Tipi: Çelik\r\nTel Sayısı: 6\r\nÇalım: Sağ El\r\nGövde Şekli: J-45 Dreadnought\r\nArka & Yanlar: Maun\r\nÖn Gövde: Sitka Ladin\r\nFinish: Gloss Nitrocellulose Lacquer\r\nRenk: Cherry\r\nBinding: Multi-ply\r\nSap (Neck): Maun\r\nSap (Neck) Şekli: Slim Taper\r\nRadius: 12\"\r\nKlavye: Hint Gülağacı\r\nKlavye İşaretleri: Mother-of-Pearl Dots\r\nPerdeler: 20\r\nUzunluk: 24.75\"\r\nEşik Genişliği: 1.725\"\r\nEşik/Saddle: Tusq/Tusq\r\nKöprü (Bridge): Gülağacı Reverse Belly\r\nBurgular: Grover Rotomatics\r\nPreamo: LR Baggs VTC\r\nTeller: Gibson, .012-.053\r\nCase: Hardshell Case", 5, new DateTime(2024, 3, 27, 23, 7, 20, 689, DateTimeKind.Local).AddTicks(2282), "gibson-standart-akustik-gitar" },
                    { 13, 1, new DateTime(2024, 3, 27, 23, 7, 20, 689, DateTimeKind.Local).AddTicks(2283), "104130571101/EPIPHONE/EF30ASGH1", "mandolin1.png", true, false, true, "Epiphone MM-30S Mandolin", null, 8500m, "Stil: F-Style\r\nGövde Derinlik: 50 mm\r\nÖn Gövde: Ladin\r\nArka ve Yanlar: Akçaağaç\r\nSap (Neck): Akçaağaç\r\nKlavye: Gülağacı\r\nKlavye İşaretleri: inlays\r\nEşik Genişliği: 28 mm\r\nUzunluk: 350 mm\r\nPerdeler: 24\r\nKöprü (Bridge): Rosewood\r\nBurgular: Chrome-plated\r\nRenk: Whiskey Burst Satin", 6, new DateTime(2024, 3, 27, 23, 7, 20, 689, DateTimeKind.Local).AddTicks(2284), "epiphone-mm-30s-mandolin" },
                    { 14, 1, new DateTime(2024, 3, 27, 23, 7, 20, 689, DateTimeKind.Local).AddTicks(2285), "10413216580 /ORTEGA/RMF30-WB", "mandolin2.png", true, false, true, "8 Telli Mandolin", null, 11800m, "Stil: F-Style\r\nGövde Derinlik: 50 mm\r\nÖn Gövde: Ladin\r\nArka ve Yanlar: Akçaağaç\r\nSap (Neck): Akçaağaç\r\nKlavye: Gülağacı\r\nKlavye İşaretleri: inlays\r\nEşik Genişliği: 28 mm\r\nUzunluk: 350 mm\r\nPerdeler: 24\r\nKöprü (Bridge): Rosewood\r\nBurgular: Chrome-plated\r\nRenk: Whiskey Burst Satin", 6, new DateTime(2024, 3, 27, 23, 7, 20, 689, DateTimeKind.Local).AddTicks(2286), "8-telli-mandolin" },
                    { 15, 1, new DateTime(2024, 3, 27, 23, 7, 20, 689, DateTimeKind.Local).AddTicks(2287), "104122165710/ORTEGA /RUAR-EY", "ukulele1.png", true, false, true, "Art Series Concert Ukulele", null, 2800m, "Teknik Özellikler\r\n\r\nSize: Concert \r\nScale: 380 mm\r\nEşik Genişliği: 36 mm\r\nPerdeler: 18\r\nTel Sayısı: 4\r\nÖn Gövde: Ladin\r\nRenk: Egypt Custom\r\nFinish: Satin \r\nSap (Neck): Nato\r\nKöprü (Bridge): Akçaağaç\r\nKlavye: Akçaağaç\r\nBurgular: Die-cast tuning machines, gold w/ gold buttons", 7, new DateTime(2024, 3, 27, 23, 7, 20, 689, DateTimeKind.Local).AddTicks(2287), "art-series-concert-ukulele" },
                    { 16, 1, new DateTime(2024, 3, 27, 23, 7, 20, 689, DateTimeKind.Local).AddTicks(2289), "104120939928/MAHALO/MM3E", "ukulele2.png", true, false, false, "All Solid Elektro Tenor Ukulele", null, 5100m, "Teknik Özellikler\r\n\r\nMarka: Mahalo\r\nÖn Gövde: SOLID Red Cedar\r\nArka ve Yanlar: Solid Maun\r\nBracing: Toneflow Bracing\r\nSap (Neck): Tek Parça Maun\r\nKlavye: Amara Abanoz\r\nKöprü (Bridge): Amara Abanoz\r\nBurgular: Waverly Style, Gold Plated with Ivoroid Button", 7, new DateTime(2024, 3, 27, 23, 7, 20, 689, DateTimeKind.Local).AddTicks(2289), "all-solid-elektro-tenor-ukulele" },
                    { 17, 1, new DateTime(2024, 3, 27, 23, 7, 20, 689, DateTimeKind.Local).AddTicks(2291), "107010959912 / MAVIS / MV012L 1/4", "keman1.png", true, false, true, "Mavis Laminated Keman", null, 1900m, "Teknik Özellikler\r\n\r\nKutu, Arşe ve Reçine dahil..\r\nKatı preslenmiş ladin ağacı salyangoz\r\nKatı preslenmiş akçaağaç gövde\r\nSiyah boyalı akçaağaçtan klavye ve pigler", 8, new DateTime(2024, 3, 27, 23, 7, 20, 689, DateTimeKind.Local).AddTicks(2291), "mavis-laminated-keman" },
                    { 18, 1, new DateTime(2024, 3, 27, 23, 7, 20, 689, DateTimeKind.Local).AddTicks(2293), "107012560101 / DONNER / EC1531", "keman2.png", true, false, false, "Donner Rising Carbon Fiber Keman Seti", null, 16000m, "Teknik Özellikler\r\n\r\nKutu, Arşe ve Reçine dahil..\r\nKatı preslenmiş ladin ağacı salyangoz\r\nKatı preslenmiş akçaağaç gövde\r\nSiyah boyalı akçaağaçtan klavye ve pigler", 8, new DateTime(2024, 3, 27, 23, 7, 20, 689, DateTimeKind.Local).AddTicks(2293), "donner-rising-carbon-fiber-keman-seti" },
                    { 19, 2, new DateTime(2024, 3, 27, 23, 7, 20, 689, DateTimeKind.Local).AddTicks(2294), "10702150010/YAMAHA/YSV104BLA02", "keman3.png", true, false, false, "Silent Keman", null, 28000m, "Teknik Özellikler\r\n\r\nÜrün Kodu: YSV104BRO \r\nTür: Silent Keman\r\nÖlçü: 4/4\r\nGövde: Ladin\r\nSap (Neck): Akçaağaç\r\nKlavye: Kompozit\r\nBurgular: Abanoz\r\nTeller: D'Addario Zyex ", 8, new DateTime(2024, 3, 27, 23, 7, 20, 689, DateTimeKind.Local).AddTicks(2295), "yamaha-silent-keman" },
                    { 20, 2, new DateTime(2024, 3, 27, 23, 7, 20, 689, DateTimeKind.Local).AddTicks(2296), "107031509907/YAMAHA/KVA5S16", "viyola1.png", true, false, true, "Viyola Seti", null, 34000m, "Teknik Özellikler\r\n\r\nTip: Stradivarius\r\nBoyut: 16\"\r\nÜst Kapak: Ladin\r\nArka Kapak: Akçaağaç\r\nYan Kapaklar: Akçaağaç\r\nSap: Akçaağaç\r\nKlavye: Abanoz\r\nCila: Poliüretan\r\nBurgular: Abanoz\r\nKuyruk: Wittner \"Ultra\" (4 Adet Fiks)\r\nFiksler: Wittner \"Ultra\" (4 Adet Fiks)\r\nEşik: Yamaha Orijinal\r\nÇenelik: Abanoz\r\nTeller: Prelude\r\nKutu: Var\r\nYay: Brazilian Ağacı\r\nReçine: Piranito ", 9, new DateTime(2024, 3, 27, 23, 7, 20, 689, DateTimeKind.Local).AddTicks(2297), "yamaha-viyola-seti" },
                    { 21, 2, new DateTime(2024, 3, 27, 23, 7, 20, 689, DateTimeKind.Local).AddTicks(2299), "107031509904/YAMAHA/VA5S16", "viyola2.png", true, false, false, "VA5S Viyola", null, 35000m, "Teknik Özellikler\r\n\r\nTip: Stradivarius\r\nBoyut: 16\"\r\nÜst Kapak: Ladin\r\nArka Kapak: Akçaağaç\r\nYan Kapaklar: Akçaağaç\r\nSap: Akçaağaç\r\nKlavye: Abanoz\r\nCila: Poliüretan\r\nBurgular: Abanoz\r\nKuyruk: Wittner \"Ultra\" (4 Adet Fiks)\r\nFiksler: Wittner \"Ultra\" (4 Adet Fiks)\r\nEşik: Yamaha Orijinal\r\nÇenelik: Abanoz\r\nTeller: Prelude\r\nKutu: Var\r\nYay: Brazilian Ağacı\r\nReçine: Piranito ", 9, new DateTime(2024, 3, 27, 23, 7, 20, 689, DateTimeKind.Local).AddTicks(2299), "yamaha-va5s-seti" },
                    { 22, 3, new DateTime(2024, 3, 27, 23, 7, 20, 689, DateTimeKind.Local).AddTicks(2301), "107041209902/RÖSLER/MC6012 1/2", "cello1.png", true, false, true, "MC6012 Çello", null, 23500m, "Teknik Özellikler\r\n\r\nÖn Kapak: Ladin\r\nYan - Arka: Akçaağaç\r\nKlavye: Ebonit\r\nKuyruk: Dahili 4 fixli kuyruk\r\nBurgu: Ebonit\r\nVernik: Parlak Cila\r\nKutu İçeriği: Taşıma Çantası, Yay", 10, new DateTime(2024, 3, 27, 23, 7, 20, 689, DateTimeKind.Local).AddTicks(2301), "rösler-mc6012-cello" },
                    { 23, 3, new DateTime(2024, 3, 27, 23, 7, 20, 689, DateTimeKind.Local).AddTicks(2303), "108351500001/YAMAHA/YDS150", "saksafon1.png", true, false, true, "Dijital Saksafon", null, 38000m, "Teknik Özellikler\r\n\r\nAkustik Saksafon ile aynı tuş düzenine sahiptir.\r\nAWM (Advanced Wave Memory) sampling\r\n73 Ses - 56 Saksafon sesi\r\n5 Efekt\r\nVolume Kontrolü ile 15 farklı seviye\r\nAkort Modu: Eb, Bb, C\r\nAkort: 427 - 453 Hz (0.5 Hz'e kadar ayarlanabilir.)\r\nAuto power off\r\nBluetooth\r\nIos veya Android uygulaması: Sesleri değiştir, fingering, enstrüman ayarlamaları\r\nStereo Kulaklık Çıkışı: 3.5 mm Mini jack\r\nMicro USB tip B\r\nBatarya (4x AAA) veya harici USB güç desteği ile çalışır.(Kutu içeriğine dahil değildir.)\r\nGüç Tüketimi: 4.5 W (USB kullanımı esnasında.)", 11, new DateTime(2024, 3, 27, 23, 7, 20, 689, DateTimeKind.Local).AddTicks(2303), "yamaha-dijital-saksafon" },
                    { 24, 3, new DateTime(2024, 3, 27, 23, 7, 20, 689, DateTimeKind.Local).AddTicks(2304), "108351500001/BOHEMIA/YDS150", "saksafon2.png", true, false, false, "Bohemia Tenor Saksafon", null, 25800m, "Teknik Özellikler\r\n\r\nBohemia XTN2001 Tenor Saksafon\r\n\r\nÖğrenci Seviyesi\r\nAltın Lake Kaplama\r\n'Bb' Tenor Saksafon\r\nKumaş Sert Çanta\r\nAskı\r\nAğızlık Set\r\n2 Yıl Garanti", 11, new DateTime(2024, 3, 27, 23, 7, 20, 689, DateTimeKind.Local).AddTicks(2305), "bohemia-tenor-saksafon" },
                    { 25, 3, new DateTime(2024, 3, 27, 23, 7, 20, 689, DateTimeKind.Local).AddTicks(2306), "108070730004/JINBAO/JBCL-570", "klarnet1.png", true, false, false, " Bemol Klarnet", null, 6800m, "Teknik Özellikler\r\n\r\nJinbao XTN2001 Tenor Saksafon\r\n\r\nÖğrenci Seviyesi\r\nAltın Lake Kaplama\r\n'Bb' Tenor Saksafon\r\nKumaş Sert Çanta\r\nAskı\r\nAğızlık Set\r\n2 Yıl Garanti", 12, new DateTime(2024, 3, 27, 23, 7, 20, 689, DateTimeKind.Local).AddTicks(2306), "jinbao-bemol-klarnet" },
                    { 26, 3, new DateTime(2024, 3, 27, 23, 7, 20, 689, DateTimeKind.Local).AddTicks(2308), "108330220010/BOHEMIA/XCL340W", "klarnet2.png", true, false, true, " Bohemia  Plus Sol Klarnet", null, 10100m, "Teknik Özellikler\r\n\r\nBakalit\r\n4 Yüzüklü.\r\nNikel kaplama.\r\nErgonomik tuş tasarımı sayesinde rahat çalım imkanı sunmaktadır.\r\n2 adet baril kutu içeriğinde bulunmaktadır. (68 mm, 70 mm)", 12, new DateTime(2024, 3, 27, 23, 7, 20, 689, DateTimeKind.Local).AddTicks(2308), "bohemia-plus-sol-klarnet" },
                    { 27, 3, new DateTime(2024, 3, 27, 23, 7, 20, 689, DateTimeKind.Local).AddTicks(2310), "108070100101/ANTIGUA/WCL3230S-WH", "klarnet3.png", true, false, false, "Si Bemol Klarnet", null, 37000m, "Teknik Özellikler\r\n\r\nBakalit\r\n4 Yüzüklü.\r\nNikel kaplama.\r\nErgonomik tuş tasarımı sayesinde rahat çalım imkanı sunmaktadır.\r\n2 adet baril kutu içeriğinde bulunmaktadır. (68 mm, 70 mm)", 12, new DateTime(2024, 3, 27, 23, 7, 20, 689, DateTimeKind.Local).AddTicks(2310), "antigua-si-bemol-klarnet" },
                    { 28, 3, new DateTime(2024, 3, 27, 23, 7, 20, 689, DateTimeKind.Local).AddTicks(2311), "108160645008/HOHNER/M58611X", "mızıka1.png", true, false, false, "Blues Bender Si Bemol Majör Mızıka", null, 732m, "Metal bb sibemol major mızıka", 13, new DateTime(2024, 3, 27, 23, 7, 20, 689, DateTimeKind.Local).AddTicks(2312), "blues-bender-si-bemol-major-mizika" },
                    { 29, 3, new DateTime(2024, 3, 27, 23, 7, 20, 689, DateTimeKind.Local).AddTicks(2313), "108010220001/BOHEMIA/XFL003", "yanflut1.png", true, false, true, "Bohemia Yan Flüt", null, 5955m, "Bohemia BFL003 Yan Flüt\r\nÖğrenci Seviyesi\r\nGümüş Kaplama\r\nKapalı Tuşe Sistemli\r\n'C' Flüt\r\nKumaş Sert Çanta\r\nTemizlik Bezi Set\r\n2 Yıl Garanti", 14, new DateTime(2024, 3, 27, 23, 7, 20, 689, DateTimeKind.Local).AddTicks(2314), "bohemia-yan-flut" },
                    { 30, 3, new DateTime(2024, 3, 27, 23, 7, 20, 689, DateTimeKind.Local).AddTicks(2315), "108010100001/ANTIGUA/FL2210-A", "yanflut2.png", true, false, true, "Yan Flüt", null, 16263m, "Antigua FL2210A Yan Flüt\r\n\r\nOrta Seviye\r\nGümüş Kaplama\r\nKapalı Tuşe Sistemli\r\n'C' Flüt\r\nSert Kabuk Çanta\r\nTemizlik Bezleri Set\r\n2 Yıl Garanti", 14, new DateTime(2024, 3, 27, 23, 7, 20, 689, DateTimeKind.Local).AddTicks(2315), "antigua-yan-flut" },
                    { 31, 3, new DateTime(2024, 3, 27, 23, 7, 20, 689, DateTimeKind.Local).AddTicks(2320), "108010320901/CONDUCTOR/M1115S", "yanflut3.png", true, false, false, "Conductor  Gümüş Yan Flüt", null, 6692m, "CONDUCTOR M1115\r\n\r\nÖğrenci Seviyesi\r\n\r\nGümüş Kaplama\r\n\r\nKapalı Tuşe Sistemli,\r\n\r\nC' Flüt\r\n\r\nKumaş Sert Çanta\r\n\r\nTemizlik Bezi Set\r\n\r\n2 Yıl Garanti", 14, new DateTime(2024, 3, 27, 23, 7, 20, 689, DateTimeKind.Local).AddTicks(2321), "conductor-gumus-yan-flut" },
                    { 32, 4, new DateTime(2024, 3, 27, 23, 7, 20, 689, DateTimeKind.Local).AddTicks(2323), "109230730002/JINBAO/JBS-1059", "akustikdavul1.png", true, false, true, "Jinbao Trampet", null, 2455m, "2 yıl garantili ,başlangıç seviye trampet", 15, new DateTime(2024, 3, 27, 23, 7, 20, 689, DateTimeKind.Local).AddTicks(2324), "jinbao-trampet" },
                    { 33, 4, new DateTime(2024, 3, 27, 23, 7, 20, 689, DateTimeKind.Local).AddTicks(2325), "109190730001/JINBAO/JBTB1413", "perkusyon1.png", true, false, false, "Jinbao Timbal", null, 4591m, "2 yıl garantili ,başlangıç seviye trampet", 16, new DateTime(2024, 3, 27, 23, 7, 20, 689, DateTimeKind.Local).AddTicks(2325), "jinbao-timbal" },
                    { 34, 4, new DateTime(2024, 3, 27, 23, 7, 20, 689, DateTimeKind.Local).AddTicks(2327), "109250730002/JINBAO/JB500AG", "perkusyon2.png", true, false, false, "Jinbao  Alto Glockenspiel", null, 5615m, "Yüksek Kaliteli Malzeme: Dayanıklı ve uzun ömürlü çalma deneyimi için sağlam yapıda malzemeler kullanılmıştır.\r\nSes Aralığı: Belirli bir not aralığını kapsayan ve doğru tonları sağlayan çeşitli notların bulunduğu geniş bir ses aralığına sahiptir.\r\nTaşınabilirlik: Hafif ve kompakt tasarımı sayesinde kolayca taşınabilirdir.", 16, new DateTime(2024, 3, 27, 23, 7, 20, 689, DateTimeKind.Local).AddTicks(2327), "jinbao-Alto-glockenspiel" },
                    { 35, 4, new DateTime(2024, 3, 27, 23, 7, 20, 689, DateTimeKind.Local).AddTicks(2329), "109052178516/MEINL/PAC14MTH", "zil1.png", true, false, true, "Meinl Hihat Zil ", null, 12212m, "Meinl PAC14MTH 14\" Pure Alloy Custom MT Meinl Hihat Zil (Çift)\r\n\r\nMeinl PAC14MTH 14\", Net ve güçlü bir ses sunar. dayanıklı ve kaliteli hi-hat zil arayan müzisyenler için idealdir.\r\n\r\nGenel özellikler\r\n\r\nGeniş ses aralığı, net ve hassas.\r\nAlmanya'da üretilmiştir.\r\nMüzik Stili:\r\n\r\nRock, Pop, Fusion, R&B, Reggae, Stüdyo", 17, new DateTime(2024, 3, 27, 23, 7, 20, 689, DateTimeKind.Local).AddTicks(2329), "meinl-Hihat-zil" },
                    { 36, 4, new DateTime(2024, 3, 27, 23, 7, 20, 689, DateTimeKind.Local).AddTicks(2331), "109052178504 / MEINL / B17JMTC", "zil2.png", true, false, true, "Jazz Medium Thin Crash Zil ", null, 11584m, "Meinl B17JMTC Byzance 17\" Jazz Medium Thin Crash Zil\r\n\r\nMeinl B17JMTC, Sıcak ve net bir sese sahiptir. dayanıklı ve kaliteli crash zil arayan müzisyenler için idealdir.\r\n\r\nGenel özellikler\r\n\r\nB20 bronz alaşımı.\r\n\r\nBenzersiz bir ses için elle yapılmıştır.", 17, new DateTime(2024, 3, 27, 23, 7, 20, 689, DateTimeKind.Local).AddTicks(2331), "jazz-medium-thin-crash-zil" },
                    { 37, 4, new DateTime(2024, 3, 27, 23, 7, 20, 689, DateTimeKind.Local).AddTicks(2332), "109052178504/Jinbao/B17JMTC", "baget1.png", true, false, false, "Jinbao M6 Keyboard Malet", null, 101m, "Yüksek Kaliteli Malzeme: Dayanıklı ve uzun ömürlü kullanım için yüksek kaliteli malzemelerden üretilmiştir.\r\nErgonomik Tasarım: Rahat bir kavrama ve kullanım sağlayan ergonomik bir tasarıma sahiptir.\r\nÇeşitli Kullanım Alanları: Klavye enstrümanlarıyla uyumlu olarak kullanılabilen çok yönlü bir malet.\r\nHassas Ses Üretimi: Denge ve kontrol sağlayan yapısı sayesinde hassas sesler elde etmek için idealdir.", 18, new DateTime(2024, 3, 27, 23, 7, 20, 689, DateTimeKind.Local).AddTicks(2333), "jinbao-m6-keyboard-malet" },
                    { 38, 4, new DateTime(2024, 3, 27, 23, 7, 20, 689, DateTimeKind.Local).AddTicks(2334), "109082170035/MEINL/SB302", "baget2.png", true, false, false, "Meinl Brush Fixed Wire Baget", null, 1352m, "Yüksek Kaliteli Malzeme: Dayanıklı ve uzun ömürlü kullanım için yüksek kaliteli malzemelerden üretilmiştir.\r\nErgonomik Tasarım: Rahat bir kavrama ve kullanım sağlayan ergonomik bir tasarıma sahiptir.\r\nÇeşitli Kullanım Alanları: Klavye enstrümanlarıyla uyumlu olarak kullanılabilen çok yönlü bir malet.\r\nHassas Ses Üretimi: Denge ve kontrol sağlayan yapısı sayesinde hassas sesler elde etmek için idealdir.", 18, new DateTime(2024, 3, 27, 23, 7, 20, 689, DateTimeKind.Local).AddTicks(2334), "meinl-brush-fixed-wire-baget" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BrandMainCategory_MainCategoryId",
                table: "BrandMainCategory",
                column: "MainCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_UserId",
                table: "Order",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_BrandId",
                table: "Product",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_OrderId",
                table: "Product",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_SubCategoryId",
                table: "Product",
                column: "SubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingBasketItems_ProductId",
                table: "ShoppingBasketItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingBasketItems_ShoppingBasketId",
                table: "ShoppingBasketItems",
                column: "ShoppingBasketId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingBaskets_UserId",
                table: "ShoppingBaskets",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategory_MainCategoryId",
                table: "SubCategory",
                column: "MainCategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BrandMainCategory");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "ShoppingBasketItems");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Brand");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "SubCategory");

            migrationBuilder.DropTable(
                name: "ShoppingBaskets");

            migrationBuilder.DropTable(
                name: "MainCategory");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
