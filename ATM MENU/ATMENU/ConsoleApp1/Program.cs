using System.Security.Cryptography;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // anladigim kadariyla ilk tanimlar yapilir
            // 4x4 2d matris
            int[,] m4 = new int[4, 4];
            //ben bottom-up merge sort kullanmaya karar verdim ve ai'dan aldigim yardimla ilk "tarayici"nin ilk baslayacagi yeri belirliyoruz
            int[] line = new int[16];
            int linePos = 0;
            //random
            Random r = new Random();

            //sutun ve satirlari tanimlayip olusturduktan sonra tarayicimizin olusturulanlarin ustunden gecmesini istiyoruz
            for (int sutun = 0; sutun < 4; sutun++)
            {
                for (int satir = 0; satir < 4; satir++)
                {
                    int sayilar = r.Next(24, 85);
                    m4[satir, sutun] = sayilar;
                    line[linePos] = sayilar;
                    linePos++;
                }
            }

            //TUM MERGESORT ISLEMI
            //bunu direk main'e yazdigim icin cagirabilecegim bir metod yok o yuzden bazi seyleri yeniden olusturucaz
            int[] tm = new int[16];
            //her grup her taramada bir oncekinin 2 katı olmali
            for (int grupBoyutu = 1; grupBoyutu < 16; grupBoyutu = grupBoyutu * 2)
            {
                for (int solBaslangic = 0; solBaslangic < 16; solBaslangic = +(2 * grupBoyutu))
                {
                    int orta = solBaslangic + grupBoyutu;
                    int sagBitis = solBaslangic + (2 * grupBoyutu);
                    //16'dan fazla kontrol etmemesi icin (ai ne sacma bir yontem kullanmis baska yolu yok mu bunun)
                    if (orta > 16) orta = 16;
                    if (sagBitis > 16) sagBitis = 16;
                    //pointers (acikcasi bunlar tam olarak ne ise yariyor anlamadim eger ustte tanimladiysak yerlerini)
                    int solIndex = solBaslangic;
                    int sagIndex = sagBitis;
                    int anaIndex = solBaslangic;

                    //simdi karsilastirmaya baslayacagiz
                    while (solIndex < orta && sagIndex < sagBitis)
                    {
                        //verdiginiz yonergeye gore buyukten kucuge siralama istiyoruz o yuzden ilk buyugu buluyoruz
                        if (line[solIndex] >= line[sagIndex])
                        {
                            tm[anaIndex] = line[solIndex];
                            solIndex++;
                        }
                        else
                        {
                            tm[anaIndex] = line[sagIndex];
                            sagIndex++;
                        }
                        anaIndex++;
                    }

                    //eğer sol tarafta kalan unsorted gruplar varsa onları da ekle
                    while(anaIndex < orta)
                    {
                        tm[anaIndex] = line[solIndex];
                        solIndex++;
                        anaIndex++;
                    }

                }

               

                //hersey belirlendigine gore artik bunlari konsola yazdirabiliriz!
                for (int a = 0; a < 4; a++)
                {
                    for (int b = 0; b < 4; b++)
                    {
                        Console.Write(m4[a, b]);
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
