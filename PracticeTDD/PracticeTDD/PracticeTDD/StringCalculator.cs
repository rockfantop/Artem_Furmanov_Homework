using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeTDD
{
    public class StringCalculator
    {
        private string delimiter = ",";
        private int methodAddCalledCount = 0;

        public event Action<string, int> AddOccured = null;

        public int Add(string numbers)
        {
            this.methodAddCalledCount += 1;

            int sum = 0;

            if (!String.IsNullOrEmpty(numbers))
            {
                if (numbers.Length > 2 && numbers.Substring(0, 2) == "//")
                {
                    this.delimiter = numbers.Split(new string[] { "//", "\n" }, StringSplitOptions.RemoveEmptyEntries)[0];
                }

                string[] digits = numbers.Split(new string[] { delimiter, "\n", "//" }, StringSplitOptions.RemoveEmptyEntries);

                string exceptionMassage = "";
                bool isAnyNegative = false;

                foreach (var item in digits)
                {
                    if(int.Parse(item) > 1000)
                    {
                        continue;
                    }

                    if (int.Parse(item) < 0)
                    {
                        exceptionMassage += item + " ";

                        isAnyNegative = true;
                    }

                    sum += int.Parse(item);
                }

                if (isAnyNegative)
                {
                    throw new ArgumentException($"negatives not allowed - {exceptionMassage}");
                }

                this.AddOccured?.Invoke("Is working", sum);

                return sum;
            }
            else
            {
                this.AddOccured?.Invoke("Is working", sum);

                return sum;
            }
        }

        public int GetCalledCount()
        {
            return this.methodAddCalledCount;
        }

        public void SetAction(Action<string, int> action)
        {
            this.AddOccured = action;
        }
    }
}
