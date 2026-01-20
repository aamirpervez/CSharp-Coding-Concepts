using System;

namespace Simple_Game_Character_System
{
    class GameCharacter
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int Mana { get; set; }
        public int Level { get; set; }

        public void TakeDamage(int amount)
        {
            Health -= amount;
        }

        public void Heal(int amount)
        {
            Health += amount;

            if (Health > 100)
            {
                Health = 100;
            }
            Console.WriteLine($"{Name} Healed");
        }

        public void UseMana(int amount)
        {
            if(Mana >= amount)
            {
                Mana -= amount;
                Console.WriteLine($"{Name} Used Mana");
            }
            else if (Mana < amount)
            {
                Console.WriteLine($"{Name} Not Enough Mana");
            }
        }

        public void Rest()
        {
            Health = 100;
            Mana = 50;
        }
    }

    class Player : GameCharacter
    {
        public int Experience { get; set; }
    }

    class Enemy : GameCharacter
    {
        public int Damage { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player();
            player.Name = "Bilal";
            player.Health = 100;
            player.Mana = 50;
            player.Level = 10;

            Enemy enemy = new Enemy();
            enemy.Health = 90;
            enemy.Mana = 0;
            enemy.Level = 20;
            enemy.Damage = 15;

            enemy.TakeDamage(20);
            player.TakeDamage(enemy.Damage);
            Console.WriteLine();

            Console.WriteLine(enemy.Health);
            Console.WriteLine(player.Health);

            player.Heal(30);

            Console.WriteLine(player.Health);
        }
    }
}