using System;
using System.Collections.Generic;
using System.Linq;

class StartUp
{
    static void Main(string[] args)
    {
        List<int> listOfStones = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

        Lake lakeList = new Lake(listOfStones);

        Console.WriteLine(string.Join(", ", lakeList));
    }
}
