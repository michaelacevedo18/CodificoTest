using Microsoft.EntityFrameworkCore;
using SalesDatePredictionBusinnesLogic.Contracts;
using SalesDatePredictionDataAccess;
using SalesDatePredictionModels.EntitiesObjects;

namespace SalesDatePredictionBusinnesLogic.Implementations
{
    public class ShipperRepository: IShipperRepository
    {
        private readonly ApplicationDbContext _context;
        public ShipperRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Shipper>> GetShippers()
        {
            return await _context.Shippers.ToListAsync();

        }
    }
}
