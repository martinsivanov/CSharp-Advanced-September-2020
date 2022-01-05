namespace Gym.Models.Equipment
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Kettlebell : Equipment
    {
        private const double INITIAL_WEIGHTS = 10000;
        private const decimal INITIAL_PRICE = 80;

        public Kettlebell()
            : base(INITIAL_WEIGHTS, INITIAL_PRICE)
        {

        }
    }
}
