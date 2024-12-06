using CustomerOrderManagement.Data;
using CustomerOrderManagement.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace CustomerOrderManagement.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly NorthwindContext _context;

        public IndexModel(NorthwindContext context)
        {
            _context = context;
        }

        public IList<Product> Products { get; set; }
        public string SearchTerm { get; set; }

        public void OnGet(string searchTerm)
        {
            SearchTerm = searchTerm;

            // Filter products based on search term
            Products = _context.Products
                .Where(p => string.IsNullOrEmpty(SearchTerm) ||
                            p.ProductName.Contains(SearchTerm))
                .ToList();
        }
    }
}
