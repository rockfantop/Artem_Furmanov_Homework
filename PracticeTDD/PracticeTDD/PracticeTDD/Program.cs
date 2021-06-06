using System;

namespace PracticeTDD
{
    class Program
    {
        static void Main(string[] args)
        {
            StringCalculator stringCalculator = new StringCalculator();

            Console.WriteLine(stringCalculator.GetCalledCount());
        }
    }
}
