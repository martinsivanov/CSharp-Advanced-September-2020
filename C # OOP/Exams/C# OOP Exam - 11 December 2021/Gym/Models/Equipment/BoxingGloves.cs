namespace Gym.Models.Equipment
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class BoxingGloves : Equipment
    {
        private const double INITIAL_WEIGHTS = 227;
        private const decimal INITIAL_PRICE = 120;

        public BoxingGloves()
            : base(INITIAL_WEIGHTS, INITIAL_PRICE)
        {

        }
    }
}
