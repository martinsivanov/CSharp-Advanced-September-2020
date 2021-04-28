using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl.Contracts
{
    public interface IBuyer
    {

        public int Food { get;}
        public string Name { get;}

        public int BuyFood();
    }
}
