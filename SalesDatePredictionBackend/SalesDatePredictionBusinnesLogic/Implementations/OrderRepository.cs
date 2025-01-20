using Microsoft.EntityFrameworkCore;
using SalesDatePredictionBusinnesLogic.Contracts;
using SalesDatePredictionDataAccess;
using SalesDatePredictionModels;
using SalesDatePredictionModels.EntitiesObjects;

namespace SalesDatePredictionBusinnesLogic.Implementations
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;
        public OrderRepository(ApplicationDbContext context)
        {

            _context = context;

        }
        public async Task<List<Order>> GetOrders()
        {
            return await _context.Orders.ToListAsync();
        }


        public async Task<List<OrderDto>> GetOrdersByCustomerIdAsync(int customerId)
        {
            var orders = await _context.Orders
                .Where(x => x.CustomerId == customerId)
                .Include(x => x.Shipper)  // Incluimos la relación con Shipper
                .ToListAsync();

            
            var orderDtos = orders.Select(order => new OrderDto
            {
                CustomerId = order.CustomerId,
                OrderId = order.OrderId,
                RequiredDate = order.RequiredDate,
                ShippedDate = order.ShippedDate,
                ShipperId = order.ShipperId,
                ShipperName = order.Shipper.ShipName,
                ShipperAddress = order.Shipper.ShipAddress,
                ShipperCity = order.Shipper.ShipCity,
            }).ToList();

            return orderDtos;
        }


        public async Task<List<Order>> GetOrdersByNameAsync(string customerName)
        {
            return await _context.Orders
                                 .Where(o => EF.Functions.Like(o.Customer.Name, $"%{customerName}%"))
                                 .ToListAsync();
        }
                
        public async Task<List<Order>> GetOrdersByIdAsync(int orderId)
        {
            return await _context.Orders.Where(x => x.OrderId == orderId).ToListAsync();
        }

        public async Task CreateOrderAsync(OrderDto order)
        {
            var orderEnt = new Order
            {
                EmployeeId = order.EmployeeId,
                ShipperId = order.ShipperId,
                CustomerId = order.CustomerId,
                OrderDate = order.OrderDate,
                RequiredDate = order.RequiredDate,
                ShippedDate = order.ShippedDate,
                Freight = order.Freight,

                OrderDetails = order.OrderDetails.Select(od => new OrderDetail
                {
                    ProductId = od.ProductId,
                    UnitPrice = od.UnitPrice,
                    Quantity = od.Quantity,
                    Discount = od.Discount
                }).ToList()
            };
            _context.Orders.Add(orderEnt);
            await _context.SaveChangesAsync();
        }
    }
}
