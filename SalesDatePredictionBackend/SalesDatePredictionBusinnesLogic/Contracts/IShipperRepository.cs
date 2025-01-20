using SalesDatePredictionModels.EntitiesObjects;

namespace SalesDatePredictionBusinnesLogic.Contracts
{
    public interface IShipperRepository
    {
        Task<List<Shipper>> GetShippers();
    }
}
