using System;
using System.Collections.Generic;

namespace Zoo
{
    class Program
    {

        public static List<Animal> Animals = new();
        public static List<Food> Foods = new();
        static void Main()
        {
            while (true)
            {
                ShowMainMenu();

            }
        }
        static void ShowMainMenu()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("---------MAIN MENU---------");
                Console.WriteLine("1.Add Animal");
                Console.WriteLine("2.Add Food");
                Console.WriteLine("3.Feed Animal");
                Console.WriteLine("4.Show Animal Info");
                Console.WriteLine("5.Exit");
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.NumPad1:
                        AddAnimal();
                        break;
                    case ConsoleKey.NumPad2:
                        AddFood();
                        break;
                    case ConsoleKey.NumPad3:
                        FeedAnimal();
                        break;
                    case ConsoleKey.NumPad4:
                        ShowAnimalInfo();
                        break;
                    case ConsoleKey.NumPad5:
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }
            }
            catch (InvalidInputException)
            {
                ShowMainMenu();
            }
        }
        static void ShowAnimalInfo()
        {
            foreach (var item in Animals)
            {
                Console.WriteLine($"Name - {item.Name} , Age - {item.Age} , Gender - {item.Gender} , {item.ALiveOrDead} , Hunger Level - {item.HungerLevel}");
            }
            Console.WriteLine("End Of List| Press Any Key to Continue");
            Console.ReadKey();
        }
        static void FeedAnimal()
        {
            ShowAnimalList();
        }
        static void ShowAnimalList()
        {
            Console.Clear();
            Console.WriteLine("Select Animal You Want To Feed");
            int i = 1;
            foreach (var item in Animals)
            {
                Console.WriteLine($"{i}.Name - {item.Name} , Hunger Level - {item.HungerLevel}");
                i++;
            }
            if (!int.TryParse(Console.ReadLine(), out int animalindex) || animalindex > Animals.Count) throw new InvalidInputException("Invalid Input in ShowAnimalList()");

            int a = ShowFoodList() - 1;
            Animals[animalindex - 1].Eat(Foods[a]);


        }
        static int ShowFoodList()
        {
            Console.Clear();
            Console.WriteLine("Select Food");
            int i = 1;
            foreach (var item in Foods)
            {
                Console.WriteLine($"{i}Food Type - {item.Ftype} , Calories From Food - {item.Calories}");
                i++;
            }
            if (!int.TryParse(Console.ReadLine(), out int foodindex) || foodindex > Animals.Count) throw new InvalidInputException("Invalid Input in ShowFoodList()");
            return foodindex;
        }
        static void AddFood()
        {
            Console.Clear();
            Console.WriteLine("--------Add Food--------");
            Console.WriteLine("Select Food Type\n1.Meat   2.Grass");
            if (!int.TryParse(Console.ReadLine(), out int foodtype) || foodtype > 2) throw new InvalidInputException("Invalid Input in AddFood()");
            Foods.Add(new Food((FoodType)foodtype));
            Console.WriteLine("Food Added\n Press Any key to continue");
            Console.ReadKey();
        }
        static void AddAnimal()
        {

            Console.Clear();
            Console.WriteLine("----------Add Animal---------");
            Console.Write("Enter Name - ");
            string name = Console.ReadLine();
            Console.WriteLine("Select Gender\n1.Male  2.Female");
            if (!int.TryParse(Console.ReadLine(), out int genderType) || genderType > 2) throw new InvalidInputException("Invalid Input In AddAnimal()|GenderType");
            Console.WriteLine("Select Type Of Food\n1.Meat  2.Grass");
            if (!int.TryParse(Console.ReadLine(), out int foodType) || foodType > 2) throw new InvalidInputException("Invalid Input in AddAnimal()|FoodType");
            Console.WriteLine("Select Animal Type\n1.Aquatic  2.Amphibian   3.Flying   4.Terrestrial");
            if (!int.TryParse(Console.ReadLine(), out int animaltype) || animaltype > 4) throw new InvalidInputException("Invalid input in AddAnimal()|AnimalType");

            switch (animaltype)
            {
                case 1:
                    Animals.Add(new AquaticAnimal(name, (GenderType)genderType, (FoodType)foodType));
                    break;
                case 2:
                    Animals.Add(new AmphibianAnimal(name, (GenderType)genderType, (FoodType)foodType));
                    break;
                case 3:
                    Animals.Add(new FlyingAnimal(name, (GenderType)genderType, (FoodType)foodType));
                    break;
                case 4:
                    Animals.Add(new TerrestrialAnimal(name, (GenderType)genderType, (FoodType)foodType));
                    break;

            }
            Console.WriteLine("Animal Added press any key to continue");
            Console.ReadKey();

        }

    }
}
