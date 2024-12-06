using CustomerOrderManagement.Data;
using CustomerOrderManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Linq;

namespace CustomerOrderManagement.Pages.Orders
{
    public class EditModel : PageModel
    {
        private readonly NorthwindContext _context;

        public EditModel(NorthwindContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Order Order { get; set; }

        public IActionResult OnGet(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid Order ID.");
            }

            Order = _context.Orders.FirstOrDefault(o => o.OrderID == id);

            if (Order == null)
            {
                return NotFound("Order not found.");
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var orderInDb = _context.Orders.FirstOrDefault(o => o.OrderID == Order.OrderID);

            if (orderInDb == null)
            {
                return NotFound("Order not found.");
            }

            orderInDb.CustomerID = Order.CustomerID;
            orderInDb.OrderDate = Order.OrderDate;

            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "An error occurred while updating the order. Please try again.");
                Console.WriteLine(ex.Message);
                return Page();
            }

            return RedirectToPage("./Index");
        }
    }
}
