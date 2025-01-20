using Microsoft.EntityFrameworkCore;
using SalesDatePredictionBusinnesLogic.Contracts;
using SalesDatePredictionDataAccess;
using SalesDatePredictionModels.EntitiesObjects;

namespace SalesDatePredictionBusinnesLogic.Implementations
{
    public class ProductRepository: IProductRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context)
        {

            _context = context;

        }

        public async Task<List<Product>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }
    }
}
