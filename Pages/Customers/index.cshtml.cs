using CustomerOrderManagement.Data;
using CustomerOrderManagement.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace CustomerOrderManagement.Pages.Customers
{
    public class IndexModel : PageModel
    {
        private readonly NorthwindContext _context;

        public IndexModel(NorthwindContext context)
        {
            _context = context;
        }

        public IList<Customer> Customers { get; set; }
        public string SearchTerm { get; set; }

        public void OnGet(string searchTerm)
        {
            SearchTerm = searchTerm;

            // Filter customers based on search term
            Customers = _context.Customers
                .Where(c => string.IsNullOrEmpty(SearchTerm) ||
                            c.CompanyName.Contains(SearchTerm) ||
                            c.ContactName.Contains(SearchTerm))
                .ToList();
        }
    }
}
