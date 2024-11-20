internal class Program
{
    private static void Main(string[] args)
    {
        Console.Write("Bir sayı girin: "); //kullanıcıdan veri alma
        int a, b;
        b = Convert.ToInt32(Console.ReadLine()); //aldığın string veriyi int'e dönüştürme
        int toplam = 0; // değişkeni sıfır olarak başlatmak için
        for (a = 1; a <= b; a++) //1den b ye olan sayılarla döngü başlatmak için
        {
            toplam += a; //a değerini toplam'a eklemek için 
        }
        Console.WriteLine(" Girdiğiniz sayıya kadar olan tüm sayıların toplamı : {1}", b, toplam); //sonucu ekrana yazdırmak için
    }
}
