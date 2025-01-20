using SalesDatePredictionModels;
using SalesDatePredictionModels.EntitiesObjects;


namespace SalesDatePredictionBusinnesLogic.Contracts
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetEmployees();
        
    }
}
