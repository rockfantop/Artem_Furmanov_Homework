using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HomeworkQueriesLINQ
{
    class QuiriesWithDigitsAndStrings
    {
        public void PrintDigits()
        {
            Enumerable.Range(10, 41).ToList().ForEach(x => { Console.Write(x + ", "); });
            Console.WriteLine();
        }

        public void PrintDigitsDivisibleBy3()
        {
            Enumerable.Range(10, 41).Where(x => x % 3 == 0).ToList().ForEach(x => { Console.Write(x + ", "); });
            Console.WriteLine();
        }

        public void PrintWord()
        {
            Enumerable.Repeat("LINQ", 10).ToList().ForEach(x => { Console.Write(x + " "); });
            Console.WriteLine();
        }

        public void PrintAllStringsWithA(string input)
        {
            input.Split(";", StringSplitOptions.RemoveEmptyEntries).Where(x => x.Contains("a"))
                .ToList().ForEach(x => { Console.Write(x + " "); });
            Console.WriteLine();
        }

        public void PrintAllStringsAndCountOfA(string input)
        {
            input.Split(";", StringSplitOptions.RemoveEmptyEntries).ToList()
                .ForEach(x => Console.WriteLine($"\"{x}\" has {x.Count(y => y == 'a')} letter of 'a', "));
            Console.WriteLine();
        }

        public void IsWordExist(string input, string word)
        {
            input.Split(";", StringSplitOptions.RemoveEmptyEntries).ToList()
                .ForEach(x => Console.WriteLine($"\"{x}\" has word \"{word}\" - {x.Contains(word)}"));
            Console.WriteLine();
        }

        public void PrintLongestString(string input)
        {
            Console.WriteLine(input.Split(";", StringSplitOptions.RemoveEmptyEntries).OrderByDescending(x => x.Length).First());
        }

        public void PrintAverageLenghtOfString(string input)
        {
            Console.WriteLine(input.Split(";", StringSplitOptions.RemoveEmptyEntries).Average(x => x.Trim().Length));
        }

        public void PrintShortestStringReverse(string input)
        {
            Console.WriteLine(new string(input.Split(";", StringSplitOptions.RemoveEmptyEntries).OrderByDescending(x => x.Length)
                .Last().Reverse().ToArray()));
        }

        public void PrintStringsStartsAEndsB(string input)
        {
            input.Split(";", StringSplitOptions.RemoveEmptyEntries).ToList()
                .ForEach(x => Console.WriteLine(String.Concat($"\"{x.Trim()}\" starts 'aa' and ends 'b' - ",
                $"{x.Trim()[0] == 'a' && x.Trim()[1] == 'a' && x.Trim().Substring(2).All(y => y == 'b')}")));
        }

        public void PrintLastInSequence(string input)
        {
            Console.WriteLine(input.Split(";", StringSplitOptions.RemoveEmptyEntries)
                .Where(x => x[x.Length - 2] == 'b' && x[x.Length - 1] == 'b')
                .Skip(2).LastOrDefault());
        }
    }
}
