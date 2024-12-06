using CustomerOrderManagement.Data;
using CustomerOrderManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;

namespace CustomerOrderManagement.Pages.Customers
{
    public class DetailsModel : PageModel
    {
        private readonly NorthwindContext _context;

        public DetailsModel(NorthwindContext context)
        {
            _context = context;
        }

        public Customer Customer { get; set; }

        public IActionResult OnGet(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Customer = _context.Customers.FirstOrDefault(c => c.CustomerID == id);

            if (Customer == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
