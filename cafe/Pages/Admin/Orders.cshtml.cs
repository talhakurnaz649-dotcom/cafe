using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using cafe.Data;
using cafe.Models;

namespace cafe.Pages.Admin
{
    [Authorize(Roles = "Admin")]
    public class OrdersModel : PageModel
    {
        private readonly CafeDbContext _context;

        public OrdersModel(CafeDbContext context)
        {
            _context = context;
        }

        public IList<Order> Orders { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Orders = await _context.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .OrderByDescending(o => o.OrderDate)
                .ToListAsync();
        }

        public async Task<IActionResult> OnPostMarkCompletedAsync(int orderId)
        {
            var order = await _context.Orders.FindAsync(orderId);
            if (order == null)
            {
                return NotFound();
            }

            order.IsCompleted = true;
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = $"Sipariş #{orderId} tamamlandı olarak işaretlendi.";
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostDeleteOrderAsync(int orderId)
        {
            var order = await _context.Orders.FindAsync(orderId);
            if (order == null)
            {
                return NotFound();
            }

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = $"Sipariş #{orderId} silindi.";
            return RedirectToPage();
        }
    }
}
