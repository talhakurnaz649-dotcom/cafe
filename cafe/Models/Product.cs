using System.ComponentModel.DataAnnotations;

namespace cafe.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Ürün adı zorunludur.")]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(500)]
        public string Description { get; set; } = string.Empty;

        [Range(0.01, 10000.00, ErrorMessage = "Geçerli bir fiyat giriniz.")]
        public decimal Price { get; set; }

        [MaxLength(500)]
        public string ImageUrl { get; set; } = string.Empty;

        [Required(ErrorMessage = "Kategori zorunludur.")]
        [MaxLength(50)]
        public string Category { get; set; } = "Kahve"; // Kahve veya Tatlı

        public bool IsActive { get; set; } = true;
    }
}
