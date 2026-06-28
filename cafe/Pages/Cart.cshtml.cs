using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using cafe.Data;
using cafe.Models;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace cafe.Pages
{
    public class CartModel : PageModel
    {
        private readonly CafeDbContext _context;

        public CartModel(CafeDbContext context)
        {
            _context = context;
        }

        public List<CartItem> CartItems { get; set; } = new List<CartItem>();

        public decimal TotalAmount => CartItems.Sum(x => x.TotalPrice);

        [BindProperty]
        public Order CustomerOrder { get; set; } = new Order();

        [BindProperty]
        [Required(ErrorMessage = "Kart üzerindeki isim zorunludur.")]
        [MaxLength(100, ErrorMessage = "İsim alanı çok uzun.")]
        public string CardName { get; set; } = string.Empty;

        [BindProperty]
        [Required(ErrorMessage = "Kart numarası zorunludur.")]
        [RegularExpression(@"^[0-9]{4}\s[0-9]{4}\s[0-9]{4}\s[0-9]{4}$", ErrorMessage = "Kart numarası geçersiz (XXXX XXXX XXXX XXXX şeklinde olmalıdır).")]
        public string CardNumber { get; set; } = string.Empty;

        [BindProperty]
        [Required(ErrorMessage = "Son kullanma tarihi zorunludur.")]
        [RegularExpression(@"^(0[1-9]|1[0-2])\/[0-9]{2}$", ErrorMessage = "Format AA/YY şeklinde olmalıdır.")]
        public string CardExpiration { get; set; } = string.Empty;

        [BindProperty]
        [Required(ErrorMessage = "CVV zorunludur.")]
        [RegularExpression(@"^[0-9]{3}$", ErrorMessage = "CVV 3 haneli bir sayı olmalıdır.")]
        public string CardCVV { get; set; } = string.Empty;

        public void OnGet()
        {
            CartItems = GetCartFromSession();
        }

        public IActionResult OnPostUpdateQuantity(int productId, string action)
        {
            var cart = GetCartFromSession();
            var item = cart.FirstOrDefault(c => c.ProductId == productId);

            if (item != null)
            {
                if (action == "increase")
                {
                    item.Quantity++;
                }
                else if (action == "decrease")
                {
                    item.Quantity--;
                    if (item.Quantity <= 0)
                    {
                        cart.Remove(item);
                    }
                }
            }

            SaveCartToSession(cart);
            return RedirectToPage();
        }

        public IActionResult OnPostRemoveItem(int productId)
        {
            var cart = GetCartFromSession();
            var item = cart.FirstOrDefault(c => c.ProductId == productId);

            if (item != null)
            {
                cart.Remove(item);
            }

            SaveCartToSession(cart);
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostCheckoutAsync()
        {
            CartItems = GetCartFromSession();

            if (!CartItems.Any())
            {
                ModelState.AddModelError("", "Sepetiniz boş! Sipariş vermek için lütfen sepete ürün ekleyin.");
                return Page();
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Create new Order
            var order = new Order
            {
                CustomerName = CustomerOrder.CustomerName,
                CustomerPhone = CustomerOrder.CustomerPhone,
                CustomerAddress = "Online Ödeme / Kredi Kartı", // Adres istenmiyor, kredi kartı ödemeli sipariş
                OrderDate = DateTime.Now,
                TotalAmount = TotalAmount,
                IsCompleted = false
            };

            _context.Orders.Add(order);
            await _context.SaveChangesAsync(); // Generates order ID

            // Add OrderItems
            foreach (var item in CartItems)
            {
                var orderItem = new OrderItem
                {
                    OrderId = order.Id,
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    UnitPrice = item.Price
                };
                _context.OrderItems.Add(orderItem);
            }

            await _context.SaveChangesAsync();

            // Clear Cart Session
            HttpContext.Session.Remove("Cart");

            TempData["SuccessOrderId"] = order.Id;
            return RedirectToPage("/OrderSuccess");
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
