
internal class Program
{
    private static void Main(string[] args)
    {

        List<string> ogrenciliste = new List<string>();
        int ogrencisayi = 0;
        Console.WriteLine("Öğrenci eklemek için 1'i eklememek için 2'yi seçin");

        while (true)
        {
            int karar = 0;

            karar = Convert.ToInt32(Console.ReadLine());

            if (karar == 1)
            {
                Console.WriteLine("Geziye katılacakların ismini giriniz ");
                ogrenciliste.Add(Console.ReadLine());
                ogrencisayi++;
                Console.WriteLine("Devam 1 - Hayır 2 ");
            }
            else if (karar == 2)
            {
                Console.WriteLine("Ekleme işlemi bitti.Toplam eklenen kişi sayısı " + ogrencisayi);
                break;

            }
            else
            {
                Console.WriteLine("Tekrar deneyin");
            }
        }
    }
}
