internal class Program
{
    private static void Main(string[] args)
        {
            int tisort = 40;
            int pantolon = 50;
            int ceket = 60;

            Console.WriteLine("Lütfen satın almak istediğiniz kıyafet türünü seçin:"); // kullanıcıdan seçimler istenir 
            Console.WriteLine("1. Tişört");
            Console.WriteLine("2. Pantolon");
            Console.WriteLine("3. Ceket");

            int secim = Convert.ToInt32(Console.ReadLine()); 

            Console.WriteLine("Kaç tane satın almak istiyorsunuz?");
            int miktar = Convert.ToInt32(Console.ReadLine());

         
            switch (secim) // tişört seçimleri
            {
                case 1: 
                    if (miktar <= tisort)
                    {
                        tisort -= miktar;
                        Console.WriteLine($"Başarıyla {miktar} Tişört satın aldınız.");
                        Console.WriteLine($"Kalan Tişört stoğu: {tisort}");
                    }
                    else
                    {
                        Console.WriteLine("Yetersiz stok! Tişört stoğu: " + tisort);
                    }
                    break;

                case 2:  //pantolon seçimleri 
                    if (miktar <= pantolon)
                    {
                        pantolon -= miktar;
                        Console.WriteLine($"Başarıyla {miktar} Pantolon satın aldınız.");
                        Console.WriteLine($"Kalan Pantolon stoğu: {pantolon}");
                    }
                    else
                    {
                        Console.WriteLine("Yetersiz stok! Pantolon stoğu: " + pantolon);
                    }
                    break;

                case 3: //ceket seçimleri
                    if (miktar <= ceket)
                    {
                        ceket -= miktar;
                        Console.WriteLine($"Başarıyla {miktar} Ceket satın aldınız.");
                        Console.WriteLine($"Kalan Ceket stoğu: {ceket}");
                    }
                    else
                    {
                        Console.WriteLine("Yetersiz stok! Ceket stoğu: " + ceket);
                    }
                    break;

                default:
                    Console.WriteLine("Geçersiz seçim yaptınız,lütfen 1,2 veya 3'ü seçin.");
                    break;
            }
        }
    }


   

