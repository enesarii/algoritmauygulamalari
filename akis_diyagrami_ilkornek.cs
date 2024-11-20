using System;

class Program
{
    static void Main()
    {
//Veri istiyor ve alıyoruz
        Console.Write("a değerini girin: ");
        int a = Convert.ToInt32(Console.ReadLine()); //alınan string verileri int'e dönüştürüyoruz

        Console.Write("b değerini girin: ");
        int b = Convert.ToInt32(Console.ReadLine());//alınan string verileri int'e dönüştürüyoruz

        Console.Write("c değerini girin: ");
        int c = Convert.ToInt32(Console.ReadLine());//alınan string verileri int'e dönüştürüyoruz

//alınan verileri topluyoruz
        int toplam = a + b + c;


        if (toplam < 180) //toplam 180'den küçükse üçgendir
        {
            Console.WriteLine("Üçgen");
        }
        else if (toplam > 180) //toplam 180den büyükse üçgen değildir
        {
            Console.WriteLine("Üçgen değil"); //toplam 180'den küçükse üçgendir
        }
        else
        {
            Console.WriteLine("Üçgen");
        }


        Console.WriteLine("Program sonlandı."); //Bitirdiğimi belirtmek için
    }
}
