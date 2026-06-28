using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using cafe.Data;
using cafe.Models;
using System.Text.Json;

namespace cafe.Pages
{
    public class MenuModel : PageModel
    {
        private readonly CafeDbContext _context;

        public MenuModel(CafeDbContext context)
        {
            _context = context;
        }

        public IList<Product> Products { get;set; } = default!;
        
        [BindProperty(SupportsGet = true)]
        public string? SelectedCategory { get; set; }

        public async Task OnGetAsync()
        {
            var query = _context.Products.Where(p => p.IsActive);
            
            if (!string.IsNullOrEmpty(SelectedCategory) && SelectedCategory != "Hepsi")
            {
                query = query.Where(p => p.Category == SelectedCategory);
            }

            Products = await query.ToListAsync();
        }

        public async Task<IActionResult> OnPostAddToCartAsync(int productId)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null || !product.IsActive)
            {
                return NotFound();
            }

            var cart = GetCartFromSession();
            var existingItem = cart.FirstOrDefault(c => c.ProductId == productId);

            if (existingItem != null)
            {
                existingItem.Quantity++;
            }
            else
            {
                cart.Add(new CartItem
                {
                    ProductId = product.Id,
                    ProductName = product.Name,
                    Price = product.Price,
                    Quantity = 1,
                    ImageUrl = product.ImageUrl
                });
            }

            SaveCartToSession(cart);

            TempData["Message"] = $"{product.Name} sepete eklendi!";
            return RedirectToPage();
        }

        private List<CartItem> GetCartFromSession()
        {
            var sessionData = HttpContext.Session.GetString("Cart");
            return sessionData == null 
                ? new List<CartItem>() 
                : JsonSerializer.Deserialize<List<CartItem>>(sessionData) ?? new List<CartItem>();
        }

        private void SaveCartToSession(List<CartItem> cart)
        {
            HttpContext.Session.SetString("Cart", JsonSerializer.Serialize(cart));
        }
    }
}
