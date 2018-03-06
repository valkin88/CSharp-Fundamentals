using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace JediCode_X
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfMessages = int.Parse(Console.ReadLine());
            StringBuilder fullMessage = new StringBuilder();
            List<string> jediNames = new List<string>();
            List<string> jediMessages = new List<string>();

            for (int i = 0; i < countOfMessages; i++)
            {
                string inputMessage = Console.ReadLine();
                fullMessage.Append(inputMessage);
            }

            string patternJediName = Console.ReadLine();
            string patternMessage = Console.ReadLine();
            int countNameLenght = patternJediName.Length;
            int countMessageLenght = patternMessage.Length;

            string namePattern = Regex.Escape(patternJediName) + $@"([a-zA-Z]{{{countNameLenght}}})(?![a-zA-Z])";
            string messagePattern = Regex.Escape(patternMessage) + $@"([a-zA-Z0-9]{{{countMessageLenght}}})(?![a-zA-Z0-9])";

            Regex regexNames = new Regex(namePattern);
            Regex regexMessages = new Regex(messagePattern);


            foreach (Match match in regexNames.Matches(fullMessage.ToString()))
            {
                jediNames.Add(match.Groups[1].Value);

            }
            foreach (Match match in regexMessages.Matches(fullMessage.ToString()))
            {
                jediMessages.Add(match.Groups[1].Value);

            }

            var indexes = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            int currentIndex = 0;
            for(int d = 0; d < indexes.Count; d++)
            {
                if (indexes[d] - 1 < jediMessages.Count())
                {
                    Console.WriteLine($"{jediNames[currentIndex]} - {jediMessages[indexes[d] - 1]}");
                    currentIndex++;
                }
                if (currentIndex >= jediNames.Count())
                {
                    break;
                }
            }
        }
    }
}
