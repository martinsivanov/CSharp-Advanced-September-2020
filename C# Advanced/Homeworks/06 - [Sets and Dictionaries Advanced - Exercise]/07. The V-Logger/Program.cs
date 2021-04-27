using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._The_V_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, HashSet<string>>> vLoggers = new Dictionary<string, Dictionary<string, HashSet<string>>>();

            string input = Console.ReadLine();


            while (input != "Statistics")
            {
                string[] inputInfo = input.Split().ToArray();


                if (inputInfo.Contains("joined"))
                {
                    string vloggername = inputInfo[0];

                    if (!vLoggers.ContainsKey(vloggername))
                    {
                        vLoggers.Add(vloggername, new Dictionary<string, HashSet<string>>());
                        vLoggers[vloggername].Add("followers", new HashSet<string>());
                        vLoggers[vloggername].Add("followings", new HashSet<string>());
                    }
                }
                else if (inputInfo.Contains("followed"))
                {
                    string follower = inputInfo[0];
                    string vloggername = inputInfo[2];

                    if (vLoggers.ContainsKey(vloggername))
                    {

                        if (!vLoggers[vloggername]["followers"].Contains(follower) && vloggername != follower)
                        {
                            if (vLoggers.ContainsKey(follower))
                            {
                                vLoggers[vloggername]["followers"].Add(follower);

                                vLoggers[follower]["followings"].Add(vloggername);
                            }
                        }
                    }

                }


                input = Console.ReadLine();

            }

            Console.WriteLine($"The V-Logger has a total of {vLoggers.Count} vloggers in its logs.");

            vLoggers = vLoggers.OrderByDescending(f => f.Value["followers"].Count).ThenBy(f => f.Value["followings"].Count).ToDictionary(x => x.Key, y => y.Value);

            int counter = 0;

            foreach (var (name, followers) in vLoggers)
            {
                counter++;
                Console.WriteLine($"{counter}. {name} : {followers["followers"].Count} followers, {followers["followings"].Count} following");
                if (counter == 1)
                {
                    foreach (var follower in followers["followers"].OrderBy(n => n))
                    {
                        Console.WriteLine($"*  {follower}");
                    }
                }
            }
        }
    }
}
