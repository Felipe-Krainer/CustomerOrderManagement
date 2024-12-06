using CustomerOrderManagement.Data;
using CustomerOrderManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CustomerOrderManagement.Pages.Orders
{
    public class CreateModel : PageModel
    {
        private readonly NorthwindContext _context;

        public CreateModel(NorthwindContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Order Order { get; set; }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Orders.Add(Order);
            _context.SaveChanges();

            return RedirectToPage("./Index");
        }
    }
}

