using System;

namespace CustomRandomList
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            var myList = new RandomList();

            Console.WriteLine(myList.RemoveRandomElements());
        }
    }
}
