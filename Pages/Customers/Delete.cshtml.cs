using CustomerOrderManagement.Data;
using CustomerOrderManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CustomerOrderManagement.Pages.Customers
{
    public class DeleteModel : PageModel
    {
        private readonly NorthwindContext _context;

        public DeleteModel(NorthwindContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Customer Customer { get; set; }

        public IActionResult OnGet(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest("Invalid Customer ID.");
            }

            Customer = _context.Customers.FirstOrDefault(c => c.CustomerID == id);

            if (Customer == null)
            {
                return NotFound("Customer not found.");
            }

            return Page();
        }

        public IActionResult OnPost(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest("Invalid Customer ID.");
            }

            var customerInDb = _context.Customers.FirstOrDefault(c => c.CustomerID == id);

            if (customerInDb == null)
            {
                return NotFound("Customer not found.");
            }

            try
            {
                _context.Customers.Remove(customerInDb);
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                // Handle foreign key constraint error
                ModelState.AddModelError(string.Empty, "Unable to delete customer. The customer is being referenced by other records (e.g., orders).");
                return Page();
            }

            return RedirectToPage("./Index");
        }
    }
}
