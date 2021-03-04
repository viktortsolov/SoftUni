using System;
using System.Collections.Generic;
using WildFarm.Core.Contracts;
using WildFarm.Factories;
using WildFarm.Models.Animals;
using WildFarm.Models.Foods;

namespace WildFarm.Core
{
    class Engine : IEngine
    {
        private readonly FoodFactory foodFactory;
        private readonly AnimalFactory animalFactory;
        private readonly List<Animal> animals;
        public Engine()
        {
            foodFactory = new FoodFactory();
            animalFactory = new AnimalFactory();
            animals = new List<Animal>();
        }

        public void Run()
        {
            string inputAnimal = string.Empty;
            while ((inputAnimal = Console.ReadLine()) != "End")
            {
                Animal animal = ProcessAnimalInfo(inputAnimal);
                Food food = ProcessFoodInfo();

                animals.Add(animal);

                Console.WriteLine(animal.AskForFood());

                try
                {
                    animal.Feed(food);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            foreach (Animal animal in animals)
            {
                Console.WriteLine(animal);
            }
        }

        private Food ProcessFoodInfo()
        {
            string[] foodArgs = Console.ReadLine()
                                          .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string foodType = foodArgs[0];
            int quantity = int.Parse(foodArgs[1]);

            Food food = this.foodFactory.CreateFood(foodType, quantity);

            return food;
        }

        private Animal ProcessAnimalInfo(string input)
        {
            string[] animalArgs = input.Split();

            Animal animal = this.animalFactory.CreateAnimal(animalArgs);

            return animal;
        }
    }
}
