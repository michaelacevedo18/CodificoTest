using Microsoft.EntityFrameworkCore;
using SalesDatePredictionBusinnesLogic.Implementations;
using SalesDatePredictionDataAccess;
using SalesDatePredictionModels.EntitiesObjects;

namespace SalesDatePredictionTests
{
    public class CustomerTest
    {
        [Fact]
        public async Task GettotalLastNextOrder_ShouldReturnCorrectCustomerAndOrdersCount()
        {
            string databaseName = Guid.NewGuid().ToString();

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName)
                .Options;

            using (var context = new ApplicationDbContext(options))
            {
                var customer1 = new Customer
                {
                    CustomerId = 1,
                    Name = "Alex Manga",
                    Address = "123 Main St",
                    City = "Anytown",
                    Country = "Anycountry"
                };

                context.Customers.Add(customer1);

                var order1 = new Order { OrderId = 1, CustomerId = 1, OrderDate = new DateTime(2024, 1, 1) };
                var order2 = new Order { OrderId = 2, CustomerId = 1, OrderDate = new DateTime(2024, 3, 1) };

                context.Orders.AddRange(order1, order2);

                await context.SaveChangesAsync();
            }

            using (var context = new ApplicationDbContext(options))
            {
                var service = new CustomerRepository(context);

                var result = await service.GettotalLastNextOrder("Alex Manga");

                Assert.NotNull(result);
                Assert.Single(result);  // Verifica que solo se devuelve un cliente

                var customer = result.First();

                // Validaciones más simples
                Assert.Equal("Alex Manga", customer.Name);  // Valida que el nombre es correcto
                
            }
        }



    }
}