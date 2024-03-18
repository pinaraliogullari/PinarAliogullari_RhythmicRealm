using AspNetCoreHero.ToastNotification;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using RhythmicRealm.Data.Abstract;
using RhythmicRealm.Data.Concrete.Contexts;
using RhythmicRealm.Data.Concrete.Repositories;
using RhythmicRealm.Entity.Concrete.Identity;
using RhythmicRealm.Service.Abstract;
using RhythmicRealm.Service.Concrete;
using RhythmicRealm.Shared.Helpers.Abstract;
using RhythmicRealm.Shared.Helpers.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<RRContext>(options =>options.UseSqlite(builder.Configuration.GetConnectionString("SqliteConnection")));


//identity
builder.Services.AddIdentity<User, Role>()
	.AddEntityFrameworkStores<RRContext>()
.AddDefaultTokenProviders();


builder.Services.Configure<IdentityOptions>(options =>
{
	//password settings
	options.Password.RequiredLength = 7; //en az 7 karakter
	options.Password.RequireNonAlphanumeric = true; //alphanumeric karakter zorunluluðu
	options.Password.RequireLowercase = true; //küçük harf zorunluluðu
	options.Password.RequireUppercase = true; //büyk harf zorunluluðu
	options.Password.RequireDigit = true; //0-9 arasý sayýsal karakter zorunluluðu
	options.User.RequireUniqueEmail = true; //Email adreslerini tekilleþtiröme.
	options.User.AllowedUserNameCharacters = "abcçdefghiýjklmnoöpqrsþtuüvwxyzABCÇDEFGHIÝJKLMNOÖPQRSÞTUÜVWXYZ0123456789-._@+"; //Kullanýcý adýnda geçerli olan karakterleri belirtiyoruz.
	options.SignIn.RequireConfirmedEmail = false;//bunu daha sonra true yapacaðým.


	//account lockout settings
	options.Lockout.MaxFailedAccessAttempts = 3;//Üst üste hatalý giriþ denemesi sýnýrý
	options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromSeconds(60);//Kilitlenmiþ bir hesaba yeniden giriþ yapabilmek için gereken bekleme süresi
}

);


//cookie settings
builder.Services.ConfigureApplicationCookie(options =>
{
	options.LoginPath = "/Account/Login";
	options.LogoutPath = "/";
	options.AccessDeniedPath = "/Account/AccessDenied";
	options.Cookie = new CookieBuilder
	{
		Name = "RRCookie", //Oluþturulacak Cookie'yi isimlendirme.
		HttpOnly = false, //client-side tarafýndan Cookie'ye eriþmesini engelleme.
		SameSite = SameSiteMode.Lax, //Top level navigasyonlara sebep olmayan requestlere Cookie'nin gönderilmemesini belirtme.
		SecurePolicy = CookieSecurePolicy.Always //HTTPS üzerinden eriþilebilirlik.
	};
	options.SlidingExpiration = true; //Expiration süresinin yarýsý kadar süre zarfýnda istekte bulunulursa, geri kalan yarýsýný tekrar sýfýrlayarak ilk ayarlanan süreyi tazeleyecektir.
	options.ExpireTimeSpan = TimeSpan.FromDays(10); //CookieBuilder nesnesinde tanýmlanan Expiration deðerinin varsayýlan deðerlerle ezilme ihtimaline karþýn tekrardan Cookie vadesi burada da belirtiliyor.
});


//datalayer-repositories
builder.Services.AddScoped<IBrandRepository, BrandRepository>();
builder.Services.AddScoped<IMainCategoryRepository, MainCategoryRepository>();
builder.Services.AddScoped<ISubCategoryRepository, SubCategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IShoppingBasketRepository, ShoppingBasketRepository>();
builder.Services.AddScoped<IShoppingBasketItemRepository, ShoppingBasketItemRepository>();


//datalayer-services
builder.Services.AddScoped<IBrandService, BrandService>();
builder.Services.AddScoped<IMainCategoryService, MainCategoryService>();
builder.Services.AddScoped<ISubCategoryService, SubCategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IShoppingBasketService, ShoppingBasketService>();
builder.Services.AddScoped<IShoppingBasketItemService, ShoppingBasketItemService>();

//Helper
builder.Services.AddScoped<IImageHelper, ImageHelper>();

//toastr
builder.Services.AddNotyf(options =>
{
	options.DurationInSeconds = 3;
	options.Position = NotyfPosition.TopRight;
	//options.HasRippleEffect = true;
	//options.IsDismissable = true;
	

});



var app = builder.Build();
var environment = app.Environment;

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapAreaControllerRoute(
	name:"Admin",
	areaName: "Admin",
	pattern: "Admin/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
