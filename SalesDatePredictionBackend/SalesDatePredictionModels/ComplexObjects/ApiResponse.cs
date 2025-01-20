

namespace SalesDatePredictionModels.ComplexObjects
{
    public class ApiResponse
    {
        public bool IsSuccess { get; set; } = true;
        public int QuantityResults { get; set; }
        public object Result { get; set; }        
        public string DisplayMessage { get; set; }
        public object ErrorMessages { get; set; }

    }
}

