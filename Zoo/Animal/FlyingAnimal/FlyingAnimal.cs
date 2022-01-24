using System;

namespace Zoo
{
    class FlyingAnimal : Animal, IFlyable
    {
        public FlyingAnimal(string nm, GenderType gd, FoodType ft) : base(nm, gd, ft)
        {

        }
        public FlyingAnimal(string nm, int age, DateTime bday, GenderType gd, ALiveOrDeadStatus AOD, FoodType ft, int hunglvl) : base(nm, age, bday, gd, AOD, ft, hunglvl)
        {

        }
        public override Animal Breed()
        {
            throw new NotImplementedException();
        }



        public void Fly()
        {
            throw new NotImplementedException();
        }

        public override void Sleep()
        {
            throw new NotImplementedException();
        }
    }
}
