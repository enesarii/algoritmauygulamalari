internal class Program
{
    private static void Main(string[] args)
    {
        string ad, soyad, tel, no;

        // Kullanıcıdan bilgileri almak için 
        Console.Write("Adınızı girin: ");
        ad = Console.ReadLine();

        Console.Write("Soyadınızı girin: ");
        soyad = Console.ReadLine();

        Console.Write("Öğrenci numaranızı girin: ");
        no = Console.ReadLine();

        Console.Write("Cep telefonunuzu girin: ");
        tel = Console.ReadLine();

       
        Console.WriteLine("Kullanıcı Bilgileriniz:");  // Bilgileri yazdırmak için 
        Console.WriteLine("Ad: " + ad);
        Console.WriteLine("Soyad: " + soyad);
        Console.WriteLine("Öğrenci Numarası: " + no);
        Console.WriteLine("Cep Telefonu: " + tel);
    }
}