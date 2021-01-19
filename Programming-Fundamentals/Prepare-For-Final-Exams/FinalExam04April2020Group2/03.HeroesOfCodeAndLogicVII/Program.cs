using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.HeroesOfCodeAndLogicVII
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, List<int>> heroes = new Dictionary<string, List<int>>();
            for (int i = 0; i < n; i++)
            {
                string[] cmdArg = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                heroes.Add(cmdArg[0], new List<int>() { int.Parse(cmdArg[1]), int.Parse(cmdArg[2]) });
            }
            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] cmdArg = input
                    .Split(" - ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string currentCommand = cmdArg[0];
                string heroName = cmdArg[1];
                if (currentCommand == "CastSpell")
                {
                    int mana = int.Parse(cmdArg[2]);
                    string spellName = cmdArg[3];
                    if (heroes[heroName][1] >= mana)
                    {
                        heroes[heroName][1] -= mana;
                        Console.WriteLine($"{heroName} has successfully cast {spellName} and now has {heroes[heroName][1]} MP!");
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
                    heroes[heroName][0] -= damage;
                    if (heroes[heroName][0] > 0)
                    {
                        Console.WriteLine($"{heroName} was hit for {damage} HP by {attacker} and now has " +
                            $"{heroes[heroName][0]} HP left!");
                    }
                    else
                    {
                        Console.WriteLine($"{heroName} has been killed by {attacker}!");
                        heroes.Remove(heroName);
                    }
                }
                else if (currentCommand == "Recharge")
                {
                    int amountMp = int.Parse(cmdArg[2]);
                    if (amountMp + heroes[heroName][1] > 200)
                    {
                        amountMp = 200 - heroes[heroName][1];
                    }
                    heroes[heroName][1] += amountMp;
                    Console.WriteLine($"{heroName} recharged for {amountMp} MP!");
                }
                else if (currentCommand == "Heal")
                {
                    int amountMp = int.Parse(cmdArg[2]);
                    if (amountMp + heroes[heroName][0] > 100)
                    {
                        amountMp = 100 - heroes[heroName][0];
                    }
                    heroes[heroName][0] += amountMp;
                    Console.WriteLine($"{heroName} healed for {amountMp} HP!");
                }
                input = Console.ReadLine();
            }
            foreach (var hero in heroes.OrderByDescending(v => v.Value[0])
                .ThenBy(k => k.Key))
            {
                Console.WriteLine($"{hero.Key}\nHP: {hero.Value[0]}\nMP: {hero.Value[1]}");
            }
        }
    }
}
