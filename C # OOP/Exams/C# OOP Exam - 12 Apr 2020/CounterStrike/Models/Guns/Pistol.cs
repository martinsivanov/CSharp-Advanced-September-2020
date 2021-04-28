using System;
using System.Collections.Generic;
using System.Text;

namespace CounterStrike.Models.Guns
{
    public class Pistol : Gun
    {
        public Pistol(string name, int bulletsCount)
            : base(name, bulletsCount)
        {
        }

        public override int Fire()
        {
            int result = 0;
            if (this.BulletsCount > 0)
            {
                this.BulletsCount -= 1;
              return result = 1;
            }

            return result;
           
        }
    }
}
