using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03.HeroesOfCodeAndLogicVII
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Hero> heroes = new List<Hero>();
            for (int i = 0; i < n; i++)
            {
                string[] cmdArg = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                Hero hero = new Hero()
                {
                    Name = cmdArg[0],
                    Hp = int.Parse(cmdArg[1]),
                    Mp = int.Parse(cmdArg[2])
                };
                heroes.Add(hero);
            }
            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] cmdArg = input
                    .Split(" - ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string currentCommand = cmdArg[0];
                string heroName = cmdArg[1];
                Hero hero = heroes.FirstOrDefault(h => h.Name == heroName);
                if (currentCommand == "CastSpell")
                {
                    int mana = int.Parse(cmdArg[2]);
                    string spellName = cmdArg[3];
                    if (hero.Mp >= mana)
                    {
                        hero.Mp -= mana;
                        Console.WriteLine($"{heroName} has successfully cast {spellName} and now has {hero.Mp} MP!");
                    }
                    else
                    {
                        Console.WriteLine($"{heroName} does not have enough MP to cast {spellName}!");
                    }

                }
                else if (currentCommand == "TakeDamage")
                {
                    int damage = int.Parse(cmdArg[2]);
                    string attacker = cmdArg[3];
                    hero.Hp -= damage;
                    if (hero.Hp > 0)
                    {
                        Console.WriteLine($"{heroName} was hit for {damage} HP by {attacker} and now has " +
                            $"{hero.Hp} HP left!");
                    }
                    else
                    {
                        Console.WriteLine($"{heroName} has been killed by {attacker}!");
                        heroes.Remove(hero);
                    }
                }
                else if (currentCommand == "Recharge")
                {
                    int amountMp = int.Parse(cmdArg[2]);
                    if (amountMp + hero.Mp > 200)
                    {
                        amountMp = 200 - hero.Mp;
                    }
                    hero.Mp += amountMp;
                    Console.WriteLine($"{heroName} recharged for {amountMp} MP!");
                }
                else if (currentCommand == "Heal")
                {
                    int amountMp = int.Parse(cmdArg[2]);
                    if (amountMp + hero.Hp > 100)
                    {
                        amountMp = 100 - hero.Hp;
                    }
                    hero.Hp += amountMp;
                    Console.WriteLine($"{heroName} healed for {amountMp} HP!");
                }
                input = Console.ReadLine();
            }
            foreach (var hero in heroes.OrderByDescending(h => h.Hp)
                .ThenBy(h => h.Name))
            {
                Console.WriteLine(hero);
            }
        }
    }

    class Hero
    {
        public string Name { get; set; }

        public int Hp { get; set; }

        public int Mp { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(Name);
            sb.AppendLine($"HP: {Hp}");
            sb.AppendLine($"MP: {Mp}");
            return sb.ToString().TrimEnd();
        }
    }
}
