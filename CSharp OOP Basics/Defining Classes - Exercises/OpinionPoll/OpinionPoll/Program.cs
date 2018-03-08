using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        var linesOfInput = int.Parse(Console.ReadLine());
        Family family = new Family();

        for (int i = 0; i < linesOfInput; i++)
        {
            var input = Console.ReadLine().Split(" ");
            var person = new Person(input[0], int.Parse(input[1]));
            family.AddMember(person);
        }

        var members = family.GetMembersOlderThan30();
        foreach (var member in members)
        {
            Console.WriteLine($"{member.Name} - {member.Age}");
        }
        


    }
}
