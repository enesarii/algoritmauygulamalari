using System;
using System.Collections.Generic;
using System.ComponentModel.Design;

namespace yemekhanesunumu
{
     class Program
    {
        static void Main(string[] args)
        {
            // öğrenci ve yemek class'ını kullanarak liste oluşturuyorum.
            List<Ogrenci> ogrenciler = new List<Ogrenci>();
            List<Yemek> yemekler = new List<Yemek>
            {
                new Yemek { Ad = "Çorba", Stok = 0 }, 
                new Yemek { Ad = "Tavuk", Stok = 0 },
                new Yemek { Ad = "Pilav", Stok = 0 }
            };

            Console.Write("Şuan okulda bulunan öğrenci sayısını giriniz: "); // öğrenci verisini kullanıcıdan istiyorum
            int ogrenciSayisi = Convert.ToInt16(Console.ReadLine());  // string veriyi int'e çeviriyorum.
            stokGuncelle(yemekler, ogrenciSayisi); //Stoğu güncellemesi için metodumu çağırıyorum.

            Console.WriteLine("--------------------------------");
            Console.WriteLine("|       - BİLGİLENDİRME -      |");
            Console.WriteLine("| Yemek Ücreti 25 TL'dir.      |");
            Console.WriteLine("| Her kişi bir yemek seçebilir. |");
            Console.WriteLine("--------------------------------");

            while (true) // Seçenekler arasında döngü başlatıyorum.
            {
                Console.WriteLine("      Yemek Takip Sistemi     "); // bilgilendirme yazıları
                Console.WriteLine("------------------------------");
                Console.WriteLine("1. Öğrenci Ekle");
                Console.WriteLine("2. Öğrenci Kartına Para Yükle");
                Console.WriteLine("3. Yemek Seç");
                Console.WriteLine("4. Stok Durumunu Görüntüle");
                Console.WriteLine("5. Çıkış");
                Console.Write("Seçiminizi yapınız: ");
                string secim = Console.ReadLine();

                switch (secim) // Seçenekler içerisinde işlemler yapmak için 
                {
                    case "1":
                        OgrEkle(ogrenciler);
                        break;
                    case "2":
                        Yukleme(ogrenciler);
                        break;
                    case "3":
                        YemekSec(ogrenciler, yemekler);
                        break;
                    case "4":
                        Stok(yemekler);
                        break;
                    case "5":
                        return; // çıkış yapıp bitiriyorum.
                    default:
                        Console.WriteLine("Geçersiz seçim!");
                        break; // işlemi kırıyorum.
                }
            }
        }

        static void OgrEkle(List<Ogrenci> ogrenciler) // Öğrenci ekleme metodu 
        // Öğrenci daha önce eklenmişse uyarı verir,eklenmemişse ekler.
        {
            Console.Write("Öğrenci Adı: ");
            string ad = Console.ReadLine();

            foreach (var ogrenci in ogrenciler) // öğrenciler listesinde öğrenci üzerinde işlem yapmak için kullanılır.
            {
                if (ogrenci.Ad == ad) // öğrenci'nin daha önceden yazılıp yazılmadığını kontrol ediyorum
                {
                    Console.WriteLine("Bu isimde bir öğrenci zaten mevcut!");
                    return; // seçeneklere geri dönmek için kullanıyorum
                }
            }

            ogrenciler.Add(new Ogrenci { Ad = ad, Bakiye = 0 }); // List'imizden öğrenci çekiyoruz ve başlangıç değeri 0 oluyor
            Console.WriteLine($"{ad} adlı öğrenci eklendi.");
        }

        static void Yukleme(List<Ogrenci> ogrenciler) // bakiye yükleme metodu
        // Öğrenci eğer eklenmişse ve ismi uyumluysa bakiye yükler.
        {
            Console.Write("Öğrenci Adı: ");
            string ad = Console.ReadLine();

            foreach (var ogrenci in ogrenciler) // öğrenciler listesinde öğrenci üzerinde işlem yapmak için kullanılır.
            {
                if (ogrenci.Ad == ad)
                {
                    Console.Write("Yüklenecek Tutar: ");
                    decimal tutar = decimal.Parse(Console.ReadLine());

                    ogrenci.Bakiye += tutar;
                    Console.WriteLine($"{ogrenci.Ad} adlı öğrencinin yeni bakiyesi: {ogrenci.Bakiye} TL");
                    return;
                }
            }

            Console.WriteLine("Öğrenci bulunamadı!");
        }

        static void YemekSec(List<Ogrenci> ogrenciler, List<Yemek> yemekler)
        // Öğrencinin yemek seçimini , stok ve bakiye kontrolünü yapar. 
        {
            Console.Write("Öğrenci Adı: ");
            string ad = Console.ReadLine();

            foreach (var ogrenci in ogrenciler) // öğrenciler listesinde öğrenci üzerinde işlem yapmak için kullanılır.
            {
                if (ogrenci.Ad == ad)
                {
                    Console.WriteLine("Mevcut Yemekler:");
                    foreach (var yemek in yemekler) // yemekler listesinde yemek üzerinde işlem yapmak için kullanılır.
                    {
                        Console.WriteLine($"{yemek.Ad} (Stok: {yemek.Stok})");
                    }

                    Console.Write("Seçilecek Yemek Adı: ");
                    string yemekAdi = Console.ReadLine();

                    foreach (var yemek in yemekler) // yemekler listesinde yemek üzerinde işlem yapmak için kullanılır.
                    {
                        if (yemek.Ad == yemekAdi)
                        {
                            if (yemek.Stok > 0) //yemek stoğu varsa alttaki koşula devam eder
                            {
                                if (ogrenci.Bakiye >= 25) // bakiye yeterliyse 
                                {
                                    yemek.Stok--; //yemeğin stoğunu 1 düşürür
                                    ogrenci.Bakiye -= 25; // bakiyenizi 25 tl düşürür
                                    Console.WriteLine($"{yemek.Ad} seçildi. Kalan bakiye: {ogrenci.Bakiye} TL"); 
                                }
                                else // bakiye yeterli değilse 
                                {
                                    Console.WriteLine("Yeterli bakiye yok!");
                                }
                            }
                            else //yemek stoğu yoksa
                            {
                                Console.WriteLine("Seçilen yemek stokta yok!");
                            }
                            return; // menüye geri döner
                        }
                    }

                    Console.WriteLine("Yemek bulunamadı! Tekrar deneyebilirsiniz."); // yukarıdakı koşulların hiçbiri sağlanmazsa yanlış seçim yapıldığı belirtilir.
                    return; // menüye döner 
                }
            }

            Console.WriteLine("Öğrenci bulunamadı!");
        }

        static void Stok(List<Yemek> yemekler) // Kullanıldığında stok durumunu yazdırması için metod.
        {
            Console.WriteLine("Yemek Stok Durumu:");
            foreach (var yemek in yemekler) // yemekler listesinde yemek üzerinde işlem yapmak için kullanılır.
            {
                Console.WriteLine($"{yemek.Ad}: {yemek.Stok} adet"); 
            }
        }

        static void stokGuncelle(List<Yemek> yemekler, int ogrenciSayisi) // stoğumuzu güncelleme metodu
        // Yemek stoklarını sayıya göre günceller.
        {
            foreach (var yemek in yemekler) 
            {
                yemek.Stok = ogrenciSayisi * 1; //yemek stoğunu öğrenci sayısıyla aynı tutar.
            }

            Console.WriteLine("Yemek stokları öğrenci sayısına göre güncellendi.");
        }
    }
}
