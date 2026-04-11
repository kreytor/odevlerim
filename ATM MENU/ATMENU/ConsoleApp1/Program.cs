using System.Security.Cryptography;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            // anladigim kadariyla ilk tanimlar yapilir
            // 4x4 2d matris
            int[,] m = new int [4,4];
            //random
            Random r = new Random();

            //sutun ve satirlari tanimlamak ve olusturmak icin:
            for (int sutun = 0; sutun < 4; sutun++) 
            {  
                for(int satir = 0; satir < 4; satir++)
                {
                    m[satir, sutun] = r.Next(25, 85);
                }
            }

            //hersey belirlendigine gore artik bunlari konsola yazdirabiliriz!
            for (int a = 0; a < 4; a++)
            {
                for (int b = 0; b < 4; b++)
                {
                    Console.Write(m[a, b]);
                }
                Console.WriteLine();
            }
        }
    }
}
