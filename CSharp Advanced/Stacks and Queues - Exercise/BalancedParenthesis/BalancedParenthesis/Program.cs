using System;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;

namespace BalancedParenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            Stack<char> firstQueue = new Stack<char>();
            bool isItBalanced = true;
            foreach (var ch in input)
            {
                switch (ch)
                {
                    case '{':
                        isItBalanced = FirstComparingBrackets(firstQueue, isItBalanced);
                        if (isItBalanced == false)
                        {
                            Console.WriteLine("NO");
                        }
                        else
                        {
                            firstQueue.Push(ch);
                        }

                        break;
                    case '(':
                        isItBalanced = FirstComparingBrackets(firstQueue, isItBalanced);
                        if (isItBalanced == false)
                        {
                            Console.WriteLine("NO");
                        }
                        else
                        {
                            firstQueue.Push(ch);
                        }

                        break;
                    case '[':
                        isItBalanced = FirstComparingBrackets(firstQueue, isItBalanced);
                        if (isItBalanced == false)
                        {
                            Console.WriteLine("NO");
                        }
                        else
                        {
                            firstQueue.Push(ch);
                        }

                        break;
                    case '}':
                        isItBalanced = SecondComparingBrackets(firstQueue, ch, isItBalanced);
                        if (isItBalanced == false)
                        {
                            Console.WriteLine("NO");
                        }
                        else
                        {
                            firstQueue.Pop();
                        }

                        break;
                    case ')':
                        isItBalanced = SecondComparingBrackets(firstQueue, ch, isItBalanced);
                        if (isItBalanced == false)
                        {
                            Console.WriteLine("NO");
                        }
                        else
                        {
                            firstQueue.Pop();
                        }

                        break;
                    case ']':
                        isItBalanced = SecondComparingBrackets(firstQueue, ch, isItBalanced);
                        if (isItBalanced == false)
                        {
                            Console.WriteLine("NO");
                        }
                        else
                        {
                            firstQueue.Pop();
                        }

                        break;
                    default:
                        break;
                }
                if (isItBalanced == false)
                {
                    break;
                }
            }

            if (isItBalanced == true)
            {
                Console.WriteLine("YES");
            }
        }
        public static bool FirstComparingBrackets(Stack<char> firstQueue, bool isItBalanced)
        {
            if (firstQueue.Count != 0)
            {
                if (firstQueue.Peek() == '}' || firstQueue.Peek() == ')' || firstQueue.Peek() == ']')
                {
                    isItBalanced = false;
                }
                else
                {
                    isItBalanced = true;
                }
            }
            else
            {
                isItBalanced = true;
            }
            return isItBalanced;
            
        }

        public static bool SecondComparingBrackets(Stack<char> firstQueue, char ch, bool isItBalanced)
        {
            if (firstQueue.Count == 0)
            {
                isItBalanced = false;
                
            }
            else if (ch == '}' && firstQueue.Peek() == '{')
            {
                isItBalanced = true;
            }
            else if (ch == ')' && firstQueue.Peek() == '(')
            {
                isItBalanced = true;
            }
            else if (ch == ']' && firstQueue.Peek() == '[')
            {
                isItBalanced = true;
            }
            else
            {
                isItBalanced = false;
                
            }

            return isItBalanced;
        }
    }
}
