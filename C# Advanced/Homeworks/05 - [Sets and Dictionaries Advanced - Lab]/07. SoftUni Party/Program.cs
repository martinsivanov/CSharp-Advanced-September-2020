using System;
using System.Collections.Generic;

namespace _07._SoftUni_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> listRegular = new HashSet<string>();
            HashSet<string> listVIP = new HashSet<string>();

            string input = Console.ReadLine();

            int cntDidntCome = 0;

            while (input != "END")
            {
                string guest = input;

                if (guest != "PARTY")
                {

                    if (char.IsDigit(guest[0]))
                    {
                        listVIP.Add(guest);
                    }
                    else
                    {
                        listRegular.Add(guest);
                    }
                }
                if (input == "PARTY")
                {
                    string name = Console.ReadLine();
                    while (name != "END")
                    {
                        if (char.IsDigit(name[0]))
                        {
                            listVIP.Remove(name);
                        }
                        else
                        {
                            listRegular.Remove(name);
                        }
                        name = Console.ReadLine();
                    }
                    break;
                }

                input = Console.ReadLine();
            }

            cntDidntCome = listRegular.Count + listVIP.Count;
            Console.WriteLine(cntDidntCome);
            if (listVIP.Count > 0)
            {
                Console.WriteLine(String.Join(Environment.NewLine, listVIP));
            }
            if (listRegular.Count > 0)
            {
                Console.WriteLine(String.Join(Environment.NewLine, listRegular));
            }
        }
    }
}
