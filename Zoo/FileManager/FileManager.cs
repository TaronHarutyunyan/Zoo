using System;
using System.Collections.Generic;
using System.IO;

namespace Zoo
{
    static class FileManagers
    {
        public static readonly string FileAdress = @"./AnimalInfo.txt";
        public static readonly string FileAdress2 = @"./Log.txt";
        public static void WriteInfoInFile(List<Animal> animals)
        {
            using StreamWriter writer = new(new FileStream(FileAdress, FileMode.Append, FileAccess.Write));
            foreach (var item in animals)
            {
                writer.WriteLine(item.GetType() + "," + item.ToString() + "," + DateTime.Now);
            }
        }
        public static List<Animal> ReadInfoFromFile()
        {
            List<Animal> animals = new();
            string[] arr;
            string s;
            using StreamReader reader = new(new FileStream(FileAdress, FileMode.Open, FileAccess.Read));
            while (!reader.EndOfStream)
            {
                s = reader.ReadLine();
                arr = s.Split(',');
                animals.Add(StringToAnimalParser(arr));
            }
            return animals;
        }
        public static void ErrorWriter(string s)
        {
            using StreamWriter writer = new(new FileStream(FileAdress2, FileMode.Append, FileAccess.Write));
            writer.WriteLine(s + DateTime.Now.ToString());
        }
        private static Animal StringToAnimalParser(string[] s)
        {
            Animal a;
            string name = s[1];
            int age = int.Parse(s[2]);
            DateTime birthday = DateTime.Parse(s[3]);
            GenderType gender;
            if (s[4] == "Male") gender = GenderType.Male; else gender = GenderType.Female;
            ALiveOrDeadStatus status;
            if (s[5] == "ALive") status = ALiveOrDeadStatus.ALive; else status = ALiveOrDeadStatus.Dead;
            FoodType foodType;
            if (s[6] == "Meat") foodType = FoodType.Meat; else foodType = FoodType.Grass;
            int hungerlvl = int.Parse(s[7]);

            Type tp = Type.GetType(s[0]);
            if (tp == typeof(AmphibianAnimal)) a = new AmphibianAnimal(name, age, birthday, gender, status, foodType, hungerlvl);
            else if (tp == typeof(AquaticAnimal)) a = new AquaticAnimal(name, age, birthday, gender, status, foodType, hungerlvl);
            else if (tp == typeof(TerrestrialAnimal)) a = new TerrestrialAnimal(name, age, birthday, gender, status, foodType, hungerlvl);
            else a = new FlyingAnimal(name, age, birthday, gender, status, foodType, hungerlvl);
            ChangeHungerLevel(a, DateTime.Parse(s[8]));
            return a;

        }
        private static void ChangeHungerLevel(Animal animal, DateTime dateTime)
        {
            if (dateTime.AddMinutes(animal.HungerLevel).Ticks >= DateTime.Now.Ticks)
            {
                animal.HungerLevel = 0;
                animal.ALiveOrDead = ALiveOrDeadStatus.Dead;
            }

        }
    }
}
