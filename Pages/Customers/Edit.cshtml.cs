using CustomerOrderManagement.Data;
using CustomerOrderManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;

namespace CustomerOrderManagement.Pages.Customers
{
    public class EditModel : PageModel
    {
        private readonly NorthwindContext _context;

        public EditModel(NorthwindContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var customerInDb = _context.Customers.FirstOrDefault(c => c.CustomerID == Customer.CustomerID);
            if (customerInDb == null)
            {
                return NotFound();
            }

            customerInDb.CompanyName = Customer.CompanyName;
            customerInDb.ContactName = Customer.ContactName;
            customerInDb.Country = Customer.Country;

            _context.SaveChanges();

            return RedirectToPage("./Index");
        }
    }
}
