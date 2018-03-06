using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _03.WordCount
{
    class WordCount
    {
        static void Main(string[] args)
        {
            using (var wordsReader = new StreamReader(@"D:\Projects\SoftUni Projects\CSharp Fundamentals\CSharp Advanced\Streams - Exercise\Resourses\words.txt"))
            {
                using (var textReader = new StreamReader(@"D:\Projects\SoftUni Projects\CSharp Fundamentals\CSharp Advanced\Streams - Exercise\Resourses\text.txt"))
                {
                    using (var writer = new StreamWriter("results.txt"))
                    {
                        Dictionary<string, int> wordsDictionary = WordReader(wordsReader);

                        TextReader(textReader, wordsDictionary);

                        wordsDictionary = Printer(writer, wordsDictionary);
                    }
                }
            }
        }

        private static Dictionary<string, int> Printer(StreamWriter writer, Dictionary<string, int> wordsDictionary)
        {
            wordsDictionary = wordsDictionary.OrderByDescending(w => w.Value).ToDictionary(x => x.Key, x => x.Value);
            foreach (KeyValuePair<string, int> pair in wordsDictionary)
            {
                writer.WriteLine($"{pair.Key} - {pair.Value}");

            }

            return wordsDictionary;
        }

        private static void TextReader(StreamReader textReader, Dictionary<string, int> wordsDictionary)
        {
            string line = null;
            while ((line = textReader.ReadLine()) != null)
            {
                foreach (var word in line.ToLower().Split(new[] { ' ', '.', ',', '-', '?', '!' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    if (wordsDictionary.ContainsKey(word))
                    {
                        wordsDictionary[word]++;
                    }
                }
            }
        }

        private static Dictionary<string, int> WordReader(StreamReader wordsReader)
        {
            var wordsDictionary = new Dictionary<string, int>();
            var wordRead = wordsReader.ReadLine().ToLower();

            while (wordRead != null)
            {
                wordsDictionary[wordRead] = 0;
                wordRead = wordsReader.ReadLine();
            }

            return wordsDictionary;
        }
    }
}


