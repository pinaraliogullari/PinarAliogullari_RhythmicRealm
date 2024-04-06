using AutoFixture;
using Moq;
using RhythmicRealm.Data.Abstract;
using RhythmicRealm.Entity.Concrete.Others;
using RhythmicRealm.Service.Concrete;
using Xunit;

namespace RhythmicRealm.Test.Services
{
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

	}
}
