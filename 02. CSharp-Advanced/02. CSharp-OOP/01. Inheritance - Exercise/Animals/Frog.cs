﻿namespace Animals
{
    class Frog : Animal
    {
        public Frog(string name, int age, string gender)
            : base(name, age, gender)
        {
        }
        public override string ProduceSound()
        {
            string sound = "Ribbit";
            return sound;
        }
    }
}
