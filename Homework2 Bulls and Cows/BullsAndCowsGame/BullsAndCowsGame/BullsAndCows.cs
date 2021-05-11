using System;
using System.Collections.Generic;
using System.Text;

namespace BullsAndCowsGame
{
    class BullsAndCows
    {
        private List<string> listOfAnswers = new List<string>();

        private void GenerateListOfAllAnswers(int size)
        {
            int lowerBound = 0;

            int upperBound = (int)Math.Pow(10, size) - 1;

            for (; lowerBound <= upperBound; lowerBound++)
            {
                string currentNumber = lowerBound.ToString();

                if (lowerBound <= (int)Math.Pow(10, size - 1) - 1)
                {
                    for (int i = currentNumber.Length; i < size; i++)
                    {
                        currentNumber = "0" + currentNumber;
                    }
                }

                listOfAnswers.Add(currentNumber);
            }
        }

        private bool IsSimilar(string currentDigit, string guessedDigit, int bulls, int cows)
        {
            string tempGuessed = "";
            string tempCurrent = "";
            for (int i = 0; i < guessedDigit.Length; i++)
            {
                if (guessedDigit[i] == currentDigit[i])
                {
                    tempGuessed += "x";
                    tempCurrent += "w";
                    bulls--;
                }
                else
                {
                    tempGuessed += guessedDigit[i];
                    tempCurrent += currentDigit[i];
                }
            }
            guessedDigit = tempGuessed;
            currentDigit = tempCurrent;
            for (int i = 0; i < currentDigit.Length; i++)
            {
                int index = guessedDigit.IndexOf(currentDigit[i]);
                if (index >= 0)
                {
                    cows--;
                }
            }
            return (bulls == 0) && (cows == 0);
        }

        private void FilterOutNumbers(int bulls, int cows, string currentDigit)
        {
            for(int i = 0; i < listOfAnswers.Count; i++)
            {
                if (!IsSimilar(currentDigit, listOfAnswers[i], bulls, cows))
                {
                    listOfAnswers.RemoveAt(i);
                    i--;
                }
            }
        }

        public void StartGame()
        {
            Console.Write("\tBulls and Cows\n\nPlease, enter number of digits: ");

            int size = 0;
            int bulls = 0;
            int cows = 0;

            string currentDigit = "";

            try
            {
                size = int.Parse(Console.ReadLine());

                GenerateListOfAllAnswers(size);

                Console.WriteLine($"Range from {listOfAnswers[0]} to {listOfAnswers[listOfAnswers.Count - 1]}");

                while (bulls != size || listOfAnswers.Count == 0)
                {
                    currentDigit = listOfAnswers[new Random().Next(0, listOfAnswers.Count)];

                    Console.WriteLine(currentDigit);

                    Console.Write("Bulls: ");

                    bulls = int.Parse(Console.ReadLine());

                    Console.Write("Cows: ");

                    cows = int.Parse(Console.ReadLine());

                    FilterOutNumbers(bulls, cows, currentDigit);
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Incorrect input! Please try again.");
            }

            if (bulls == size)
            {
                Console.WriteLine($"Congratulation! Your magic number is {currentDigit}");
            }
            else
            {
                Console.WriteLine("Game over");
            }
        }
    }
}
