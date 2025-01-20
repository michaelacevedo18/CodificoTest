using Microsoft.EntityFrameworkCore;
using SalesDatePredictionBusinnesLogic.Contracts;
using SalesDatePredictionDataAccess;
using SalesDatePredictionModels;
using SalesDatePredictionModels.EntitiesObjects;

namespace SalesDatePredictionBusinnesLogic.Implementations
{
    public class CustomerRepository: ICustomerRepository
    {
        private readonly ApplicationDbContext _context;

        public CustomerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Customer>> GetCustomersAsync()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<Customer> GetCustomerByIdAsync(int customerId)
        {
            return await _context.Customers
                .FirstOrDefaultAsync(c => c.CustomerId == customerId);
        }

        public async Task<IEnumerable<Order>> GetOrdersByCustomerIdAsync(int customerId)
        {
            return await _context.Orders
                .Where(o => o.CustomerId == customerId)
                .ToListAsync();
        }

        public async Task<List<CustomerDto>> GetLastNextOrder(int customerId)
        {
            var orders = await _context.Orders.Where(o => o.CustomerId == customerId).Include(o => o.Customer).ToListAsync();

            var result = orders
                .GroupBy(o => new { o.Customer.CustomerId, o.Customer.Name })
                .Select(g =>
                {
                    var orderDates = g.Select(o => o.OrderDate).OrderBy(d => d).ToList();
                    var averageDaysBetweenOrders = orderDates.Count > 1
                        ? orderDates.Zip(orderDates.Skip(1), (first, second) => (second - first).Days).Average()
                        : 0;

                    return new CustomerDto
                    {
                        CustomerId = g.Key.CustomerId,
                        Name = g.Key.Name,
                        LastOrderDate = orderDates.Last(),
                        NextPredictedOrderDate = orderDates.Last().AddDays(averageDaysBetweenOrders)
                    };
                })
                .ToList();

            return result;
        }

        public async Task<List<CustomerDto>> GettotalLastNextOrder(string Name)
        {
            List<Order> orders;
                        
            if (string.IsNullOrEmpty(Name) || Name=="Empty")
            {
                orders = await _context.Orders.Include(o => o.Customer).ToListAsync();
            }
            else
            {
                orders = await _context.Orders.Include(o => o.Customer)
                                     .Where(x => EF.Functions.Like(x.Customer.Name, $"%{Name}%"))
                                     .ToListAsync();
            }


            var result = orders
                .GroupBy(o => new { o.Customer.CustomerId, o.Customer.Name })
                .Select(g =>
                {                    
                    var orderDates = g.Select(o => o.OrderDate).OrderBy(d => d).ToList();
                                        
                    if (orderDates.Count == 0)
                    {
                        return null;
                    }
                    var averageDaysBetweenOrders = 0.0;
                    if (orderDates.Count > 1)
                    {
                        averageDaysBetweenOrders = orderDates.Zip(orderDates.Skip(1), (first, second) => (second - first).Days).Average();
                    }


                    return new CustomerDto
                    {
                        CustomerId = g.Key.CustomerId,
                        Name = g.Key.Name,
                        LastOrderDate = orderDates.Last(),
                        NextPredictedOrderDate = orderDates.Count > 1
                            ? orderDates.Last().AddDays(averageDaysBetweenOrders)
                            : orderDates.Last()
                    };
                })
                .Where(dto => dto != null) 
                .ToList();

            return result;
        }


    }
}
