# Kantin Satış Otomasyonu

C# Windows Forms ile geliştirilmiş, yerel metin dosyaları üzerinden çalışan pratik bir satış otomasyonu uygulaması.

## Özellikler
* **Dinamik Ürün Yükleme:** `urunler.txt` dosyasından ürün bilgilerini (ID, Ad, Fiyat) okuyarak arayüze otomatik yükler.
* **Sepet İşlemleri:** Seçilen ürünleri ve belirtilen adetleri hesaplayarak dinamik olarak sepet tablosunda (DataGridView) gösterir.
* **Toplam Tutar Hesaplama:** Sepete eklenen tüm ürünlerin anlık toplam maliyetini hesaplar.
* **Satış Kaydı Loglama:** Tamamlanan satış işlemlerini tarih ve saat damgasıyla birlikte `satislar.txt` dosyasına kalıcı olarak kaydeder.

## Kullanılan Teknolojiler
* C#
* .NET Framework (Windows Forms)
* Dosya Okuma/Yazma Sınıfları (StreamReader & StreamWriter)

## Kurulum ve Kullanım
1. Projeyi klonlayın veya masaüstünüze indirin.
2. `Gorsel_Programlama_01.sln` dosyasını Visual Studio ile açın.
3. Uygulamayı başlatmadan önce derleme (Debug) klasörünün içinde formata uygun bir `urunler.txt` dosyası bulunduğundan emin olun.
   * *Örnek urunler.txt satır formatı (ID|Ürün Adı|Fiyat):* `1|Çay|15,50`
4. Projeyi çalıştırın (F5) ve arayüz üzerinden satış işlemlerini gerçekleştirin.
