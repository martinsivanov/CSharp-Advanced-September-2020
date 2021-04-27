using System;
using System.Linq;

namespace _03._Count_Uppercase_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, bool> func = s => s[0] == s.ToUpper()[0];

            string[] text = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Where(func).ToArray();

            Console.WriteLine(String.Join(Environment.NewLine, text));
        }
    }
}
