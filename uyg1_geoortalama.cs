internal class Program
{
    private static void Main(string[] args)
    {
        // Kullanıcıdan bilgi al
        Console.WriteLine("Birinci sayıyı girin:");
        double sayi1 = Convert.ToDouble(Console.ReadLine()); // küsürat olabilir o yüzden double kullanıyoruz
        Console.WriteLine("İkinci sayıyı girin:");
        double sayi2 = Convert.ToDouble(Console.ReadLine());
        
        double geometrikOrtalama = Math.Sqrt(sayi1 * sayi2); // Geometrik ortalamayı hesaplatıyoruz

        Console.WriteLine("Geometrik Ortalama: " + geometrikOrtalama);// Sonucu ekrana yazdır
    }