internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Bir sayı giriniz");
        int sayi, i, bolentoplam; 
        bolentoplam = 0; //bölenlerin toplamını başlatmak için 
        sayi = Convert.ToInt16(Console.ReadLine()); // Kullanıcıdan sayıyı alıyoruz
        for (i = 1; i < sayi; i++)         // 1'den sayi - 1'e kadar olan sayılarla döngü yapıp bölenleri buluyoruz
        {
            if (sayi % i == 0)// Eğer 'i' sayısının böleni ise
            {
                bolentoplam += i; // toplama ekliyoruz
            }
        }
        if (bolentoplam == sayi) // Eğer bölenlerin toplamı sayıya eşitse, sayı mükemmel bir sayıdır
        {
            Console.WriteLine("Bu sayı mükemmel bir sayıdır.");
        }
        else
        {
            Console.WriteLine("Bu sayı mükemmel sayı değildir.");
        }
        Console.ReadLine();
    }
}
