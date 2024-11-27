internal class Program
{
    private static void Main(string[] args)
        {
                    string[] urunisim = new string[100];
        decimal[] fiyatlar = new decimal[100];
        int[] adet = new int[100];
        int miktar = 0; // Eklenen ürün sayısı
        decimal kullaniciparasi = 100.00m; // Kullanıcının bakiyesi (örnek olarak 1000 TL

        while (true)
        {
            Console.WriteLine("\n---- Depo Yönetim Sistemi ----");
            Console.WriteLine("1. Ürün Ekle");
            Console.WriteLine("2. Ürün Satış");
            Console.WriteLine("3. Çıkış");

            int menuSecim = Convert.ToInt32(Console.ReadLine()); // Menü seçimi

            switch (menuSecim)
            {
                case 1: // Ürün ekleme
                    Console.WriteLine("\nYeni ürün eklemek veya mevcut ürünün miktarını artırmak için seçenekleri girin:");

                    // Ürünleri listele
                    if (miktar == 0)
                    {
                        Console.WriteLine("Depoda hiçbir ürün bulunmamaktadır.");
                    }
                    else
                    {
                        Console.WriteLine("Mevcut ürünler:");
                        for (int i = 0; i < miktar; i++)
                        {
                            Console.WriteLine($"{i + 1}. {urunisim[i]} - Birim Fiyatı: {fiyatlar[i]} - Mevcut Stok: {adet[i]}");
                        }
                    }

                    Console.WriteLine("Yeni ürün eklemek için 0 girin, mevcut ürünün miktarını artırmak için ürün numarasını girin:");
                    int ekleSecim = Convert.ToInt32(Console.ReadLine());

                    if (ekleSecim == 0) // Yeni ürün ekleme
                    {
                        Console.WriteLine("Yeni ürün adı:");
                        urunisim[miktar] = Console.ReadLine();

                        Console.WriteLine("Birim fiyatı:");
                        fiyatlar[miktar] = Convert.ToDecimal(Console.ReadLine());

                        Console.WriteLine("Adet:");
                        adet[miktar] = Convert.ToInt32(Console.ReadLine());

                        miktar++; // Yeni ürün eklendikçe ürün sayısını artır

                        Console.WriteLine("Yeni ürün başarıyla eklendi.");
                    }
                    else // Var olan ürünün miktarını artırma
                    {
                        if (ekleSecim >= 1 && ekleSecim <= miktar)
                        {
                            int urunIndex = ekleSecim - 1; // Kullanıcıdan alınan seçim sıfır tabanlı olduğu için 1 eksiltildi.
                            Console.WriteLine($"Mevcut {urunisim[urunIndex]} stoğu: {adet[urunIndex]}");
                            Console.WriteLine("Eklemek istediğiniz miktar:");
                            int eklenenMiktar = Convert.ToInt32(Console.ReadLine());
                            adet[urunIndex] += eklenenMiktar; // Mevcut ürüne miktar ekleme

                            Console.WriteLine($"{urunisim[urunIndex]} ürününün yeni stoğu: {adet[urunIndex]}");
                        }
                        else
                        {
                            Console.WriteLine("Geçersiz seçim!");
                        }
                    }
                    break;

                case 2: // Ürün satış işlemi
                    Console.WriteLine("\nLütfen satın almak istediğiniz ürünü seçin:");

                    if (miktar == 0)
                    {
                        Console.WriteLine("Depoda ürün bulunmamaktadır.");
                    }
                    else
                    {
                        // Ürünleri listele
                        for (int i = 0; i < miktar; i++)
                        {
                            Console.WriteLine($"{i + 1}. {urunisim[i]} - Birim Fiyatı: {fiyatlar[i]} - Mevcut Stok: {adet[i]}");
                        }

                        Console.WriteLine("Satın almak istediğiniz ürünü numara ile seçin:");
                        int urunsec = Convert.ToInt32(Console.ReadLine()) - 1; // Kullanıcıdan seçim al

                        if (urunsec >= 0 && urunsec < miktar)
                        {
                            Console.WriteLine("Kaç adet satın almak istiyorsunuz?");
                            int satilanadet = Convert.ToInt32(Console.ReadLine());

                            // Seçilen ürün için stok kontrolü
                            if (satilanadet <= adet[urunsec])
                            {
                                decimal toplamfiyat = satilanadet * fiyatlar[urunsec]; // Satış tutarı

                                if (toplamfiyat <= kullaniciparasi)
                                {
                                    // Satış işlemi
                                    adet[urunsec] -= satilanadet; // Satılan ürünlerden stok düşür
                                    kullaniciparasi -= toplamfiyat; // Kullanıcı bakiyesinden düşüş

                                    Console.WriteLine($"{urunisim[urunsec]} başarıyla satıldı.");
                                    Console.WriteLine($"Toplam Tutar: {toplamfiyat} TL");
                                    Console.WriteLine($"Kalan Stok: {adet[urunsec]}");
                                    Console.WriteLine($"Kalan Bakiyeniz: {kullaniciparasi} TL");
                                }
                                else
                                {
                                    Console.WriteLine("Yetersiz bakiye! Satın almak için yeterli paranız yok.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Yetersiz stok! Mevcut stok: " + adet[urunsec]);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Geçersiz seçim!");
                        }
                    }
                    break;

                case 3: // Çıkış
                    Console.WriteLine("Sistemden çıkılıyor...");
                    return; // Programı sonlandır
                default:
                    Console.WriteLine("Geçersiz seçim yaptınız.");
                    break;
            }
        }
    }
}


   

