using RhythmicRealm.Entity.Concrete;

namespace RhythmicRealm.Data.Abstract
{
    public interface IOrderRepository : IGenericRepository<Order>
	{
		Task<List<Order>> GetAllOrdersByProductIdAsync(int productId);
	}
}
