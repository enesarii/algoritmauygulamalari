using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace enesarimetot
{
    internal class Program
    {
        static void Main(string [enesarimetot] args)
        {
            //öğrenci  bilgisi al 
            Console.Write("ögrenci isim soyisim: ");
            string adSoyad = Console.ReadLine();

            //1. sınav not bilgisi al 
            Console.Write("1. sınav notu: ");
            int not1 = Convert.ToInt32(Console.ReadLine());
            //2. sınav not bilgisi al 
            Console.Write("2. sınav notu: ");
            int not2 = Convert.ToInt32(Console.ReadLine());
            //ortalamayı hesapla
            int ortalama = (not1 + not2) / 2;

            //öğrenci bilgisiyle birlikte ortalamayı göster
            Console.WriteLine($"{adSoyad} için not ortalaması: {ortalama}");
        }
    }
}