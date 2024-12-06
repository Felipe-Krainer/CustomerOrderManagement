using CustomerOrderManagement.Data;
using CustomerOrderManagement.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace CustomerOrderManagement.Pages.Orders
{
    public class IndexModel : PageModel
    {
        private readonly NorthwindContext _context;

        public IndexModel(NorthwindContext context)
        {
            _context = context;
        }

        public IList<Order> Orders { get; set; }
        public string SearchTerm { get; set; }

        public void OnGet(string searchTerm)
        {
            SearchTerm = searchTerm;

            // Filter orders based on search term
            Orders = _context.Orders
                .Where(o => string.IsNullOrEmpty(SearchTerm) ||
                            o.CustomerID.Contains(SearchTerm))
                .ToList();
        }
    }
}
