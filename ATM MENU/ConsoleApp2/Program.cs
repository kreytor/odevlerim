using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Player player1 = new Player("Ash");
        Player player2 = new Player("Gary");

        List<Card> cards = new List<Card>();

        cards.Add(new AttackCard("Ateş Kartı", 20));
        cards.Add(new HealCard("Şifa Kartı", 15));

        bool devamEt = true;

        while (devamEt)
        {
            try
            {
                Console.WriteLine("===== KART OYUNU =====");
                Console.WriteLine("1 - Kartları Listele");
                Console.WriteLine("2 - Kart Oyna");
                Console.WriteLine("3 - Oyuncu Durumlarını Göster");
                Console.WriteLine("4 - Çıkış");
                Console.Write("Seçiminiz: ");

                string secim = Console.ReadLine();

                Console.WriteLine();

                switch (secim)
                {
                    case "1":
                        KartlariListele(cards);
                        break;

                    case "2":
                        KartOyna(cards, player1, player2);
                        break;

                    case "3":
                        DurumGoster(player1, player2);
                        break;

                    case "4":
                        devamEt = false;
                        Console.WriteLine("Oyundan çıkılıyor...");
                        break;

                    default:
                        throw new Exception("Menüde olmayan bir seçim yaptınız.");
                }
            }
            catch (InvalidCardSelectionException ex)
            {
                Console.WriteLine("Kart seçim hatası: " + ex.Message);
            }
            catch (FormatException)
            {
                Console.WriteLine("Hata: Lütfen sayı giriniz.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hata: " + ex.Message);
            }

            Console.WriteLine();
        }
    }

    static void KartlariListele(List<Card> cards)
    {
        Console.WriteLine("Kartlar:");

        for (int i = 0; i < cards.Count; i++)
        {
            Console.WriteLine($"{i + 1} - {cards[i].Name}");
        }
    }

    static void KartOyna(List<Card> cards, Player player1, Player player2)
    {
        KartlariListele(cards);

        Console.Write("Oynamak istediğiniz kart numarası: ");
        int secilenKart = Convert.ToInt32(Console.ReadLine());

        if (secilenKart < 1 || secilenKart > cards.Count)
        {
            throw new InvalidCardSelectionException("Böyle bir kart numarası yok.");
        }

        Card card = cards[secilenKart - 1];

        card.Play(player1, player2);
    }

    static void DurumGoster(Player player1, Player player2)
    {
        Console.WriteLine($"{player1.Name} Can: {player1.Health}");
        Console.WriteLine($"{player2.Name} Can: {player2.Health}");
    }
}

// Oyuncu sınıfı
class Player
{
    public string Name { get; set; }
    public int Health { get; private set; } = 100;

    public Player(string name)
    {
        Name = name;
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;

        if (Health < 0)
        {
            Health = 0;
        }

        Console.WriteLine($"{Name} {damage} hasar aldı. Can: {Health}");
    }

    public void Heal(int amount)
    {
        Health += amount;

        if (Health > 100)
        {
            Health = 100;
        }

        Console.WriteLine($"{Name} {amount} can kazandı. Can: {Health}");
    }
}

// Abstract class
abstract class Card
{
    public string Name { get; set; }

    public Card(string name)
    {
        Name = name;
    }

    public abstract void Play(Player owner, Player enemy);
}

// Interface
interface IAttackable
{
    void Attack(Player enemy);
}

interface IHealable
{
    void Heal(Player owner);
}

// Saldırı kartı
class AttackCard : Card, IAttackable
{
    public int Damage { get; set; }

    public AttackCard(string name, int damage) : base(name)
    {
        Damage = damage;
    }

    public override void Play(Player owner, Player enemy)
    {
        Console.WriteLine($"{owner.Name}, {Name} oynadı.");
        Attack(enemy);
    }

    public void Attack(Player enemy)
    {
        enemy.TakeDamage(Damage);
    }
}

// Şifa kartı
class HealCard : Card, IHealable
{
    public int HealAmount { get; set; }

    public HealCard(string name, int healAmount) : base(name)
    {
        HealAmount = healAmount;
    }

    public override void Play(Player owner, Player enemy)
    {
        Console.WriteLine($"{owner.Name}, {Name} oynadı.");
        Heal(owner);
    }

    public void Heal(Player owner)
    {
        owner.Heal(HealAmount);
    }
}

// Custom Exception
class InvalidCardSelectionException : Exception
{
    public InvalidCardSelectionException(string message) : base(message)
    {
    }
}