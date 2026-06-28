using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace cafe.Models
{
    public class Order
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Ad ve Soyad alanı zorunludur.")]
        [MaxLength(100, ErrorMessage = "Ad Soyad en fazla 100 karakter olabilir.")]
        public string CustomerName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Telefon numarası zorunludur.")]
        [RegularExpression(@"^05\d{2}\s?\d{3}\s?\d{2}\s?\d{2}$", ErrorMessage = "Telefon numarası 05XX XXX XX XX formatında (11 hane) olmalıdır.")]
        public string CustomerPhone { get; set; } = string.Empty;

        [MaxLength(500)]
        public string? CustomerAddress { get; set; } = string.Empty; // Artık isteğe bağlı (Adres yerine masa no vb. için kullanılabilir)

        public DateTime OrderDate { get; set; } = DateTime.Now;

        public decimal TotalAmount { get; set; }

        public bool IsCompleted { get; set; } = false;

        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
