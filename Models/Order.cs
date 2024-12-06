using System;
using System.ComponentModel.DataAnnotations;

namespace CustomerOrderManagement.Models
{
    public class Order
    {
        public int OrderID { get; set; }

        [Required(ErrorMessage = "Customer ID is required.")]
        public string CustomerID { get; set; }

        [Required(ErrorMessage = "Order Date is required.")]
        [DataType(DataType.Date)]
        public DateTime? OrderDate { get; set; }

        public string? ShipName { get; set; }
        public string? ShipAddress { get; set; }
        public string? ShipCity { get; set; }
        public string? ShipRegion { get; set; }
        public string? ShipPostalCode { get; set; }
        public string? ShipCountry { get; set; }
    }
}
