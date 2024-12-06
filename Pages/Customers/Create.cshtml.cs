using CustomerOrderManagement.Data;
using CustomerOrderManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CustomerOrderManagement.Pages.Customers
{
    public class CreateModel : PageModel
    {
        private readonly NorthwindContext _context;

        public CreateModel(NorthwindContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Customer Customer { get; set; }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Customers.Add(Customer);
            _context.SaveChanges();

            return RedirectToPage("./Index");
        }
    }
}
