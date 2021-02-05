using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Trainer> trainers = new List<Trainer>();
            string input = Console.ReadLine();
            while (input != "Tournament")
            {
                string[] tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string trainer = tokens[0];
                string pokemon = tokens[1];
                string element = tokens[2];
                int health = int.Parse(tokens[3]);
                Pokemon currentPokemon = new Pokemon(pokemon, element, health);
                if (trainers.Any(x => x.Name == trainer) == false)
                {
                    trainers.Add(new Trainer(trainer));
                }
                Trainer currentTrainer = trainers.FirstOrDefault(x => x.Name == trainer);
                if (currentTrainer.Pokemons.Any(x => x.Name == pokemon) == false)
                {
                    currentTrainer.Pokemons.Add(currentPokemon);
                }
                input = Console.ReadLine();
            }
            string command = Console.ReadLine();
            while (command != "End")
            {
                CheckForElemens(trainers, command);
                command = Console.ReadLine();
            }
            foreach (var trainer in trainers.OrderByDescending(x => x.Badges))
            {
                Console.WriteLine($"{trainer.Name} {trainer.Badges} {trainer.Pokemons.Count}");
            }
        }

        static void CheckForElemens(List<Trainer> trainers, string command)
        {
            foreach (var trainer in trainers)
            {
                if (trainer.Pokemons.Any(x => x.Element == command))
                {
                    trainer.Badges++;
                }
                else
                {
                    DecreasePokemonHealthBy10AndRemove(trainer);
                }
            }
        }

        static void DecreasePokemonHealthBy10AndRemove(Trainer trainer)
        {
            foreach (var pokemon in trainer.Pokemons)
            {
                pokemon.Health -= 10;
            }
            trainer.Pokemons.RemoveAll(x => x.Health <= 0);
        }
    }
}
