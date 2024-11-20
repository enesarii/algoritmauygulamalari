using System;

class Ogrenci
{
    public string Ad { get; set; }
    public string[] Dersler { get; set; } /// öğrencinin adı,aldığı dersleri ve ders sayısı
    public int DersSayisi { get; set; }
}

class Ogretmen
{
    public string Ad { get; set; }
    public string[] VerdigiDersler { get; set; } /// öğretmenin adı,verdiği dersler ve girdiği ders sayısı
    public int DersSayisi { get; set; }
}

class Sinif
{
    public string SinifAdi { get; set; } /// sınıfın adı,dersleri ve ders sayısı
    public string[] Dersler { get; set; }
    public int DersSayisi { get; set; }
}

class Program
{
    static void OgrenciDersProgrami(Ogrenci ogr)     // Öğrenci ders programını ekrana yazdırma metodu

    {
        Console.WriteLine($"\nÖğrenci {ogr.Ad}'nin ders programı ({ogr.DersSayisi} ders):");   // Öğrencinin adı ve aldığı ders sayısı 
        string[] gunler = { "Pazartesi", "Salı", "Cuma" };         // Haftanın günleri
        for (int i = 0; i < ogr.DersSayisi; i++)  // Öğrencinin aldığı dersler günlere göre yazılması için

        {
            Console.WriteLine($"- {gunler[i]}: {ogr.Dersler[i]}");
        }
    }

    static void OgretmenDersProgrami(Ogretmen ogrt) // Öğretmen ders programını ekrana yazdırma metodu
    {
        Console.WriteLine($"\nÖğretmen {ogrt.Ad}'nin verdiği dersler ({ogrt.DersSayisi} ders):"); // Öğretmenin adı ve verdiği ders sayısı 
        string[] gunler = { "Pazartesi", "Salı", "Cuma" }; // Haftanın günleri
        for (int i = 0; i < ogrt.DersSayisi; i++) // Öğretmenin verdiği dersler günlere göre yazılması için
        {
            Console.WriteLine($"- {gunler[i]}: {ogrt.VerdigiDersler[i]}");
        }
    }

    static void SinifDersProgrami(Sinif sinif)  
    {
        Console.WriteLine($"\n{sinif.SinifAdi} sınıfının ders programı ({sinif.DersSayisi} ders):");// Sınıfın adı ve aldığı ders sayısı ile başlık yazdırılır
        string[] gunler = { "Pazartesi", "Salı", "Cuma" }; // Haftanın günleri
        for (int i = 0; i < sinif.DersSayisi; i++) // Sınıfın aldığı dersler günlere göre yazdırılır

        {
            Console.WriteLine($"- {gunler[i]}: {sinif.Dersler[i]}");
        }
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Hoş geldiniz! Lütfen bir seçim yapınız:"); // Kullanıcıya seçim yaptırmak için
        Console.WriteLine("1. Öğretmen");
        Console.WriteLine("2. Öğrenci");
        Console.WriteLine("3. Sınıf Ders Programı");
        Console.Write("Seçiminiz: ");
        int secim = Convert.ToInt32(Console.ReadLine());
   //öğrenci, öğretmen ve sınıf verileri
        Ogrenci ogrenci = new Ogrenci { Ad = "Enes", Dersler = new string[] { "Algoritma", "Yazılım", "Tasarım" }, DersSayisi = 3 };
        Ogretmen ogretmen = new Ogretmen { Ad = "Arman", VerdigiDersler = new string[] { "Algoritma", "Yazılım", "Tasarım" }, DersSayisi = 3 };
        Sinif sinif = new Sinif { SinifAdi = "Bilgisayar1", Dersler = new string[] { "Algoritma", "Yazılım", "Tasarım" }, DersSayisi = 3 };

        if (secim == 1) // öğretmenin ders programı
        {
            OgretmenDersProgrami(ogretmen);
        }
        else if (secim == 2) //öğrencinin ders programı
        {
            OgrenciDersProgrami(ogrenci);
        }
        else if (secim == 3) //sınıfın ders programı
        {
            SinifDersProgrami(sinif);
        }
        else //yanlış seçim
        {
            Console.WriteLine("Geçersiz seçim!");
        }
    }
}
