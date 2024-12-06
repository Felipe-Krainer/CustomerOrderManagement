using System.ComponentModel.DataAnnotations;

namespace CustomerOrderManagement.Models
{
    public class Product
    {
        public int ProductID { get; set; }

        [Required(ErrorMessage = "Product name is required.")]
        public string ProductName { get; set; }

        public int? SupplierID { get; set; }
        public int? CategoryID { get; set; }

        public string? QuantityPerUnit { get; set; }

        [DataType(DataType.Currency)]
        public decimal? UnitPrice { get; set; }

        public int? UnitsInStock { get; set; }
        public int? UnitsOnOrder { get; set; }
        public int? ReorderLevel { get; set; }
        public bool Discontinued { get; set; }
    }
}
