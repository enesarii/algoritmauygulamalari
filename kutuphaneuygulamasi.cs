using System;
using System.Collections.Generic;
using System.Linq;

namespace kutuphaneuygulamasi

{
    public class Kitap
    {
        public string Ad { get; set; } // Kitap Adı
        public string Yazar { get; set; } // Yazar Adı
        public int YayınYılı { get; set; } // Yayın Yılı
        public int Stok { get; set; } // Stok

        public Kitap(string ad, string yazar, int yayinYili, int stok)
        {
            Ad = ad;
            Yazar = yazar;
            YayınYılı = yayinYili;
            Stok = stok;
        }
    }

    public class Kullanıcı
    {
        public string Ad { get; set; } // Kullanıcı Adı
        public List<Kiralama> Kiralamalar { get; set; } // Kiralama Bilgileri

        public Kullanıcı(string ad)
        {
            Ad = ad;
            Kiralamalar = new List<Kiralama>();
        }
    }

    public class Kiralama
    {
        public Kullanıcı Kullanıcı { get; set; } // Kullanıcı
        public Kitap Kitap { get; set; } // Kitap
        public int Gün { get; set; } // Kiralama Süresi
        public DateTime İadeTarihi { get; set; } // İade Tarihi

        public Kiralama(Kullanıcı kullanıcı, Kitap kitap, int gün)
        {
            Kullanıcı = kullanıcı;
            Kitap = kitap;
            Gün = gün;
            İadeTarihi = DateTime.Now.AddDays(gün); // Şu anki tarihe göre iade tarihi hesaplanır
        }
    }

    public class Kütüphane
    {
        public List<Kitap> Kitaplar { get; set; } // Kitaplar Listesi
        public List<Kullanıcı> Kullanıcılar { get; set; } // Kullanıcılar Listesi

        public Kütüphane()
        {
            Kitaplar = new List<Kitap>();
            Kullanıcılar = new List<Kullanıcı>();
        }

        public void KitapEkle(string ad, string yazar, int yayinYili, int stok)
        {
            var mevcutKitap = Kitaplar.FirstOrDefault(k => k.Ad == ad && k.Yazar == yazar);
            if (mevcutKitap != null)
            {
                mevcutKitap.Stok += stok; // Kitap mevcutsa, stoğunu artır
            }
            else
            {
                Kitaplar.Add(new Kitap(ad, yazar, yayinYili, stok));
            }
        }

        public void KitapKirala(Kullanıcı kullanıcı, string kitapAdı, int gün, decimal bütçe)
        {
            var kitap = Kitaplar.FirstOrDefault(k => k.Ad == kitapAdı);
            if (kitap == null || kitap.Stok == 0)
            {
                Console.WriteLine("Stokta yeterli kitap yok.");
                return;
            }

            decimal kiraBedeli = gün * 5; // Günlük kira bedeli 5 TL
            if (bütçe < kiraBedeli)
            {
                Console.WriteLine("Bütçeniz yeterli değil.");
                return;
            }

            kitap.Stok--; // Kitap kiralandı, stoktan bir adet düşürülecek

            // Kullanıcıyı listede kontrol et, yoksa ekle
            if (!Kullanıcılar.Contains(kullanıcı))
            {
                Kullanıcılar.Add(kullanıcı);
            }

            Kiralama kiralama = new Kiralama(kullanıcı, kitap, gün);
            kullanıcı.Kiralamalar.Add(kiralama);
            Console.WriteLine($"{kitap.Ad} kitabını {gün} günlüğüne kiraladınız.");
        }

        public void KitapİadeEt(Kullanıcı kullanıcı, string kitapAdı)
        {
            var kiralama = kullanıcı.Kiralamalar.FirstOrDefault(k => k.Kitap.Ad == kitapAdı);
            if (kiralama == null)
            {
                Console.WriteLine("Kiralanmış kitap bulunamadı.");
                return;
            }

            kullanıcı.Kiralamalar.Remove(kiralama);
            kiralama.Kitap.Stok++; // Kitap iade ediliyor, stok artırılıyor
            Console.WriteLine($"{kitapAdı} kitabı iade alındı.");
        }

