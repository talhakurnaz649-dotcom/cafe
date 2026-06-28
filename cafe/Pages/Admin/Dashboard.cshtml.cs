using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using cafe.Data;
using cafe.Models;

namespace cafe.Pages.Admin
{
    [Authorize(Roles = "Admin")]
    public class DashboardModel : PageModel
    {
        private readonly CafeDbContext _context;

        public DashboardModel(CafeDbContext context)
        {
            _context = context;
        }

        public int TotalOrders { get; set; }
        public int PendingOrders { get; set; }
        public int CompletedOrders { get; set; }
        public decimal TotalRevenue { get; set; }
        public int TotalProducts { get; set; }
        public List<Order> RecentOrders { get; set; } = new List<Order>();

        public async Task OnGetAsync()
        {
            TotalOrders = await _context.Orders.CountAsync();
            PendingOrders = await _context.Orders.CountAsync(o => !o.IsCompleted);
            CompletedOrders = await _context.Orders.CountAsync(o => o.IsCompleted);
            TotalRevenue = await _context.Orders.SumAsync(o => o.TotalAmount);
            TotalProducts = await _context.Products.CountAsync();

            RecentOrders = await _context.Orders
                .OrderByDescending(o => o.OrderDate)
                .Take(5)
                .ToListAsync();
        }
    }
}
