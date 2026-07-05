# Cafe & Restoran Yönetim Sistemi

Bu proje, bir kafe veya restoranın menü, sipariş ve masa yönetim süreçlerini dijitalleştirmek amacıyla geliştirilmiş modern bir web uygulamasıdır.

## 🚀 Kullanılan Teknolojiler
* **Framework:** ASP.NET Core Razor Pages (.NET 8/9)
* **Veri Tabanı / ORM:** Entity Framework Core (Code-First Yaklaşımı) & SQL Server
* **Tasarım:** HTML, CSS, JavaScript, Bootstrap

## ✨ Özellikler / Yapı
* `Pages/`: Uygulamanın sayfa odaklı arayüz kodları ve iş mantığı (PageModel).
* `Models/`: Veritabanı tablolarına karşılık gelen veri modelleri.
* `Data/`: DbContext ve veritabanı bağlantı yapılandırmaları.
* `Migrations/`: Veritabanı şemasının versiyon kontrol dosyaları.

## 🛠️ Nasıl Çalıştırılır?
1. `appsettings.json` dosyasındaki bağlantı dizesini (Connection String) kendi yerel SQL Server ayarlarınıza göre güncelleyin.
2. Package Manager Console üzerinde `Update-Database` komutunu çalıştırarak veritabanı şemasını oluşturun.
3. Projeyi Visual Studio 2022 veya `dotnet run` komutu ile ayağa kaldırın.
