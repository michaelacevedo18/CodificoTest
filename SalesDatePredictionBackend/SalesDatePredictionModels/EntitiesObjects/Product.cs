namespace SalesDatePredictionModels.EntitiesObjects
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
