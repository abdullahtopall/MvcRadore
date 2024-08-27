# MvcRadore

Bu proje, ASP.NET MVC kullanılarak bir blog sitesi oluşturmayı amaçlamaktadır. Proje, Radore Hosting tarafından düzenlenen ASP.NET MVC Bootcamp eğitimi kapsamında geliştirilmiştir.

## Proje Yapısı

Proje, aşağıdaki katmanlardan oluşmaktadır:

- **MvcRadore:** ASP.NET MVC web uygulaması
- **MvcRadore.Business:** İş mantığı katmanı
- **MvcRadore.DataAccess:** Veri erişim katmanı
- **MvcRadore.Entities:** Veritabanı nesneleri

## Kullanılan Teknolojiler

Proje, aşağıdaki teknolojileri kullanmaktadır:

- ASP.NET MVC 5
- Entity Framework 6
- Microsoft SQL Server
- Bootstrap 3

## Kurulum

Proje dosyalarını indirdikten sonra, aşağıdaki adımları takip ederek projeyi çalıştırabilirsiniz:

1. `Web.config` dosyasındaki `connectionString` ayarını kendi veritabanı bağlantı dizesinize göre güncelleyin.
2. Visual Studio'da `MvcRadore` projesini açın.
3. Package Manager Console'u açın ve `Update-Database` komutunu çalıştırın. Bu, veritabanı tablolarını oluşturacaktır.
4. Projeyi çalıştırın.

## Lisans

Bu proje MIT lisansı ile lisanslanmıştır. Daha fazla bilgi için `LICENSE` dosyasına bakabilirsiniz.
