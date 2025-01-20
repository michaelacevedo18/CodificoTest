using Microsoft.EntityFrameworkCore;
using SalesDatePredictionBusinnesLogic.Implementations;
using SalesDatePredictionDataAccess;
using SalesDatePredictionModels.EntitiesObjects;

namespace SalesDatePredictionTests
{
    public class EmployeeTest
    {
        [Fact]
        public async Task GetEmployees_ShouldReturnAllEmployees()
        {         
            string databaseName = Guid.NewGuid().ToString();

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: databaseName)
                .Options;

            using (var context = new ApplicationDbContext(options))
            {
                context.Employees.AddRange(
                    new Employee { EmpId = 1, FullName = "John Doe" },
                    new Employee { EmpId = 2, FullName = "Jane Smith" }
                );
                await context.SaveChangesAsync();
            }

            using (var context = new ApplicationDbContext(options))
            {
                var repository = new EmployeeRepository(context);

                var result = await repository.GetEmployees();

                Assert.NotNull(result);
                Assert.Equal(2, result.Count);
                Assert.Contains(result, e => e.FullName == "John Doe");
                Assert.Contains(result, e => e.FullName == "Jane Smith");
            }
        }

    }
}