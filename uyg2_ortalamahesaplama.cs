internal class Program
{
    private static void Main(string[] args)
    {
        // Derslerin notlarını almak için değişkenler
        double ders1, ders2, ders3, ortalama; //ortalama küsüratlı olabilir diye double kullanıyorum

        // Kullanıcıdan 3 dersin notlarını al
        Console.WriteLine("Birinci dersin notunu girin:");
        ders1 = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("İkinci dersin notunu girin:");
        ders2 = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Üçüncü dersin notunu girin:");
        ders3 = Convert.ToDouble(Console.ReadLine());

        // Ortalamayı hesapla
        ortalama = (ders1 + ders2 + ders3) / 3;

        // Ortalamayı ekrana yazdır
        Console.WriteLine("Derslerin ortalaması: " + ortalama);

        // Ortalama 50'den büyükse geçer değilse kalır
        if (ortalama >= 50)
        {
            Console.WriteLine("Geçtiniz.");
        }
        else
        {
            Console.WriteLine("Kaldınız.");
        }

       
        Console.ReadLine();
    }
}