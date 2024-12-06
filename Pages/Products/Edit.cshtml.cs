using CustomerOrderManagement.Data;
using CustomerOrderManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;

namespace CustomerOrderManagement.Pages.Products
{
    public class EditModel : PageModel
    {
        private readonly NorthwindContext _context;

        public EditModel(NorthwindContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var productInDb = _context.Products.FirstOrDefault(p => p.ProductID == Product.ProductID);

            if (productInDb == null)
            {
                return NotFound("Product not found.");
            }

            productInDb.ProductName = Product.ProductName;
            productInDb.UnitPrice = Product.UnitPrice;
            productInDb.UnitsInStock = Product.UnitsInStock;

            _context.SaveChanges();

            return RedirectToPage("./Index");
        }
    }
}
