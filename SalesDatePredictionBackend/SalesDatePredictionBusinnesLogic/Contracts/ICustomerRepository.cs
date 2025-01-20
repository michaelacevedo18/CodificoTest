using SalesDatePredictionModels;
using SalesDatePredictionModels.EntitiesObjects;

namespace SalesDatePredictionBusinnesLogic.Contracts
{
    
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetCustomersAsync();
        Task<Customer> GetCustomerByIdAsync(int customerId);
        Task<IEnumerable<Order>> GetOrdersByCustomerIdAsync(int customerId);
        Task<List<CustomerDto>> GetLastNextOrder(int customerId);
        Task<List<CustomerDto>> GettotalLastNextOrder(string Name);
    }
}
