using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace Regeh
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"[[]\w+<(\d+)REGEH(\d+)>\w+[]]";
            Regex regex = new Regex(pattern);
            string result = String.Empty;
            List<int> listOfIndexes = new List<int>();
            foreach (Match match in regex.Matches(input))
            {

                listOfIndexes.Add(int.Parse(match.Groups[1].Value));
                listOfIndexes.Add(int.Parse(match.Groups[2].Value));
            }

            int sum = 0;
            for (int i = 0; i < listOfIndexes.Count; i++)
            {
                sum += listOfIndexes[i];

                if (sum > input.Length)
                {
                    sum %= input.Length - 1;

                }

                result += input[sum];

            }
            Console.WriteLine(result);
            
        }
    }
}
