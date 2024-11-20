internal class Program
{
    private static void Main(string[] args)
    {
        Console.Write("Bir sayı girin: "); //kullanıcıdan veri istenir
        int sayi;
        sayi = Convert.ToInt32(Console.ReadLine()); //istenen veri sayi değişkenine atanır
        int basamakSayisi = sayi.ToString().Length; // Basamak sayısını bulmak için sayıyı string dönüştürüyoruz ve uzunluğunu alıyoruz
        int girilensayi = sayi; // sayıyı basamağı sonradan ayarlamak için geçici bir değişkene atıyoruz
        int toplam = 0; // toplamı sıfırlıyoruz
        while (girilensayi > 0) //sayı sıfır olana kadar her basamağa işlem yapılır
        {
            int basamak = girilensayi % 10; //sayının son basamağını almak için
            toplam += (int)Math.Pow(basamak, basamakSayisi);// basamağın basamak sayısı kadar üssünü alıyoruz ve toplamla topluyoruz
            girilensayi /= 10;//sayının son basamağını çıkarıyoruz
        }
        if (toplam == sayi) //eğer toplam ilk sayıya eşitse bu sayı armstrong sayısıdır.
        {
            Console.WriteLine("Girdiğinz sayı Armstrong sayısıdır.");
        }
        else
            Console.WriteLine("Girdiğiniz sayı bir Armstrong sayısı değildir.");
    }
}
    
