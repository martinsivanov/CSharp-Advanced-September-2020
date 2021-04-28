using System;
using System.Collections.Generic;
using System.Text;

namespace CustomRandomList
{
    class RandomList : List<string>
    {
        private Random rnd;

        public RandomList()
        {

        }
        public string RemoveRandomElements()
        {
            if (this.Count > 0)
            {
                int index = rnd.Next(0, this.Count);
                string str = this[index];
                this.RemoveAt(index);
                return str;
            }
            else
            {
                return null;
            }
          
        }
    }
}
