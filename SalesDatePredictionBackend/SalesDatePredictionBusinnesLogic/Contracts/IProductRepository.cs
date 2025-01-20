using SalesDatePredictionModels.EntitiesObjects;

namespace SalesDatePredictionBusinnesLogic.Contracts
{
    public interface IProductRepository
    {
        Task<List<Product>> GetProducts();
    }
}
