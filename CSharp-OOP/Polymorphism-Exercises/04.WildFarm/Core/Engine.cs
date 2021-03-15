using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace _04.WildFarm.Core
{
    class Engine
    {
        public void Run()
        {
            List<Animal> animals = new List<Animal>();

            AddAnimals(animals);

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }

        private void AddAnimals(List<Animal> animals)
        {
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] animalInfo = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string type = animalInfo[0];
                string name = animalInfo[1];
                double weight = double.Parse(animalInfo[2]);

                Animal currentAnimal = null;
                switch (type)
                {
                    case "Owl":
                        double wingSize = double.Parse(animalInfo[3]);
                        currentAnimal = new Owl(name, weight, wingSize);
                        break;
                    case "Hen":
                        wingSize = double.Parse(animalInfo[3]);
                       currentAnimal = new Hen(name, weight, wingSize);
                        break;

                    case "Mouse":
                        string livingRegion = animalInfo[3];
                        currentAnimal = new Mouse(name, weight, livingRegion);
                        break;
                    case "Dog":
                        livingRegion = animalInfo[3];
                        currentAnimal = new Dog(name, weight, livingRegion);
                        break;

                    case "Cat":
                        livingRegion = animalInfo[3];
                        string breed = animalInfo[4];
                        currentAnimal = new Cat(name, weight, livingRegion, breed);
                        break;
                    case "Tiger":
                        livingRegion = animalInfo[3];
                        breed = animalInfo[4];
                        currentAnimal = new Tiger(name, weight, livingRegion, breed);
                        break;
                }

                string[] foodInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string foodType = foodInfo[0];
                int quantity = int.Parse(foodInfo[1]);

                currentAnimal.ProduceSound(TakeFood(foodType,quantity));
                animals.Add(currentAnimal);
            }
        }

        private Food TakeFood(string type, int quantity)
        {
            switch (type)
            {
                case "Meat":
                    return new Meat(quantity);
                case "Vegetable":
                    return new Vegetable(quantity);
                case "Fruit":
                    return new Fruit(quantity);
                case "Seeds":
                    return new Seeds(quantity);
            }
            return null;
        }
    }

}
