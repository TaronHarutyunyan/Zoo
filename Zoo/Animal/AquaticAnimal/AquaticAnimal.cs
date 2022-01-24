using System;

namespace Zoo
{
    class AquaticAnimal : Animal, ISwimable
    {
        public AquaticAnimal(string nm, GenderType gd, FoodType ft) : base(nm, gd, ft)
        {

        }
        public AquaticAnimal(string nm, int age, DateTime bday, GenderType gd, ALiveOrDeadStatus AOD, FoodType ft, int hunglvl) : base(nm, age, bday, gd, AOD, ft, hunglvl)
        {

        }
        public override Animal Breed()
        {
            throw new NotImplementedException();
        }



        public override void Sleep()
        {
            throw new NotImplementedException();
        }

        public void Swim()
        {
            throw new NotImplementedException();
        }
    }
}
