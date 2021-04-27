using System;

namespace _05.DateModifier
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string first = Console.ReadLine();
            string second = Console.ReadLine();

            DateModifier dateModifier = new DateModifier();
            var result = dateModifier.CalculateDifference(first, second);

            Console.WriteLine(result);
        }
    }
}
