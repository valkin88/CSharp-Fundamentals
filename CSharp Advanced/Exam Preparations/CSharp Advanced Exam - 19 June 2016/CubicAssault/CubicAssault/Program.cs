using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace CubicAssault
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, long>> statistics = new Dictionary<string, Dictionary<string, long>>();

            var input = Console.ReadLine();

            while (input != "Count em all")
            {
                var splitInput = input.Split(new string[] { " -> " }, StringSplitOptions.RemoveEmptyEntries);

                string regionName = splitInput[0];
                string meteorType = splitInput[1];
                long count = long.Parse(splitInput[2]);

                if (!statistics.ContainsKey(regionName))
                {
                    statistics.Add(regionName, new Dictionary<string, long>());
                    statistics[regionName].Add("Black", 0);
                    statistics[regionName].Add("Red", 0);
                    statistics[regionName].Add("Green", 0);
                }
                statistics[regionName][meteorType] += count;

                if (statistics[regionName]["Green"] >= 0)
                {
                    long redCount = statistics[regionName]["Green"] / 1000000;
                    statistics[regionName]["Red"] += redCount;
                    statistics[regionName]["Green"] = statistics[regionName]["Green"] % 1000000;

                }
                if (statistics[regionName]["Red"] > 0)
                {
                    long blackCount = statistics[regionName]["Red"] / 1000000;
                    statistics[regionName]["Black"] += blackCount;
                    statistics[regionName]["Red"] = statistics[regionName]["Red"] % 1000000;

                }
                input = Console.ReadLine();
            }

            foreach (var item in statistics.OrderByDescending(x => x.Value["Black"]).
                ThenBy(x => x.Key.Length).
                ThenBy(x => x.Key))
            {
                Console.WriteLine(item.Key);
                foreach (var soldierType in item.Value.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                {
                    Console.WriteLine($"-> {soldierType.Key} : {soldierType.Value}");
                }
            }
        }
    }
}
