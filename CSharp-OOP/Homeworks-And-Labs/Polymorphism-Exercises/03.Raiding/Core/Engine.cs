using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Raiding.Core
{
    class Engine
    {
        public void Run()
        {
            int n = int.Parse(Console.ReadLine());
            List<BaseHero> heroes = new List<BaseHero>();
            for (int i = 0; i < n; i++)
            {
                if (AddHero(heroes) == false) i--;
            }
            int bossPower = int.Parse(Console.ReadLine());

            CastAbility(heroes);

            PrintFinalState(heroes, bossPower);
        }

        private static void PrintFinalState(List<BaseHero> heroes, int bossPower)
        {
            if (heroes.Sum(h => h.Power) >= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }

        private static bool AddHero(List<BaseHero> heroes)
        {
            string name = Console.ReadLine();
            string type = Console.ReadLine();
            if (type == "Druid")
            {
                heroes.Add(new Druid(name));
            }
            else if (type == "Paladin")
            {
                heroes.Add(new Paladin(name));
            }
            else if (type == "Rogue")
            {
                heroes.Add(new Rogue(name));
            }
            else if (type == "Warrior")
            {
                heroes.Add(new Warrior(name));
            }
            else
            {
                Console.WriteLine("Invalid hero!");
                return false;
            }
            return true;
        }

        private void CastAbility(List<BaseHero> heroes)
        {
            foreach (var hero in heroes)
            {
                Console.WriteLine(hero.CastAbility());
            }
        }
    }
}
