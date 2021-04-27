using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._Simple_Text_Editor
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Stack<string> stack = new Stack<string>();

            string text = string.Empty;

            for (int i = 0; i < n; i++)
            {
                string[] line = Console.ReadLine().Split().ToArray();
                if (line[0] == "1")
                {
                    string charactersForAdd = line[1];
                    text += charactersForAdd;
                    stack.Push(text);

                }
                else if (line[0] == "2")
                {
                    int count = int.Parse(line[1]);

                    int charsForErase = int.Parse(line[1]); ;
                    text = text.Substring(0, text.Length - charsForErase);
                    stack.Push(text);


                }
                else if (line[0] == "3")
                {
                    int index = int.Parse(line[1]);
                    Console.WriteLine(text[index - 1]);
                }
                else if (line[0] == "4")
                {
                    stack.Pop();
                    if (stack.Count > 0)
                    {
                        text = stack.Peek();
                    }
                    else
                    {
                        text = string.Empty;
                    }
                }

            }
        }
    }
}
