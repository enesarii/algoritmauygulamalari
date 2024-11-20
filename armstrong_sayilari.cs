internal class Program
{
    private static void Main(string[] args)
    {
        Console.Write("Bir sayı girin: ");
        int sayi;
        sayi = Convert.ToInt32(Console.ReadLine());
        int basamakSayisi = sayi.ToString().Length;
        int girilensayi = sayi;
        int toplam = 0;
        while (girilensayi > 0)
        {
            int basamak = girilensayi % 10;
            toplam += (int)Math.Pow(basamak, basamakSayisi);
            girilensayi /= 10;
        }
        if (toplam == sayi)
        {
            Console.WriteLine("Girdiğinz sayı Armstrong sayısıdır.");
        }
        else

            Console.WriteLine("Girdiğiniz sayı bir Armstrong sayısı değildir.");
    }
}
    }
}