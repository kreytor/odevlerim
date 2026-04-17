using System.Security.Cryptography;
using System.Security.Permissions;

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

                    while (sagIndex < orta) 
                    { 
                        tm[anaIndex] = line[sagIndex];
                        sagIndex++;
                        anaIndex++;
                    }

                    for (int i = solBaslangic; i < sagBitis; i++)
                    {
                        line[i] = tm[i];
                    }



                    //hersey belirlendigine gore artik bunlari konsola yazdirabiliriz!
                    int[,] box2x4 = new int[2, 4];
                    linePos = 0;
                    Console.WriteLine("Siralama: ");
                    for (int sutun = 0; sutun < 4; sutun++)
                    {
                        for (int satir = 0; satir < 2; satir++)
                        {
                            box2x4[satir,sutun] = line[linePos];                            Console.Write( + " ");
                            linePos++;
                            Console.Write(box2x4[satir, sutun] + "\t");
                        }
                        Console.WriteLine();
                    }
                }
        }
    }
}}
