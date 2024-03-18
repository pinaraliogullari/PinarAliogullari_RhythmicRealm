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
	options.Password.RequireNonAlphanumeric = true; //alphanumeric karakter zorunlulu�u
	options.Password.RequireLowercase = true; //k���k harf zorunlulu�u
	options.Password.RequireUppercase = true; //b�yk harf zorunlulu�u
	options.Password.RequireDigit = true; //0-9 aras� say�sal karakter zorunlulu�u
	options.User.RequireUniqueEmail = true; //Email adreslerini tekille�tir�me.
	options.User.AllowedUserNameCharacters = "abc�defghi�jklmno�pqrs�tu�vwxyzABC�DEFGHI�JKLMNO�PQRS�TU�VWXYZ0123456789-._@+"; //Kullan�c� ad�nda ge�erli olan karakterleri belirtiyoruz.
	options.SignIn.RequireConfirmedEmail = false;//bunu daha sonra true yapaca��m.


	//account lockout settings
	options.Lockout.MaxFailedAccessAttempts = 3;//�st �ste hatal� giri� denemesi s�n�r�
	options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromSeconds(60);//Kilitlenmi� bir hesaba yeniden giri� yapabilmek i�in gereken bekleme s�resi
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
		Name = "RRCookie", //Olu�turulacak Cookie'yi isimlendirme.
		HttpOnly = false, //client-side taraf�ndan Cookie'ye eri�mesini engelleme.
		SameSite = SameSiteMode.Lax, //Top level navigasyonlara sebep olmayan requestlere Cookie'nin g�nderilmemesini belirtme.
		SecurePolicy = CookieSecurePolicy.Always //HTTPS �zerinden eri�ilebilirlik.
	};
	options.SlidingExpiration = true; //Expiration s�resinin yar�s� kadar s�re zarf�nda istekte bulunulursa, geri kalan yar�s�n� tekrar s�f�rlayarak ilk ayarlanan s�reyi tazeleyecektir.
	options.ExpireTimeSpan = TimeSpan.FromDays(10); //CookieBuilder nesnesinde tan�mlanan Expiration de�erinin varsay�lan de�erlerle ezilme ihtimaline kar��n tekrardan Cookie vadesi burada da belirtiliyor.
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
