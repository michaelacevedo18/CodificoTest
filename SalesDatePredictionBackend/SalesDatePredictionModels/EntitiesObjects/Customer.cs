using System.ComponentModel.DataAnnotations.Schema;

namespace SalesDatePredictionModels.EntitiesObjects
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
     
        public ICollection<Order> Orders { get; set; }

    }
}
