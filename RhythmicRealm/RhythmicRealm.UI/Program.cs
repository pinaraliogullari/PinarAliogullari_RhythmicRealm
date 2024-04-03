using RhythmicRealm.UI.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.LoadMyDbContextServices();
builder.Services.LoadMyIdentityServices();
builder.Services.LoadMyCookieConfiguration();
builder.Services.LoadMyRepositoriesAndServices();
builder.Services.LoadMyEmailSenderService();
builder.Services.LoadMyImageHelperService();
builder.Services.LoadMyToastrService();


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
