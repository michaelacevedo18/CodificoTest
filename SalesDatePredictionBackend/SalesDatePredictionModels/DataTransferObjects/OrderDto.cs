using SalesDatePredictionModels.DataTransferObjects;

namespace SalesDatePredictionModels
{
  
    public class OrderDto
    {
        public int OrderId { get; set; }
        public int EmployeeId { get; set; }
        public int ShipperId { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public decimal Freight { get; set; }
        public List<OrderDetailDto> OrderDetails { get; set; }
        public string? ShipperName {  get; set; }
        public string? ShipperAddress { get; set; }
        public string? ShipperCity { get; set; }
    
    }
}
