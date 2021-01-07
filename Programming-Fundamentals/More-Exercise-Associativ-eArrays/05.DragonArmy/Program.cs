using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.DragonArmy
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<Dragon>> result = new Dictionary<string, List<Dragon>>();
            int dragonsCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < dragonsCount; i++)
            {
                string[] dragonInfo = Console.ReadLine()
                    .Split()
                    .ToArray();
                string type = dragonInfo[0];
                string name = dragonInfo[1];
                int damage = 0;
                int health = 0;
                int armor = 0;
                if (dragonInfo[2] == "null")
                {
                    damage = 45;
                }
                else
                {
                    damage = int.Parse(dragonInfo[2]);
                }
                if (dragonInfo[3] == "null")
                {
                    health = 250;
                }
                else
                {
                    health = int.Parse(dragonInfo[3]);
                }
                if (dragonInfo[4] == "null")
                {
                    armor = 10;
                }
                else
                {
                    armor = int.Parse(dragonInfo[4]);
                }
                if (result.ContainsKey(type) == false)
                {
                    Dragon dragon = new Dragon(name, damage, health, armor);
                    result.Add(type, new List<Dragon>());
                    result[type].Add(dragon);
                }
                else
                {
                    Dragon repeat = result[type].Find(x => x.Name == name);
                    if ((repeat == null) == false)
                    {
                        repeat.Damage = damage;
                        repeat.Health = health;
                        repeat.Armor = armor;
                    }
                    else
                    {
                        Dragon dragon = new Dragon(name, damage, health, armor);
                        result[type].Add(dragon);
                    }
                }

            }

            foreach (var dragon in result)
            {
                double averageDamage = dragon.Value.Average(x => x.Damage); 
                double averageHealth = dragon.Value.Average(x => x.Health); 
                double averageArmor = dragon.Value.Average(x => x.Armor); 
                Console.WriteLine($"{dragon.Key}::({averageDamage:f2}/{averageHealth:f2}/{averageArmor:f2})");
                Console.WriteLine(String.Join(Environment.NewLine,
                    dragon.Value.OrderBy(x => x.Name)
                    .Select(x => $"-{x.Name} -> damage: {x.Damage}, health: {x.Health}, armor: {x.Armor}")));
            }
        }
    }

    class Dragon
    {
        public string Name { get; set; }
        public int Damage { get; set; }
        public int Health { get; set; }
        public int Armor { get; set; }
        public Dragon(string name, int damage, int health, int armor)
        {
            this.Name = name;
            this.Damage = damage;
            this.Health = health;
            this.Armor = armor;
        }
    }
}

