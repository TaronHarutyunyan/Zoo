using System;
//TODO remove unused using
namespace Zoo
{
    class TerrestrialAnimal : Animal, IWalkable
    {
        public TerrestrialAnimal(string nm, GenderType gd, FoodType ft) : base(nm, gd, ft)
        {

        }
        public TerrestrialAnimal(string nm, int age, DateTime bday, GenderType gd, ALiveOrDeadStatus AOD, FoodType ft, int hunglvl) : base(nm, age, bday, gd, AOD, ft, hunglvl)
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

        public void Walk()
        {
            throw new NotImplementedException();
        }
    }
}
