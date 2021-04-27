using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Balanced_Parenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<char> stack = new Stack<char>();

            bool isbalanced = true;
            foreach (var c in input)
            {
                if (c == '(' || c == '{' || c == '[')
                {
                    stack.Push(c);
                }
                else
                {
                    if (!stack.Any())
                    {
                        isbalanced = false;
                        break;
                    }

                    char currentOpen = stack.Pop();
                    bool isBalanceRound = currentOpen == '(' && c == ')';
                    bool isBalanceCurly = currentOpen == '{' && c == '}';
                    bool isBalanceSqueare = currentOpen == '[' && c == ']';

                    if (isBalanceRound == false && isBalanceCurly == false && isBalanceSqueare == false)
                    {
                        isbalanced = false;
                        break;
                    }
                }
            }
            if (isbalanced)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
