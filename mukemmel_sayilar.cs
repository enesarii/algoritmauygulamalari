internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Bir sayı giriniz");
        int sayi, i, bolentoplam;
        bolentoplam = 0;
        sayi = Convert.ToInt16(Console.ReadLine());
        for (i = 1; i < sayi; i++)
        {
            if (sayi % i == 0)
            {
                bolentoplam += i;
            }
        }
        if (bolentoplam == sayi)
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
