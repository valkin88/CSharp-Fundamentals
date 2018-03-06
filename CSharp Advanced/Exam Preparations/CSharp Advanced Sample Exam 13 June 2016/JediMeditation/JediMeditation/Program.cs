using System;
using System.Collections.Generic;
using System.Linq;

namespace JediMeditation
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            List<string> listOfMeditatingJedi = new List<string>();
            List<string> toshkoAndSlav = new List<string>();
            List<string> jediMasters = new List<string>();
            List<string> jediKnights = new List<string>();
            List<string> padawans = new List<string>();
            bool isItYoda = false;

            if (count != 0)
            {
                
                for (int i = 0; i < count; i++)
                {
                    var input = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                    for (int inputCounter = 0; inputCounter < input.Length; inputCounter++)
                    {
                        if (input[inputCounter].Contains("y"))
                        {
                            isItYoda = true;
                        }
                        else
                        {
                            char[] jedi = input[inputCounter].ToCharArray();
                            char jediType = jedi[0];

                            switch (jediType)
                            {
                                case 't': toshkoAndSlav.Add(input[inputCounter]); break;
                                case 's': toshkoAndSlav.Add(input[inputCounter]); break;
                                case 'm': jediMasters.Add(input[inputCounter]); break;
                                case 'k': jediKnights.Add(input[inputCounter]); break;
                                case 'p': padawans.Add(input[inputCounter]); break;

                            }
                        }
                    }
                }

                if (isItYoda == false)
                {

                    Console.Write(String.Join(" ", toshkoAndSlav));
                    Console.Write(" ");
                    Console.Write(String.Join(" ", jediMasters));
                    Console.Write(" ");
                    Console.Write(String.Join(" ", jediKnights));
                    Console.Write(" ");
                    Console.Write(String.Join(" ", padawans));
                    Console.WriteLine();
                }
                else
                {

                    Console.Write(String.Join(" ", jediMasters));
                    Console.Write(" ");
                    Console.Write(String.Join(" ", jediKnights));
                    Console.Write(" ");
                    Console.Write(String.Join(" ", toshkoAndSlav));
                    Console.Write(" ");
                    Console.Write(String.Join(" ", padawans));
                    Console.WriteLine();
                }

            }
        }
    }
}