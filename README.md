# Cafe & Restoran YÃ¶netim Sistemi

Bu proje, bir kafe veya restoranÄ±n menÃ¼, sipariÅŸ ve masa yÃ¶netim sÃ¼reÃ§lerini dijitalleÅŸtirmek amacÄ±yla geliÅŸtirilmiÅŸ modern bir web uygulamasÄ±dÄ±r.

## ğŸš€ KullanÄ±lan Teknolojiler
* **Framework:** ASP.NET Core Razor Pages (.NET 8/9)
* **Veri TabanÄ± / ORM:** Entity Framework Core (Code-First YaklaÅŸÄ±mÄ±) & SQL Server
* **TasarÄ±m:** HTML, CSS, JavaScript, Bootstrap

## âœ¨ Ã–zellikler / YapÄ±
* `Pages/`: UygulamanÄ±n sayfa odaklÄ± arayÃ¼z kodlarÄ± ve iÅŸ mantÄ±ÄŸÄ± (PageModel).
* `Models/`: VeritabanÄ± tablolarÄ±na karÅŸÄ±lÄ±k gelen veri modelleri.
* `Data/`: DbContext ve veritabanÄ± baÄŸlantÄ± yapÄ±landÄ±rmalarÄ±.
* `Migrations/`: VeritabanÄ± ÅŸemasÄ±nÄ±n versiyon kontrol dosyalarÄ±.

## ğŸ› ï¸ NasÄ±l Ã‡alÄ±ÅŸtÄ±rÄ±lÄ±r?
1. `appsettings.json` dosyasÄ±ndaki baÄŸlantÄ± dizesini (Connection String) kendi yerel SQL Server ayarlarÄ±nÄ±za gÃ¶re gÃ¼ncelleyin.
2. Package Manager Console Ã¼zerinde `Update-Database` komutunu Ã§alÄ±ÅŸtÄ±rarak veritabanÄ± ÅŸemasÄ±nÄ± oluÅŸturun.
3. Projeyi Visual Studio 2022 veya `dotnet run` komutu ile ayaÄŸa kaldÄ±rÄ±n.