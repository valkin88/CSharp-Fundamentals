using System;
using System.IO;

namespace _01.OddLines
{
    class OddLines
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader(@"D:\Projects\SoftUni Projects\CSharp Fundamentals\CSharp Advanced\Streams - Exercise\Resourses\text.txt");
            using (reader)
            {
                int lineNumber = 0;
                string line = reader.ReadLine();
                while (line!=null)
                {
                    lineNumber++;
                    if (lineNumber%2 == 0)
                    {
                        Console.WriteLine($"{line}");
                    }
               
                    line = reader.ReadLine();
                }
            }
        }
    }
}
