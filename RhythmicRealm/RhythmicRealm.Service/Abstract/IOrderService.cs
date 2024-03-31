using RhythmicRealm.Entity.Concrete;
using RhythmicRealm.Shared.ComplexTypes;
using RhythmicRealm.Shared.ViewModels.OrderViewModels;

namespace RhythmicRealm.Service.Abstract
{
	public interface IOrderService
	{
		Task CreateOrderAsync(Order order);
		Task<List<OrderListViewModel>> GetOrdersAsync(string userId=null);
		Task<List<OrderListViewModel>> GetOrdersAsync(int productId);
		Task<OrderListViewModel>GetOrderAsync(int orderId);
		Task<EnumOrderState> UpdateOrderState(int id,EnumOrderState orderState);
	}
}
