🌱 ThePrototype - Farming System
Bu proje, Unity kullanılarak geliştirilen modüler bir tarım simülasyonu sistemidir. Oyuncular belirli alanlara ekin ekebilir, ekinlerin büyümesini takip edebilir ve olgunlaşan mahsulleri hasat edebilir.

Sistem event-driven (olay tabanlı) bir mimariye sahiptir ve modüler bir şekilde genişletilebilir.

📌 Özellikler
✅ Ekim Sistemi

Oyuncular belirli ekim alanlarına (grid tabanlı) mahsul ekebilir.
Kullanıcı dostu bir arayüz ile ekin seçimi yapılabilir.
✅ Büyüme Mekaniği

Her ekin belirli büyüme aşamalarından geçer.
Ekinlerin büyüme süresi, ScriptableObject (CropSO) ile özelleştirilebilir.
EventBus kullanılarak ekin ekildiğinde otomatik olarak büyüme süreci başlatılır.
✅ Hasat Sistemi

Büyüme tamamlandığında, ekinler hasat edilebilir hale gelir.
Hasat edilebilecek ekinler, özel bir UI ile kullanıcıya gösterilir.
Sürükleme (drag & drop) mekaniği ile hasat edilen ürünler toplanır.
✅ Dokunmatik & Mobil Uyumluluk

Mobil cihazlarda dokunmatik kontroller desteklenir.
Uzun basma (long press) mekanizması ile özel işlemler gerçekleştirilebilir.
✅ Event-Driven Mimari

EventBus yapısı kullanılarak oyun içi olaylar arasında bağlantı sağlanır.
Modüler ve genişletilebilir bir yapı sunar.
✅ Performans Optimizasyonu

Object Pooling ve event tabanlı sistemler kullanılarak gereksiz hesaplamalar minimize edilmiştir.
Minimal UI update cycle kullanılarak UI performansı optimize edilmiştir.
⚙️ Kullanılan Teknolojiler & Sistem Mimarisi
🛠️ Teknolojiler
Unity Engine (Ana oyun motoru - Unity 2021.3+)
C# (Oyun mekaniği ve sistemler için ana dil)
Scriptable Objects (SO) (Veri yönetimi ve konfigürasyon için)
EventBus Yapısı (Oyun içi event yönetimi için)
Singleton Design Pattern (Global yöneticiler için Persistent Singleton kullanımı)
Physics Raycasting (UI ve dünya içi nesne etkileşimleri için)
🚀 Kurulum ve Kullanım
1️⃣ Projeyi Klonlayın
sh
Kopyala
Düzenle
git clone https://github.com/username/ThePrototype.git
2️⃣ Unity ile Açın
📌 Desteklenen Unity Versiyonu: Unity 2021.3+

3️⃣ Oyun Sahnesini Çalıştırın
Unity içinde sahneyi açarak Play tuşuna basın.

4️⃣ Temel Oyun Mekaniklerini Test Edin
Ekim: Bir ekin seçin ve haritaya yerleştirin.
Büyüme: Büyüme aşamalarını takip edin.
Hasat: Büyüyen mahsulleri toplayın.
🏗️ Kod Yapısı & Önemli Scriptler
📌 GrowthManager.cs

Ekinlerin büyüme sürecini yönetir.
Büyüme sürecinin tamamlanıp tamamlanmadığını kontrol eder.
📌 CropUIManager.cs

Kullanıcı arayüzü üzerinden ekin ekme ve hasat işlemlerini düzenler.
UI butonlarını oluşturur ve yönetir.
📌 HarvestEntityManager.cs

Hasat edilen ürünlerin sürükleme (drag & drop) mekanizmasını yönetir.
Ürünlerin toplanmasını ve envantere eklenmesini sağlar.
📌 EventBus.cs

Event-driven mimariyi desteklemek için kullanılır.
Sistemler arası iletişimi sağlar ve bileşenler arası bağımlılığı azaltır.
📌 CropSO.cs (Scriptable Object)

Ekinlerin verilerini saklar.
Büyüme süresi, görünüm ve hasat edilebilirlik durumu gibi bilgileri içerir.
📌 PlacementManager.cs

Ekinlerin nereye ekilebileceğini yönetir.
Raycast kullanarak uygun alanları tespit eder.
📌 IndicatorManager.cs

Kullanıcının seçtiği ekini gösterir.
UI üzerindeki butonlar ile etkileşimi yönetir.
🎯 Sistem Akışı
1️⃣ Ekin Seçme → Kullanıcı, ekilecek mahsulü seçer.
2️⃣ Ekim → Seçilen mahsul belirlenen alana ekilir.
3️⃣ Büyüme Süreci → GrowthManager tarafından büyüme aşamaları tamamlanır.
4️⃣ Hasat Edilebilir Duruma Gelme → Son aşamaya gelen mahsul toplanabilir.
5️⃣ Hasat İşlemi → HarvestEntityManager sürükleyerek mahsulü toplama işlemini yönetir.

💡 Geliştirme Süreci & İyileştirme Fikirleri
📌 Eklenecek Özellikler:

🌾 Farklı ekin türleri ve yetişme süreleri
📦 Envanter sistemi (Hasat edilen ürünlerin depolanması)
🏠 Çiftlik yönetimi (Oyuncunun birden fazla tarla alanı kontrol etmesi)
🌦️ Hava durumu etkileri (Yağmur, kuraklık vb. durumların mahsul büyümesine etkisi)
🔔 Bildirim Sistemi (Büyüme tamamlandığında kullanıcıya bildirim gönderme)
🤝 Katkıda Bulunma
Bu proje açık kaynaklıdır! Eğer katkıda bulunmak istersen:
📌 Bir Issue açarak öneri veya hata bildirebilirsin.
📌 Yeni özellikler eklemek için bir Pull Request gönderebilirsin.

📝 Lisans: MIT License

👨‍💻 Geliştirici: Burak Torun

🚀 İyi oyunlar! 🎮🌾