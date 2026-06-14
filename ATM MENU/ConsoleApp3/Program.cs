using System.ComponentModel;
using System.Data;
using static ConsoleApp3.Program;

namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Asteroid asteroid = new Asteroid(); 
            Spaceship spaceship = new Spaceship();
            
            Console.WriteLine("Gemi ismini giriniz:");
            spaceship.Name = Console.ReadLine();

            asteroid.Name = "Demirock";
            asteroid.mineralAmount = Random.Shared.Next(1, 101);
            asteroid.isScanned = false;
            asteroid.Hardness = Random.Shared.Next(1, 11);
            


            bool devamEt = true;

            List<MiningAction> islemler = new List<MiningAction>();

            islemler.Add(new ScanAction("Asteroid Tarama", 5));
            islemler.Add(new DrillAction("Maden Delme", 15, 25));

            while (devamEt) 
            {
               Console.Clear();
               Console.WriteLine("===== ASTEROID MADENCILIGI =====");
               Console.WriteLine("1 - İşlemleri Listele");
               Console.WriteLine("2 - İşlem Yap");
               Console.WriteLine("3 - Gemi Durumunu Göster");
               Console.WriteLine("4 - Asteroid Durumunu Göster");
               Console.WriteLine("5 - Çıkış");
               Console.Write("Seçiminiz: ");

                string secim = Console.ReadLine();

                switch (secim)
                {
                    case "1":
                        Listele(islemler);
                        break;
                    case "2":
                        Islem(islemler, spaceship, asteroid);
                        break;
                    case "3":
                        DurumGoster(spaceship, asteroid);
                        break;
                    case "4":
                        AsteroidDurum(asteroid);
                        break;




                }
            }    
        }    

        static void Listele(List<MiningAction> islemler)
        {
            Console.WriteLine("İşlemler: ");
            for (int i = 0; i < islemler.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {islemler[i].Name}");
            }
        }
        
        static void Islem(List<MiningAction> islemler, Spaceship spaceship, Asteroid asteroid)
        {
            Listele(islemler);
            
            Console.Write("Yapilacak Islemi Seciniz.");
            int secilenIslem = Convert.ToInt32(Console.ReadLine());

            /* if (secilenIslem < 1 || secilenIslem > islemler.Count)
              {
                  throw new InvalidSelectionException("Böyle bir kart numarası yok.");
              }*/
            MiningAction Execute = islemler[secilenIslem - 1];
            Execute.Execute(spaceship, asteroid);
        }

        static void DurumGoster(Spaceship spaceship, Asteroid asteroid)
        {
            Console.WriteLine($" Gemi:{spaceship.Name}" +
                $" Yakit: {spaceship.Fuel}" +
                $" Kargo Miktari: {spaceship.cargoAmount}" +
                $" Max Kargo: {spaceship.maxCargo}" +
                $" Sicaklik Degeri: {spaceship.Temp}");

        }
        
        static void AsteroidDurum(Asteroid asteroid)
        {
            if(asteroid.isScanned = true)
            {
                Console.WriteLine($" Asteroid:{asteroid.Name}" +
                $" Mineral Miktari: {asteroid.mineralAmount}" +
                $" Sertligi: {asteroid.Hardness}");
            }
        }



        public class Spaceship
        {
            public string Name { get; set; }
            public int Fuel { get; set; }
            public int cargoAmount { get; set; }
            public int maxCargo { get; private set; }
            public int Temp { get; set; }

            public void UseFuel(int amount)
            {

            }

            public void AddCargo(int amount)
            {

            }

            public void CoolDown(int amount)
            {
            
            }

            public void IncreaseTemp(int amount)
            {

            }
        }   

        public class Asteroid
        {
            public string Name;
            public int mineralAmount;
            public int Hardness;
            public bool isScanned;

            public void Scan()
            {
                isScanned = false;
            }

            public void ExtractMineral(int amount)
            {

            }
        }

        interface IScannable
        {
            void Scan(Asteroid asteroid);
        }

        interface IMineable
        {
            void GainedAmount(Spaceship spaceship, Asteroid asteroid);
        }

        interface ICoolable
        {
            void Cool(Spaceship ship);
        }

        abstract class MiningAction
        {
            public string Name { get; set; }
            public int FuelCost;
            public int AddTemp;
            public int CoolDown;
            public int DrillPower;
           

            public MiningAction(string name, int fuelCost)
            {
                Name = name;
                FuelCost = fuelCost;
                
                
                
            }

           

            public abstract void Execute(Spaceship spaceship, Asteroid asteroid); 
            
        }
      class ScanAction : MiningAction, IScannable
      {
            public ScanAction(string name, int fuelCost) : base(name, fuelCost)
            {

            }
            public override void Execute(Spaceship spaceship, Asteroid asteroid)
            {
                
            }

            public void Scan(Asteroid asteroid)
            {
                asteroid.isScanned = true;
            }
      } 
      class DrillAction : MiningAction, IMineable
      {
            public int DrillPower { get; set; }
            

            public DrillAction(string name, int fuelCost, int drillPower) : base(name, fuelCost)
            {
                DrillPower = drillPower;

            }
            public override void Execute(Spaceship spaceship, Asteroid asteroid)
            {
                
            }
            public void MinedAmount(Spaceship spaceship, Asteroid asteroid, int amount)
            {
                gainedAmount = DrillPower - asteroid.Hardness;
            }
      }

    }
}
