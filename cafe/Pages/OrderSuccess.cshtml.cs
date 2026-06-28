using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using cafe.Data;
using cafe.Models;
using Microsoft.EntityFrameworkCore;

namespace cafe.Pages
{
    public class OrderSuccessModel : PageModel
    {
        private readonly CafeDbContext _context;

        public OrderSuccessModel(CafeDbContext context)
        {
            _context = context;
        }

        public Order? Order { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var orderIdObj = TempData["SuccessOrderId"];
            if (orderIdObj == null || !(orderIdObj is int orderId))
            {
                return RedirectToPage("/Index");
            }

            Order = await _context.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .FirstOrDefaultAsync(o => o.Id == orderId);

            if (Order == null)
            {
                return RedirectToPage("/Index");
            }

            // Keep the TempData just in case of reload, or let it expire. We can keep it or not.
            return Page();
        }
    }
}
