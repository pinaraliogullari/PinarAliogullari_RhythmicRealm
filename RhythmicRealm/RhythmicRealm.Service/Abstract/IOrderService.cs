using RhythmicRealm.Entity.Concrete;
using RhythmicRealm.Shared.ComplexTypes;
using RhythmicRealm.Shared.Response;
using RhythmicRealm.Shared.ViewModels.OrderViewModels;

namespace RhythmicRealm.Service.Abstract
{
	public interface IOrderService
	{
		Task <Response<NoContent>> CreateOrderAsync(Order order);
		Task<Response<List<OrderListViewModel>>> GetOrdersAsync(string userId=null);
		Task<Response<List<OrderListViewModel>>> GetOrdersByOrderStateAsync(EnumOrderState orderState);
		Task<Response<List<OrderListViewModel>>> GetOrdersAsync(int productId);
		Task<Response<OrderListViewModel>>GetOrderAsync(int orderId);
		Task<EnumOrderState> UpdateOrderStateAsync(int id,EnumOrderState orderState);
	}
}
