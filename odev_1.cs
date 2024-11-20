internal class Program
{
    private static void Main(string[] args)
    {
        Console.Write("Bir sayı girin: ");
        int a, b;
        b = Convert.ToInt32(Console.ReadLine());
        int toplam = 0;
        for (a = 1; a <= b; a++)
        {
            toplam += a;
        }
        Console.WriteLine(" Girdiğiniz sayıya kadar olan tüm sayıların toplamı : {1}", b, toplam);
    }
}