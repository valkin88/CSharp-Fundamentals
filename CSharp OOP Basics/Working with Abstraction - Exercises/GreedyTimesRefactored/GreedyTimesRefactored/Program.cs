using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        long bagCapacity = long.Parse(Console.ReadLine());
        string[] items = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        var bag = new Dictionary<string, Dictionary<string, long>>();

        long totalGold = 0;
        long totalGems = 0;
        long totalCash = 0;

        for (int i = 0; i < items.Length; i += 2)
        {
            string nameOfItem = items[i];
            long quantityOfItem = long.Parse(items[i + 1]);

            string itemType = GetItemType(nameOfItem);

            if (itemType == "")
            {
                continue;
            }
            else if (bagCapacity < bag.Values.Select(x => x.Values.Sum()).Sum() + quantityOfItem)
            {
                continue;
            }

            switch (itemType)
            {
                case "Gem":
                    if (!CanAddItem(bag, quantityOfItem, "Gold", itemType))
                    {
                        continue;
                    }
                    break;
                case "Cash":
                    if (!CanAddItem(bag, quantityOfItem, "Gem", itemType))
                    {
                        continue;
                    }
                    break;
            }

            AddInBag(bag, nameOfItem, quantityOfItem, itemType);

            IncreaseAmountOfItems(ref totalGold, ref totalGems, ref totalCash, quantityOfItem, itemType);
        }

        PrintResult(bag);
    }

    private static void PrintResult(Dictionary<string, Dictionary<string, long>> bag)
    {
        foreach (var x in bag)
        {
            Console.WriteLine($"<{x.Key}> ${x.Value.Values.Sum()}");
            foreach (var z in x.Value.OrderByDescending(y => y.Key).ThenBy(y => y.Value))
            {
                Console.WriteLine($"##{z.Key} - {z.Value}");
            }
        }
    }

    private static void IncreaseAmountOfItems(ref long totalGold, ref long totalGems, ref long totalCash, long quantityOfItem, string itemType)
    {
        if (itemType == "Gold")
        {
            totalGold += quantityOfItem;
        }
        else if (itemType == "Gem")
        {
            totalGems += quantityOfItem;
        }
        else if (itemType == "Cash")
        {
            totalCash += quantityOfItem;
        }
    }

    private static void AddInBag(Dictionary<string, Dictionary<string, long>> bag, string nameOfItem, long quantityOfItem, string itemType)
    {
        if (!bag.ContainsKey(itemType))
        {
            bag[itemType] = new Dictionary<string, long>();
        }

        if (!bag[itemType].ContainsKey(nameOfItem))
        {
            bag[itemType][nameOfItem] = 0;
        }

        bag[itemType][nameOfItem] += quantityOfItem;
    }

    private static bool CanAddItem(Dictionary<string, Dictionary<string, long>> bag, long quantityOfItem,string otherType, string itemType)
    {
        if (!bag.ContainsKey(itemType))
        {
            if (bag.ContainsKey(otherType))
            {
                if (quantityOfItem > bag[otherType].Values.Sum())
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        else if (bag[itemType].Values.Sum() + quantityOfItem > bag[otherType].Values.Sum())
        {
            return false;
        }
        return true;
    }

    private static string GetItemType(string nameOfItem)
    {
        string itemType = string.Empty;

        if (nameOfItem.Length == 3)
        {
            itemType = "Cash";
        }
        else if (nameOfItem.ToLower().EndsWith("gem"))
        {
            itemType = "Gem";
        }
        else if (nameOfItem.ToLower() == "gold")
        {
            itemType = "Gold";
        }

        return itemType;
    }
}
