using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

namespace JediDreams
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfLines = int.Parse(Console.ReadLine());
            string methodNamesPattern = @"static\s+.*?\s+([a-zA-Z]*[A-Z]{1}[a-zA-Z]*)\s*\(";
            string invokedMethodsPattern = @"([a-zA-Z]*[A-Z]+[a-zA-Z]*)\s*\(";


            Dictionary<string, List<string>> allMethods = new Dictionary<string, List<string>>();

            Regex methodNamesRegex = new Regex(methodNamesPattern);
            Regex invokedMethodsRegex = new Regex(invokedMethodsPattern);
            string currentMethod = String.Empty;
            for (int i = 0; i < countOfLines; i++)
            {
                var input = Console.ReadLine();

                if (methodNamesRegex.IsMatch(input))
                {
                    Match methodDeclarationNamesMatch = methodNamesRegex.Match(input);
                    currentMethod = methodDeclarationNamesMatch.Groups[1].Value;
                    if (!allMethods.ContainsKey(currentMethod))
                    {
                        allMethods.Add(currentMethod, new List<string>());
                    }
                    
                }
                else if (invokedMethodsRegex.IsMatch(input) && currentMethod != String.Empty)
                {
                    MatchCollection invokedmethodDeclarationMatch = invokedMethodsRegex.Matches(input);

                    foreach (Match match in invokedmethodDeclarationMatch)
                    {
                        allMethods[currentMethod].Add(match.Groups[1].Value);
                    }
                    
                }

            }

            foreach (var method in allMethods.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
            {
                if (method.Value.Count == 0)
                {
                    Console.Write($"{method.Key} -> None");
                    Console.WriteLine();
                }
                else
                {
                    Console.Write($"{method.Key} -> {method.Value.Count} -> ");
                    Console.Write(String.Join(", ", method.Value.OrderBy(x => x)));
                    Console.WriteLine();
                }
                
            }
        }
    }
}
