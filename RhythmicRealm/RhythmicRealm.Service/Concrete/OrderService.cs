using Microsoft.EntityFrameworkCore;
using RhythmicRealm.Data.Abstract;
using RhythmicRealm.Entity.Concrete;
using RhythmicRealm.Service.Abstract;
using RhythmicRealm.Shared.ComplexTypes;
using RhythmicRealm.Shared.ViewModels.OrderViewModels;


namespace RhythmicRealm.Service.Concrete
{
	public class OrderService : IOrderService
	{
		private readonly IOrderRepository _orderRepository;
		public OrderService(IOrderRepository orderRepository)
		{
			_orderRepository = orderRepository;
		}
		public async Task CreateOrderAsync(Order order)
		{
			await _orderRepository.CreateAsync(order);
		}
		public async Task<OrderListViewModel> GetOrderAsync(int orderId)
		{
			var order = await _orderRepository.GetAsync(x => x.Id == orderId, IncludeExpression => IncludeExpression
			.Include(x => x.OrderItems)
			.ThenInclude(y => y.Product));
			var model = new OrderListViewModel
			{
				Id = order.Id,
				OrderNumber = order.OrderNumber,
				OrderDate = order.OrderDate,
				OrderState = order.OrderState,
				FirstName = order.FirstName,
				LastName = order.LastName,
				Address = order.Address,
				City = order.City,
				PhoneNumber = order.PhoneNumber,
				Email = order.Email,
				OrderItems = order.OrderItems.Select(x => new OrderListViewModel.OrderItemViewModel
                {
					Id = x.Id,
					Price = x.Price,
					Quantity = x.Quantity,
				}).ToList()
			};
			return model;
		}
		public async Task<List<OrderListViewModel>> GetOrdersAsync(string userId = null)
		{
			var orders = await _orderRepository.GetAllAsync(null, includeExpression => includeExpression
			   .Include(x => x.OrderItems)
			   .ThenInclude(y => y.Product)
			   .Include(x => x.User));
			if (!string.IsNullOrEmpty(userId))
			{
				orders = (List<Order>)orders.Where(x => x.UserId == userId);
			}
			var model = orders.Select(order => new OrderListViewModel
			{
				Id = order.Id,
				OrderNumber = order.OrderNumber,
				OrderDate = order.OrderDate,
				OrderState = order.OrderState,
				FirstName = order.FirstName,
				LastName = order.LastName,
				Address = order.Address,
				City = order.City,
				PhoneNumber = order.PhoneNumber,
				Email = order.Email,
				OrderItems = order.OrderItems.Select(x => new OrderListViewModel.OrderItemViewModel
                {
					Id = x.Id,
					Price = x.Price,
					Quantity = x.Quantity,
				}).ToList()
			}).ToList();
			return model;
		}
		public async Task<List<OrderListViewModel>> GetOrdersAsync(int productId)
		{
			var orders= await _orderRepository.GetAllOrdersByProductIdAsync(productId);
			var model = orders.Select(order => new OrderListViewModel
			{
				Id = order.Id,
				OrderNumber = order.OrderNumber,
				OrderDate = order.OrderDate,
				OrderState = order.OrderState,
				FirstName = order.FirstName,
				LastName = order.LastName,
				Address = order.Address,
				City = order.City,
				PhoneNumber = order.PhoneNumber,
				Email = order.Email,
				OrderItems = order.OrderItems.Select(x => new OrderListViewModel.OrderItemViewModel
                {
					Id = x.Id,
					Price = x.Price,
					Quantity = x.Quantity,
				}).ToList()
			}).ToList();
			return model;
		}
		public async Task<EnumOrderState> UpdateOrderState(int id, EnumOrderState orderState)
		{
			var order = await _orderRepository.GetAsync(x => x.Id == id);
			order.OrderState = orderState;
			await _orderRepository.UpdateAsync(order);
			return order.OrderState;
		}
	}
}
