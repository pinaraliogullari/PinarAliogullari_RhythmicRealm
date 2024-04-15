using Moq;
using RhythmicRealm.Data.Abstract;
using RhythmicRealm.Entity.Concrete.Others;
using RhythmicRealm.Service.Concrete;
using Xunit;

namespace RhythmicRealm.Test.Services
{

	//verileri ayarla
	//setup
	//metodu çağır
	//sonuçlar
	public class FavoriteServiceTest
	{

		//private readonly Fixture _fixture;
  //      public FavoriteServiceTest()
  //      {
  //          _fixture = new Fixture();
  //      }

        [Fact]
		public async Task GetAllFavoritesAsync_ReturnFailResponse_WhenFavoriteProductNotFound()
		{
			var userId = Guid.NewGuid().ToString();
			var favoriteRepoMock = new Mock<IFavoriteRepository>();
			favoriteRepoMock.Setup(x => x.GetFavoritesAsync(userId)).ReturnsAsync(new List<Favorite>());

			var favService = new FavoriteService(favoriteRepoMock.Object);

			var result = favService.GetAllFavoritesAsync(userId);

			Assert.False(result.Result.IsSucceesed);
			Assert.Equal(result.Result.StatusCode, 404);
		}

		[Fact]
		public async Task GetAllFavoritesAsync_ReturnSuccessResponse_WhenGetFavoriteProducts()
		{
			var userId = Guid.NewGuid().ToString();
			var favProducts = new List<Favorite>() { new Favorite() };
			var favoriteRepoMock = new Mock<IFavoriteRepository>();
			favoriteRepoMock.Setup(x => x.GetFavoritesAsync(userId)).ReturnsAsync(favProducts);

			var favService = new FavoriteService(favoriteRepoMock.Object);

			var result = favService.GetAllFavoritesAsync(userId);

			Assert.True(result.Result.IsSucceesed);
			Assert.Equal(result.Result.StatusCode, 200);
		}

		[Fact]
		public async Task AddToFavoritesAsync_ReturnSuccessResponse_WhenAddedFavoriteProduct()
		{
			var userId = Guid.NewGuid().ToString();
			var productId = 1111;

			var favoriteRepoMock = new Mock<IFavoriteRepository>();
			var favProducts = new List<Favorite>();
			favoriteRepoMock.Setup(x => x.GetFavoritesAsync(It.IsAny<string>())).ReturnsAsync(new List<Favorite>());

			favoriteRepoMock.Setup(x => x.CreateAsync(It.IsAny<Favorite>())).Callback((Favorite fav) =>
			{
				favProducts.Add(fav);
			});


			var favService = new FavoriteService(favoriteRepoMock.Object);

			var result = favService.AddToFavoritesAsync(userId, productId);

			Assert.True(result.Result.IsSucceesed);
			Assert.Equal(result.Result.StatusCode, 200);
			Assert.Single(favProducts);
		}

		[Fact]
		public async Task AddToFavoritesAsync_ReturnSuccessResponse_WhenExistingFavoriteProductInFavoriteProduct()
		{
			var userId = Guid.NewGuid().ToString();
			var productId = 1111;

			var favoriteRepoMock = new Mock<IFavoriteRepository>();
			var favProducts = new List<Favorite>();

			favoriteRepoMock.Setup(x => x.GetFavoritesAsync(It.IsAny<string>())).ReturnsAsync(new List<Favorite>() { new Favorite()});
			var favService = new FavoriteService(favoriteRepoMock.Object);

			var result = favService.AddToFavoritesAsync(userId, productId);

			Assert.False(result.Result.IsSucceesed);
			Assert.Equal(result.Result.StatusCode, 500);
		}

		[Fact]
		public async Task IsProductFavoriteAsync_ReturnSuccessResponse_WhenProductIsFavorite()
		{
			var userId= Guid.NewGuid().ToString();
			var productId = 2222;
			var favoriteRepoMock= new Mock<IFavoriteRepository>();
			var favProduct = new List<Favorite>();

			favoriteRepoMock.Setup(x => x.GetFavoriteByProductAsync(userId, productId)).ReturnsAsync( new List<Favorite>()
			{
				new Favorite()
			});
			var favService = new FavoriteService(favoriteRepoMock.Object);

			var result= await favService.IsProductFavoriteAsync(userId, productId);

			Assert.True(result);
		}

		[Fact]
		public async Task IsProductFavoriteAsync_ReturnFailResponse_WhenProductIsNotFavorite()
		{
			var userId=Guid.NewGuid().ToString();
			var productId = 2222;
			var favoriteRepoMock= new Mock<IFavoriteRepository>();
			var favProduct= new List<Favorite>();

			favoriteRepoMock.Setup(x => x.GetFavoriteByProductAsync(userId, productId)).ReturnsAsync(new List<Favorite>());
			var favService= new FavoriteService(favoriteRepoMock.Object);

			var result = await favService.IsProductFavoriteAsync(userId, productId);

			Assert.False(result);
			
		}

		[Fact]
		public async Task RemoveFromFavoriteAsync_ReturnSuccessResponse_WhenProductIsRemoveFromFavoriteList()
		{
			var userId= Guid.NewGuid().ToString();
			var productId = 1111;
			var favoriteRepoMock= new Mock<IFavoriteRepository>();
			var favProduct= new List<Favorite>();	
			favoriteRepoMock.Setup(x=>x.GetFavoritesAsync(userId)).ReturnsAsync(new List<Favorite>()
			{
				new Favorite()
			});
			var favService = new FavoriteService(favoriteRepoMock.Object);
			var result = await favService.RemoveFromFavoriteAsync(userId,productId);

			Assert.True(result.IsSucceesed);
			Assert.Equal(result.StatusCode, 200);
		}

		[Fact]

		public async Task RemoveFromFavoriteAsync_ReturnFailResponse_WhenProductIsRemoveFromFavoriteList()
		{
			var userId= Guid.NewGuid().ToString();
			var productId = 1111;
			var favoriteRepoMock= new Mock<IFavoriteRepository>();
			var favProduct= new List<Favorite>();

			favoriteRepoMock.Setup(x => x.GetFavoritesAsync(userId)).ReturnsAsync(new List<Favorite>());
			var favService= new FavoriteService (favoriteRepoMock.Object);

			var result= await favService.RemoveFromFavoriteAsync(userId,productId);

			Assert.False(result.IsSucceesed);
			Assert.Equal(result.StatusCode, 500);
		}
	}
}
