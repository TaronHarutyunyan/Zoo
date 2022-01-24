using System;
using System.Timers;

namespace Zoo
{
    //TODO enumn -ները առանձին ֆայլում
    public enum GenderType
    {
        Male = 1,
        Female
    };
    public enum ALiveOrDeadStatus
    {
        ALive, Dead
    };
    abstract class Animal
    {
        public Timer timer = new();
        protected Animal(string name, GenderType gender, FoodType foodType)
        {
            Name = name;
            Birthday = DateTime.Now;
            Age = Birthday.Year - DateTime.Now.Year;
            Gender = gender;
            HungerLevel = 1;
            Foodtype = foodType;
            ALiveOrDead = ALiveOrDeadStatus.ALive;
            StomachSize = 10000;
            GettingHungry();
        }


        //filemanagerum petqa
        protected Animal(string nm, int age, DateTime bday, GenderType gd, ALiveOrDeadStatus AOD, FoodType ft, int hunglvl)
        {
            Name = nm;
            Age = age;
            Birthday = bday;
            Gender = gd;
            ALiveOrDead = AOD;
            Foodtype = ft;
            StomachSize = 10000;
            HungerLevel = hunglvl;
            GettingHungry();
        }

        public string Name { set; get; }
        public int Age { private set; get; }
        public DateTime Birthday { private set; get; }
        public GenderType Gender { set; get; }
        public ALiveOrDeadStatus ALiveOrDead { get; set; }
        public FoodType Foodtype { set; get; }
        public int StomachSize { set; get; }
        public int HungerLevel { set; get; }
        public void Eat(Food f)
        {
            //TODO: ստուգում է պետք արդյոք կենդանին ուտում է էտ կերը
            if (ALiveOrDead != ALiveOrDeadStatus.Dead)
            {
                if (Foodtype == f.Ftype)
                {
                    if (f.Calories <= (StomachSize - HungerLevel)) HungerLevel += f.Calories;
                    else HungerLevel = 10000;

                }
                else
                {
                    throw new Exception("Wrong Food");
                    //throw new WrongFoodException();
                }
            }
            else throw new Exception("Animal Is Dead");
        }
        public override string ToString()
        {
            return $"{Name},{Age},{Birthday},{Gender},{ALiveOrDead},{Foodtype},{HungerLevel}";
        }
        public void GettingHungry()
        {
            timer.Interval = 60000;
            timer.Elapsed += Timer_Elapsed1;
            timer.Enabled = true;
        }

        //TODO անունը պետք է փոխել մեթոդի
        private void Timer_Elapsed1(object sender, ElapsedEventArgs e)
        {
            if (HungerLevel <= 0)
            {
                ALiveOrDead = ALiveOrDeadStatus.Dead;
                timer.Enabled = false;
            }
            else
            {
                HungerLevel--;
            }
        }
        public abstract void Sleep();
        public abstract Animal Breed();

    }
}
