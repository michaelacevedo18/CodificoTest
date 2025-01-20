using System.ComponentModel.DataAnnotations;

namespace SalesDatePredictionModels.EntitiesObjects
{
    public class Employee
    {
        [Key]
        public int EmpId {  get; set; }
        public string FullName {  get; set; }        
        public ICollection<Order> Orders { get; set; }
    }
}
