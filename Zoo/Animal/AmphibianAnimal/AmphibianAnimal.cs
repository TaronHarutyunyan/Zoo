using System;

namespace Zoo
{
    class AmphibianAnimal : Animal, IWalkable, ISwimable
    {
        public AmphibianAnimal(string nm, GenderType gt, FoodType ft) : base(nm, gt, ft)
        {

        }
        public AmphibianAnimal(string nm, int age, DateTime bday, GenderType gd, ALiveOrDeadStatus AOD, FoodType ft, int hunglvl) : base(nm, age, bday, gd, AOD, ft, hunglvl)
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

        public void Walk()
        {
            throw new NotImplementedException();
        }
    }
}
