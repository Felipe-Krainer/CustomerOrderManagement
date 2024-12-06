using CustomerOrderManagement.Data;
using CustomerOrderManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;

namespace CustomerOrderManagement.Pages.Products
{
    public class DetailsModel : PageModel
    {
        private readonly NorthwindContext _context;

        public DetailsModel(NorthwindContext context)
        {
            _context = context;
        }

        public Product Product { get; set; }

        public IActionResult OnGet(int id)
        {
            Product = _context.Products.FirstOrDefault(p => p.ProductID == id);

            if (Product == null)
            {
                return NotFound("Product not found.");
            }

            return Page();
        }
    }
}
