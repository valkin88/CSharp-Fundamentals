using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Cubic_Messages
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();



            while (input != "Over!")
            {
                
                var n = int.Parse(Console.ReadLine());

                var pattern = $@"(.+)([a-zA-Z]{{{n}}})(\S*)";

                var regex = new Regex(pattern);
                bool isValidLastGroup = true;
                bool isValidFirstGroup = true;
                var firstGroup = string.Empty;
                var lastGroup = string.Empty;
                var middleGroup = string.Empty;
                var result = string.Empty;
                foreach (Match item in regex.Matches(input))
                {
                    firstGroup = item.Groups[1].Value;
                    lastGroup = item.Groups[3].Value;
                    middleGroup = item.Groups[2].Value;
                    result = middleGroup;
                    foreach (var letter in firstGroup)
                    {
                        if (!Char.IsDigit(letter))
                        {
                            isValidFirstGroup = false;
                            break;
                        }
                    }

                    if (isValidLastGroup == true)
                    {
                        foreach (var letter in lastGroup)
                        {
                            if (Char.IsLetter(letter))
                            {
                                isValidLastGroup = false;
                                break;
                            }
                        }
                    }

                }
                if (isValidLastGroup && isValidFirstGroup)
                {
                    var lastGroupDigits = string.Empty;
                    foreach (var item in lastGroup)
                    {
                        if (Char.IsDigit(item))
                        {
                            lastGroupDigits += item;
                        }
                    }
                    var indexes = firstGroup + lastGroupDigits;
                    Console.Write($"{result} == ");
                    for (int i = 0; i < indexes.Length; i++)
                    {
                        if (int.Parse(indexes[i].ToString()) <= middleGroup.Length - 1)
                        {
                            Console.Write(middleGroup[int.Parse(indexes[i].ToString())]);
                        }
                        else
                        {
                            Console.Write(" ");
                        }

                    }
                    Console.WriteLine();

                }
                input = Console.ReadLine();
            }
        }
    }
}