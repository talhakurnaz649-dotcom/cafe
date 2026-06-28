using Microsoft.EntityFrameworkCore;
using cafe.Models;

namespace cafe.Data
{
    public class CafeDbContext : DbContext
    {
        public CafeDbContext(DbContextOptions<CafeDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed Products
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Espresso",
                    Description = "Yoğun kıvamlı ve zengin aromalı klasik İtalyan espressosu.",
                    Price = 70.00m,
                    ImageUrl = "https://images.unsplash.com/photo-1510972527921-ce03766a1cf1?q=80&w=300",
                    Category = "Kahve",
                    IsActive = true
                },
                new Product
                {
                    Id = 2,
                    Name = "Caffe Latte",
                    Description = "Espresso, buharla ısıtılmış süt ve üzerinde hafif süt köpüğü.",
                    Price = 90.00m,
                    ImageUrl = "https://images.unsplash.com/photo-1570968915860-54d5c301fc9f?q=80&w=300",
                    Category = "Kahve",
                    IsActive = true
                },
                new Product
                {
                    Id = 3,
                    Name = "Americano",
                    Description = "Sıcak su ile yumuşatılmış zengin Espresso lezzeti.",
                    Price = 80.00m,
                    ImageUrl = "https://images.unsplash.com/photo-1551046713-bc755f487116?q=80&w=300",
                    Category = "Kahve",
                    IsActive = true
                },
                new Product
                {
                    Id = 4,
                    Name = "Türk Kahvesi",
                    Description = "Geleneksel yöntemlerle cezvede pişirilmiş, bol köpüklü klasik Türk kahvesi.",
                    Price = 65.00m,
                    ImageUrl = "https://images.unsplash.com/photo-1514432324607-a09d9b4aefdd?q=80&w=300",
                    Category = "Kahve",
                    IsActive = true
                },
                new Product
                {
                    Id = 5,
                    Name = "San Sebastian Cheesecake",
                    Description = "İçi yumuşacık ve akışkan, üzeri karamelize yanık İspanyol cheesecake'i.",
                    Price = 140.00m,
                    ImageUrl = "https://images.unsplash.com/photo-1524351199679-46cddf530c04?q=80&w=300",
                    Category = "Tatlı",
                    IsActive = true
                },
                new Product
                {
                    Id = 6,
                    Name = "Çikolatalı Sufle",
                    Description = "Sıcak servis edilen, içi akışkan çikolatalı nefis sufle.",
                    Price = 110.00m,
                    ImageUrl = "https://images.unsplash.com/photo-1606313564200-e75d5e30476c?q=80&w=300",
                    Category = "Tatlı",
                    IsActive = true
                },
                new Product
                {
                    Id = 7,
                    Name = "Tiramisu",
                    Description = "Espresso ile ıslatılmış savoyer bisküvileri ve mascarpone kremasıyla hazırlanan orijinal İtalyan tiramisusu.",
                    Price = 120.00m,
                    ImageUrl = "https://images.unsplash.com/photo-1571877227200-a0d98ea607e9?q=80&w=300",
                    Category = "Tatlı",
                    IsActive = true
                },
                new Product
                {
                    Id = 8,
                    Name = "Flat White",
                    Description = "Espresso ile ince dokulu kadifemsi sıcak sütün mükemmel buluşması.",
                    Price = 95.00m,
                    ImageUrl = "https://images.unsplash.com/photo-1577968897966-3d4325b36b61?q=80&w=300",
                    Category = "Kahve",
                    IsActive = true
                },
                new Product
                {
                    Id = 9,
                    Name = "Caffe Mocha",
                    Description = "Zengin espresso, çikolata sosu, sıcak süt ve krema şöleni.",
                    Price = 105.00m,
                    ImageUrl = "https://images.unsplash.com/photo-1534778101976-62847782c213?q=80&w=300",
                    Category = "Kahve",
                    IsActive = true
                },
                new Product
                {
                    Id = 10,
                    Name = "Cold Brew",
                    Description = "18 saat boyunca soğuk suda demlenmiş, yumuşak içimli soğuk filtre kahve.",
                    Price = 90.00m,
                    ImageUrl = "https://images.unsplash.com/photo-1517701604599-bb29b565090c?q=80&w=300",
                    Category = "Kahve",
                    IsActive = true
                },
                new Product
                {
                    Id = 11,
                    Name = "Çikolatalı Brownie",
                    Description = "İçi ıslak, bol çikolatalı ve ceviz parçacıklı leziz brownie dilimi.",
                    Price = 95.00m,
                    ImageUrl = "https://images.unsplash.com/photo-1564355808539-22fda35bed7e?q=80&w=300",
                    Category = "Tatlı",
                    IsActive = true
                },
                new Product
                {
                    Id = 12,
                    Name = "Havuçlu Tarçınlı Kek",
                    Description = "Ceviz, havuç ve tarçın eşliğinde ev yapımı kıvamında leziz kek dilimi.",
                    Price = 85.00m,
                    ImageUrl = "https://images.unsplash.com/photo-1607958996333-41aef7caefaa?q=80&w=300",
                    Category = "Tatlı",
                    IsActive = true
                },
                new Product
                {
                    Id = 13,
                    Name = "Elmalı Tart",
                    Description = "Karamelize elma dolgusu ve tereyağlı çıtır hamuruyla servis edilen dilim tart.",
                    Price = 90.00m,
                    ImageUrl = "https://images.unsplash.com/photo-1508737027454-e6454ef45afd?q=80&w=300",
                    Category = "Tatlı",
                    IsActive = true
                }
            );
        }
    }
}
