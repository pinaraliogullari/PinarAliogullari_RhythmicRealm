using AspNetCoreHero.ToastNotification;
using Iyzipay.Model;
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
using RhythmicRealm.UI.EmailServices.Abstract;
using RhythmicRealm.UI.EmailServices.Concrete;

namespace RhythmicRealm.UI.Extensions
{
	public static class ServiceCollectionExtensions
	{
		public static IServiceCollection LoadMyDbContextServices(this IServiceCollection services)
		{
			services.AddDbContext<RRContext>(options => options.UseSqlite(services.BuildServiceProvider().GetRequiredService<IConfiguration>().GetConnectionString("SqliteConnection")));
			services.AddHttpContextAccessor(); //http context nesnesine katmanlardaki herhangi bir sınıftan erişebilmek için.
			return services;
		}

		public static IServiceCollection LoadMyIdentityServices(this IServiceCollection services)
		{
			
			services.AddIdentity<User, Role>()
				.AddEntityFrameworkStores<RRContext>()
			.AddDefaultTokenProviders();
			services.Configure<IdentityOptions>(options =>
			{
				//password settings
				options.Password.RequiredLength = 7; //en az 7 karakter
				options.Password.RequireNonAlphanumeric = true; //alphanumeric karakter zorunluluğu
				options.Password.RequireLowercase = true; //küçük harf zorunluluğu
				options.Password.RequireUppercase = true; //büyk harf zorunluluğu
				options.Password.RequireDigit = true; //0-9 arası sayısal karakter zorunluluğu
				options.User.RequireUniqueEmail = true; //Email adreslerini tekilleştiröme.
				options.User.AllowedUserNameCharacters = "abcçdefghiıjklmnoöpqrsştuüvwxyzABCÇDEFGHIİJKLMNOÖPQRSŞTUÜVWXYZ0123456789-._@+"; //Kullanıcı adında geçerli olan karakterleri belirtiyoruz.
				options.SignIn.RequireConfirmedEmail = true;
				//account lockout settings
				options.Lockout.MaxFailedAccessAttempts = 4;//Üst üste hatalı giriş denemesi sınırı
				options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromSeconds(60);//Kilitlenmiş bir hesaba yeniden giriş yapabilmek için gereken bekleme süresi
			});
			return services;

		}
		public static IServiceCollection LoadMyCookieConfiguration(this IServiceCollection services)
		{
			services.ConfigureApplicationCookie(options =>
			{
				options.LoginPath = "/Account/Login";
				options.LogoutPath = "/";
				options.AccessDeniedPath = "/Account/AccessDenialPage";
				options.Cookie = new CookieBuilder
				{
					Name = "RRCookie", //Oluşturulacak Cookie'yi isimlendirme.
					HttpOnly = false, //client-side tarafından Cookie'ye erişmesini engelleme.
					SameSite = SameSiteMode.Lax, //Top level navigasyonlara sebep olmayan requestlere Cookie'nin gönderilmemesini belirtme.
					SecurePolicy = CookieSecurePolicy.Always //HTTPS üzerinden erişilebilirlik.
				};
				options.SlidingExpiration = true; //Expiration süresinin yarısı kadar süre zarfında istekte bulunulursa, geri kalan yarısını tekrar sıfırlayarak ilk ayarlanan süreyi tazeleyecektir.
				options.ExpireTimeSpan = TimeSpan.FromDays(10); //CookieBuilder nesnesinde tanımlanan Expiration değerinin varsayılan değerlerle ezilme ihtimaline karşın tekrardan Cookie vadesi burada da belirtiliyor.
			});
			return services;
		}
		public static IServiceCollection LoadMyRepositoriesAndServices(this IServiceCollection services)
		{
			services.AddScoped<IBrandRepository, BrandRepository>();
			services.AddScoped<IMainCategoryRepository, MainCategoryRepository>();
			services.AddScoped<ISubCategoryRepository, SubCategoryRepository>();
			services.AddScoped<IProductRepository, ProductRepository>();
			services.AddScoped<IOrderRepository, OrderRepository>();
			services.AddScoped<IShoppingBasketRepository, ShoppingBasketRepository>();
			services.AddScoped<IShoppingBasketItemRepository, ShoppingBasketItemRepository>();
			services.AddScoped<IContactRepository, ContactRepository>();
			services.AddScoped<IMessageRepository, MessageRepository>();
			services.AddScoped<IFavoriteRepository, FavoriteRepository>();

			services.AddScoped<IBrandService, BrandService>();
			services.AddScoped<IMainCategoryService, MainCategoryService>();
			services.AddScoped<ISubCategoryService, SubCategoryService>();
			services.AddScoped<IProductService, ProductService>();
			services.AddScoped<IOrderService, OrderService>();
			services.AddScoped<IShoppingBasketService, ShoppingBasketService>();
			services.AddScoped<IShoppingBasketItemService, ShoppingBasketItemService>();
			services.AddScoped<IContactService, ContactService>();
			services.AddScoped<IMessageService, MessageService>();
			services.AddScoped<IFavoriteService, FavoriteService>();
			return services;
		}
		public static IServiceCollection LoadMyEmailSenderService(this IServiceCollection services)
		{
			services.AddScoped<IEmailSender, SmtpEmailSender>(options => new SmtpEmailSender(
			services.BuildServiceProvider().GetRequiredService<IConfiguration>()["EmailSender:Host"],
			services.BuildServiceProvider().GetRequiredService<IConfiguration>().GetValue<int>("EmailSender:Port"),
			services.BuildServiceProvider().GetRequiredService<IConfiguration>().GetValue<bool>("EmailSender:EnableSSL"),
			services.BuildServiceProvider().GetRequiredService<IConfiguration>()["EmailSender:UserName"],
			services.BuildServiceProvider().GetRequiredService<IConfiguration>()["EmailSender:Password"]
			  ));
			return services;

		}
		public static IServiceCollection LoadMyImageHelperService(this IServiceCollection services)
		{
			services.AddScoped<IImageHelper, ImageHelper>();
			return services;
		}
		public static IServiceCollection LoadMyToastrService(this IServiceCollection services)
		{
			services.AddNotyf(options =>
			{
				options.DurationInSeconds = 3;
				options.Position = NotyfPosition.TopRight;
				//options.HasRippleEffect = true;
				//options.IsDismissable = true;
			});
			return services;
		}
	}
}
