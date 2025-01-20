using Microsoft.EntityFrameworkCore;
using SalesDatePredictionBusinnesLogic.Implementations;
using SalesDatePredictionDataAccess;
using SalesDatePredictionModels.DataTransferObjects;
using SalesDatePredictionModels;
using SalesDatePredictionModels.EntitiesObjects;

namespace SalesDatePredictionTests
{
    public class OrderTest
    {
        [Fact]
        public async Task CreateOrderAsync_ShouldAddOrderToDb()
        {            
            string databaseName = Guid.NewGuid().ToString();

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName)
                .Options;
                        
            using (var context = new ApplicationDbContext(options))
            {                
                context.Employees.AddRange(
                    new Employee { EmpId = 1, FullName = "Maik Doe" },
                    new Employee { EmpId = 2, FullName = "Jane Smith" }
                );

                context.Shippers.AddRange(
                    new Shipper { ShipperId = 1, ShipName = "Servientrega", ShipAddress = "Centro A", ShipCity = "Sogamoso", ShipCountry = "Colombia" }
                );

                await context.SaveChangesAsync();
            }
                        
            using (var context = new ApplicationDbContext(options))
            {
                var orderService = new OrderRepository(context);
                
                var orderDto = new OrderDto
                {
                    EmployeeId = 1,
                    ShipperId = 1,
                    CustomerId = 1,
                    OrderDate = DateTime.Now,
                    RequiredDate = DateTime.Now.AddDays(1),
                    ShippedDate = DateTime.Now.AddDays(2),
                    Freight = 100,
                    OrderDetails = new List<OrderDetailDto>
            {
                new OrderDetailDto
                {
                    ProductId = 1,
                    UnitPrice = 10,
                    Quantity = 2,
                    Discount = 1
                }
            }
                };
                                
                await orderService.CreateOrderAsync(orderDto);
                                
                var orderInDb = await context.Orders.FirstOrDefaultAsync(o => o.CustomerId == orderDto.CustomerId);

                Assert.NotNull(orderInDb);
                Assert.Equal(orderDto.CustomerId, orderInDb.CustomerId);
                Assert.Equal(orderDto.Freight, orderInDb.Freight);
                Assert.Equal(orderDto.OrderDetails.Count, orderInDb.OrderDetails.Count);
            }
        }


    }
}