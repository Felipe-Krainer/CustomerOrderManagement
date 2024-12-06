using CustomerOrderManagement.Data;
using CustomerOrderManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CustomerOrderManagement.Pages.Products
{
    public class DeleteModel : PageModel
    {
        private readonly NorthwindContext _context;

        public DeleteModel(NorthwindContext context)
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
            var productInDb = _context.Products.FirstOrDefault(p => p.ProductID == Product.ProductID);

            if (productInDb == null)
            {
                return NotFound("Product not found.");
            }

            try
            {
                _context.Products.Remove(productInDb);
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                // Handle foreign key constraint error
                ModelState.AddModelError(string.Empty, "Unable to delete product. It is being referenced by other records.");
                return Page();
            }

            return RedirectToPage("./Index");
        }
    }
}
