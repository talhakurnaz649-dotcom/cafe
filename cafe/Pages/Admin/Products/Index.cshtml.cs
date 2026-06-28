using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using cafe.Data;
using cafe.Models;

namespace cafe.Pages.Admin.Products
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly CafeDbContext _context;

        public IndexModel(CafeDbContext context)
        {
            _context = context;
        }

        public IList<Product> Products { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Products = await _context.Products.OrderBy(p => p.Category).ThenBy(p => p.Name).ToListAsync();
        }

        public async Task<IActionResult> OnPostToggleActiveAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            product.IsActive = !product.IsActive;
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = $"{product.Name} durumu güncellendi.";
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            // Check if product is in any orders
            var hasOrders = await _context.OrderItems.AnyAsync(oi => oi.ProductId == id);
            if (hasOrders)
            {
                // Soft delete by marking inactive, or show warning.
                product.IsActive = false;
                await _context.SaveChangesAsync();
                TempData["ErrorMessage"] = $"{product.Name} siparişlerde kullanıldığı için silinemedi, ancak pasif hale getirildi.";
            }
            else
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = $"{product.Name} başarıyla silindi.";
            }

            return RedirectToPage();
        }
    }
}
