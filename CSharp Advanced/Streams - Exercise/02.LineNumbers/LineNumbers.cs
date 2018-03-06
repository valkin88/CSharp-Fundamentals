using System;
using System.IO;

namespace _02.LineNumbers
{
    class LineNumbers
    {
        static void Main(string[] args)
        {
            using (var reader = new StreamReader(@"D:\Projects\SoftUni Projects\CSharp Fundamentals\CSharp Advanced\Streams - Exercise\Resourses\text.txt"))
            {
                using (var writer = new StreamWriter("textOutput.txt"))
                {
                    string line = reader.ReadLine();
                    var lineCounter = 0;
                    while (line != null)
                    {
                        
                        writer.Write($"Line {lineCounter}: {line}");
                        writer.WriteLine();
                        line = reader.ReadLine();
                        lineCounter++;
                    }
                }
            }


        }
    }
}