        public void KitapAra(string aramaterimi)
        {
            var sonuç = Kitaplar.Where(k => k.Ad.Contains(aramaterimi, StringComparison.OrdinalIgnoreCase) ||
                                             k.Yazar.Contains(aramaterimi, StringComparison.OrdinalIgnoreCase)).ToList();

            foreach (var kitap in sonuç)
            {
                Console.WriteLine($"{kitap.Ad} - {kitap.Yazar} - {kitap.YayınYılı} - Stok: {kitap.Stok}");
            }
        }

        public void KitapRaporla()
        {
            Console.WriteLine("Tüm kitaplar:");
            foreach (var kitap in Kitaplar)
            {
                Console.WriteLine($"{kitap.Ad} - {kitap.Yazar} - {kitap.YayınYılı} - Stok: {kitap.Stok}");
            }
        }

        public void KiradaOlanKitaplarıRaporla()
        {
            Console.WriteLine("Kirada olan kitaplar:");
            foreach (var kullanıcı in Kullanıcılar)
            {
                foreach (var kiralama in kullanıcı.Kiralamalar)
                {
                    Console.WriteLine($"{kiralama.Kitap.Ad} - Kiralayan: {kullanıcı.Ad} - İade Tarihi: {kiralama.İadeTarihi.ToShortDateString()}");
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Kütüphane kütüphane = new Kütüphane();

            // Kullanıcıdan isim al
            Console.Write("Kullanıcı adını girin: ");
            string kullanıcıAdı = Console.ReadLine(); // Kullanıcı adı alınıyor

            // Kullanıcıyı oluştur
            Kullanıcı kullanıcı = new Kullanıcı(kullanıcıAdı);

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Kütüphane Sistemi");
                Console.WriteLine("1. Kitap Ekle");
                Console.WriteLine("2. Kitap Kirala");
                Console.WriteLine("3. Kitap İade Et");
                Console.WriteLine("4. Kitap Ara");
                Console.WriteLine("5. Kitap Raporla");
                Console.WriteLine("6. Kirada Olan Kitaplar");
                Console.WriteLine("7. Çık");
                Console.Write("Seçiminizi yapın: ");
                int seçim = int.Parse(Console.ReadLine());

                switch (seçim)
                {
                    case 1:
                        Console.Write("Kitap adı: ");
                        string ad = Console.ReadLine();
                        Console.Write("Yazar adı: ");
                        string yazar = Console.ReadLine();
                        Console.Write("Yayın yılı: ");
                        int yıl = int.Parse(Console.ReadLine());
                        Console.Write("Stok miktarı: ");
                        int stok = int.Parse(Console.ReadLine());
                        kütüphane.KitapEkle(ad, yazar, yıl, stok);
                        break;
                    case 2:
                        Console.Write("Kiralamak istediğiniz kitabın adı: ");
                        string kitapisim = Console.ReadLine();
                        Console.Write("Kaç gün kiralamak istersiniz?: ");
                        int gün = int.Parse(Console.ReadLine());
                        Console.Write("Bütçeniz: ");
                        decimal bütçe = decimal.Parse(Console.ReadLine());
                        kütüphane.KitapKirala(kullanıcı, kitapisim, gün, bütçe);
                        break;
                    case 3:
                        Console.Write("İade etmek istediğiniz kitabın adı: ");
                        string iadeedilenkitapadı = Console.ReadLine();
                        kütüphane.KitapİadeEt(kullanıcı, iadeedilenkitapadı);
                        break;
                    case 4:
                        Console.Write("Kitap adı veya yazar adı ile arama yapın: ");
                        string aramaterimi = Console.ReadLine();
                        kütüphane.KitapAra(aramaterimi);
                        break;
                    case 5:
                        kütüphane.KitapRaporla();
                        break;
                    case 6:
                        kütüphane.KiradaOlanKitaplarıRaporla();
                        break;
                    case 7:
                        return;
                    default:
                        Console.WriteLine("Geçersiz seçenek!");
                        break;
                }
                Console.WriteLine("\nDevam etmek için bir tuşa basın...");
                Console.ReadKey();
            }
        }
    }
}
