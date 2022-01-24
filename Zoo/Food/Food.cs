namespace Zoo
{
    public enum FoodType
    {
        Meat = 1,
        Grass
    };
    class Food
    {
        public Food(int calories, FoodType ft)
        {
            Ftype = ft;
            Calories = calories;
        }
        public Food(FoodType ft)
        {
            Ftype = ft;
            if (Ftype == FoodType.Meat) Calories = 2000;
            else Calories = 1000;
        }
        public FoodType Ftype { get; set; }
        public int Calories { get; set; }
    }
}
