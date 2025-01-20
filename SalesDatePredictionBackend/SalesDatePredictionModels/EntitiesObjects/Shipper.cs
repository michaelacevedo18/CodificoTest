namespace SalesDatePredictionModels.EntitiesObjects
{
    //Transportista
    public class Shipper 
    {
        public int ShipperId {  get; set; }        
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string ShipCountry { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
