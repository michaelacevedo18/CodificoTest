using SalesDatePredictionModels.EntitiesObjects;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace SalesDatePredictionModels
{
    public class CustomerDto
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }


        [NotMapped]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime LastOrderDate { get; set; }

        [NotMapped]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime NextPredictedOrderDate { get; set; }

    }
}
