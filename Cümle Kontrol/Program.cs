using System;

namespace CumleProgramı
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                baslangic:

                while (1 == 1)
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    int sayac = 0;
                    string cumle;
                    char ArananHarf;
                    SesliHarf Sharf = new SesliHarf();
                    SessizHarf SSharf = new SessizHarf();

                    //CÜMLEYİ GİRME
                    Console.Write("Cümle Girin : ");
                    cumle = Console.ReadLine();

                    //YAZILAN CÜMLENİN İÇİNDE TÜRKÇE KARAKTER KONTOLÜ YAPIYORUM
                    int index = cumle.IndexOfAny(new char[] { 'ç', 'ı', 'ü', 'ğ', 'ö', 'ş', 'İ', 'Ğ', 'Ü', 'Ö', 'Ş', 'Ç' });
                    if (index > -1)
                    {
                        Console.Clear();
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine("Türkçe Karakter Girdiğiniz İçin");
                        Console.WriteLine("\nProgramı Yeniden Başlatmak İçin  ENTERE Basın ...");
                        if (Console.ReadLine() == "e")
                        {
                            Console.Clear();
                            goto baslangic;
                        }
                    }
                    else
                    {
                        Console.ResetColor();
                        //CÜMLEYİ ARKA PLANDA BÜYÜK HARFE ÇEVİRİYORUM
                        cumle = cumle.ToUpper();

                        //ARADIĞI HARFİ GİRME
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("Aradığınız Harfi Girin : ");
                        ArananHarf = Convert.ToChar(Console.ReadLine().ToUpper());
                        Console.ForegroundColor = ConsoleColor.Blue;
                        //CÜMLE KAÇ KELİMEDEN OLUŞTUĞUNU BULMA
                        string[] kelimeler = cumle.Split(' ');
                        Console.WriteLine("\nGirdiğiniz Cümlede {0} Tane Kelime Bulunmaktadır...", kelimeler.Length);

                        Console.ForegroundColor = ConsoleColor.Green;
                        //ARANAN HARF SAYISINI BULMA
                        int ArananHarfSayisi = cumle.IndexOf(ArananHarf);
                        while (ArananHarfSayisi != -1)
                        {
                            ArananHarfSayisi = cumle.IndexOf(ArananHarf, ArananHarfSayisi + 1);

                            sayac++;
                        }
                        Console.WriteLine("\nGirdiğiniz Cümlede {0} Tane {1} Harfi Bulunmaktadır...", sayac, ArananHarf);

                        Console.ForegroundColor = ConsoleColor.Yellow;
                        //SESLİ HARF SAYISI
                        int SesliHarfSayisi = Sharf.SesliHarfler(cumle);
                        Console.WriteLine("\nGirdiğiniz Cümlede {0} Tane Sesli Harf Bulunmaktadır...", SesliHarfSayisi);

                        Console.ForegroundColor = ConsoleColor.Cyan;
                        //SESSİZ HARF SAYISI
                        int SessizHarfSayisi = SSharf.SessizHarfler(cumle);
                        Console.WriteLine("\nGirdiğiniz Cümlede {0} Tane Sessiz Harf Bulunmaktadır...", SessizHarfSayisi);

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nProgramı Yeniden Başlatmak İçin e Harfini Yazıp ENTERE Basın ...");
                        if (Console.ReadLine() == "e")
                        {
                            Console.Clear();
                        }
                        
                        Console.ReadLine();
                    }
                }
            }
            catch
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("\nProgramda HATALI Tuşlama yaptınız ... ");

                Console.WriteLine("\nProgramı Kapatmak İçin  ENTERE Basın ...");
                if (Console.ReadLine() == "e")
                {
                    Console.Clear();
                }
            }
        }

        //SESLİ HARF BULMA CLASSI VE METODU
        class SesliHarf
        {
            public int SesliHarfler(string gelenYazi)
            {
                char[] harfler = gelenYazi.ToCharArray();
                int SesliHarfSayisi = 0;
                char[] sesli = { 'a', 'e', 'o', 'ö', 'u', 'ü', 'ı', 'i', 'A', 'E', 'O', 'Ö', 'U', 'Ü', 'I', 'İ' };
                for (int i = 0; i < harfler.Length; i++)
                {
                    foreach (char sesliHarfler in sesli)
                    {
                        if (sesliHarfler == harfler[i])
                        {
                            SesliHarfSayisi++;
                        }
                    }
                }
                return SesliHarfSayisi;
            }
        }

        //SESSİZ HARF BULMA CLASSI VE METODU
        class SessizHarf
        {
            public int SessizHarfler(string gelenYazi)
            {
                char[] harfler = gelenYazi.ToCharArray();
                int SessizHarfSayisi = 0;
                char[] sessiz = { 'b', 'c', 'ç', 'd', 'f', 'g', 'ğ', 'h', 'j', 'k', 'l', 'm', 'n', 'p', 'r', 's', 'ş', 't', 'y', 'z', 'B', 'C', 'Ç', 'D', 'F', 'G', 'Ğ', 'H', 'J', 'K', 'L', 'M', 'N', 'P', 'R', 'S', 'Ş', 'T', 'Y', 'Z' };
                for (int i = 0; i < harfler.Length; i++)
                {
                    foreach (char sessizHarfler in sessiz)
                    {
                        if (sessizHarfler == harfler[i])
                        {
                            SessizHarfSayisi++;
                        }
                    }
                }
                return SessizHarfSayisi;
            }
        }
    }
}
