using AspNetCoreHero.ToastNotification;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
