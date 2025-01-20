using SalesDatePredictionModels;
using SalesDatePredictionModels.EntitiesObjects;

namespace SalesDatePredictionBusinnesLogic.Contracts
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetOrders();
        Task<List<Order>> GetOrdersByIdAsync(int orderId);
        Task<List<OrderDto>> GetOrdersByCustomerIdAsync(int customerId);
        Task<List<Order>> GetOrdersByNameAsync(string name);
        Task CreateOrderAsync(OrderDto order);
    }
}
