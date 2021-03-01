using System;

namespace PlayersAndMonsters
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            BladeKnight bladeKnight = new BladeKnight("Gosho",80);
            DarkWizard darkWizard = new DarkWizard("Tosho",100);
            Console.WriteLine(bladeKnight);
            Console.WriteLine(darkWizard);

        }
    }
}
