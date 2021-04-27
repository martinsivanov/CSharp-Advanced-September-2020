using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contestAndPasswords = new Dictionary<string, string>();
            Dictionary<string, Dictionary<string, int>> Students = new Dictionary<string, Dictionary<string, int>>();

            string input = Console.ReadLine();

            while (input != "end of contests")
            {
                string[] inputInfo = input.Split(":");
                string contest = inputInfo[0];
                string passwordForContest = inputInfo[1];
                if (!contestAndPasswords.ContainsKey(contest))
                {
                    contestAndPasswords.Add(contest, passwordForContest);
                }

                input = Console.ReadLine();
            }
            string command = Console.ReadLine();
            while (command != "end of submissions")
            {
                string[] info = command.Split("=>").ToArray();

                string contest = info[0];
                string password = info[1];
                string username = info[2];
                int points = int.Parse(info[3]);
                if (contestAndPasswords.ContainsKey(contest) && contestAndPasswords.ContainsValue(password))
                {
                    if (!Students.ContainsKey(username))
                    {
                        Students.Add(username, new Dictionary<string, int>());

                        if (!Students[username].ContainsKey(contest))
                        {
                            Students[username].Add(contest, points);

                        }
                    }
                    else
                    {
                        if (Students[username].ContainsKey(contest))
                        {
                            if (Students[username][contest] < points)
                            {
                                Students[username][contest] = points;
                            }
                        }
                        else
                        {
                            Students[username][contest] = points;
                        }

                    }

                }
                command = Console.ReadLine();
            }

            int bestPoints = 0;
            string bestUser = string.Empty;

            foreach (var (student, contests) in Students)
            {
                int totalPoints = 0;
                foreach (var contest in contests)
                {
                    totalPoints += contest.Value;
                }
                if (totalPoints > bestPoints)
                {
                    bestPoints = totalPoints;
                    bestUser = student;

                }
            }
            Console.WriteLine($"Best candidate is {bestUser} with total {bestPoints} points.");

            Students = Students.OrderBy(n => n.Key).ToDictionary(x => x.Key, y => y.Value);
            Console.WriteLine("Ranking:");
            foreach (var (student, contests) in Students)
            {
                Console.WriteLine(student);
                foreach (var contest in contests.OrderByDescending(c => c.Value))
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }
        }
    }
}
