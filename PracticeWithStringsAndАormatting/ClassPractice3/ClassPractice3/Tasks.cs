using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ClassPractice3
{
    class Tasks
    {

        public void PrintAllDigits(string input)
        {
            foreach(char charStr in input)
            {
                int num;

                if (int.TryParse(charStr.ToString(),out num))
                {
                    Console.Write(num);
                }
            }
            Console.WriteLine();
        }

        public void GetDividedNumber(double num1, double num2)
        {
            Console.WriteLine("Divided number: {0:f2}", num1/num2);
        }

        public void ReadExponentialNumber()
        {
            try
            {
                string input = Console.ReadLine();

                decimal number = Decimal.Parse(input, System.Globalization.NumberStyles.Float);

                Console.WriteLine(number);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void GetCurrentDate()
        {
            Console.WriteLine(DateTime.UtcNow.ToString("o"));
        }

        public DateTime ParseDate(string input)
        {
            return DateTime.ParseExact(input, "yyyy MM-dd", CultureInfo.InvariantCulture);
        }

        public void GetSumOfNumbersInString(string input)
        {
            int sum = 0;

            foreach (var num in input.Split(",", StringSplitOptions.RemoveEmptyEntries))
            {
                sum += Convert.ToInt32(num);
            }

            Console.WriteLine(sum);
        }

        public void FindSubString(string input)
        {
            string pattern = @"([a-zA-Z]+\d+)";

            MatchCollection matches = Regex.Matches(input, pattern);

            foreach(var match in matches)
            {
                Console.WriteLine(match.ToString());
            }
        }

        public void ValidatePassword(string password)
        {
            string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{6,10}$";

            MatchCollection matches = Regex.Matches(password, pattern);

            if (matches.Count == 0)
            {
                Console.WriteLine("Wrong Input!");
            }
            else
            {
                Console.WriteLine("Nice password!");
            }
        }

        public void ValidatePostCode(string code)
        {
            string pattern = @"(\d){3}-(\d){3}";

            MatchCollection matches = Regex.Matches(code, pattern);

            if (matches.Count == 0)
            {
                Console.WriteLine("Wrong Input!");
            }
            else
            {
                Console.WriteLine("Nice code!");
            }
        }

        public void ValidatePhoneNumber(string number)
        {
            string pattern = @"\+380-(\d){2}-(\d){3}-(\d){2}-(\d){2}";

            MatchCollection matches = Regex.Matches(number, pattern);

            if (matches.Count == 0)
            {
                Console.WriteLine("Wrong Input!");
            }
            else
            {
                Console.WriteLine("Nice number!");
            }
        }

        public void ReplacePhoneNumbers(string input)
        {
            string pattern = @"\+380-(\d){2}-(\d){3}-(\d){2}-(\d){2}";

            string format = "+XXX-XX-XXX-XX-XX";

            Console.WriteLine(new Regex(pattern).Replace(input, format));
        }

        public string[] NamesToUpper(string[] input)
        {
            List<string> result = new List<string>();

            foreach(var name in input)
            {
                string[] nameList = Regex.Split(name, @"\W");

                string[] spaces = Regex.Matches(name, @"\W").Cast<Match>().Select(match => match.Value).ToArray();

                string resultName = "";

                for (int i = 0; i < nameList.Length; i++)
                {
                    nameList[i] = String.Concat(nameList[i][0].ToString().ToUpper(), nameList[i].Substring(1));

                    if (i != nameList.Length - 1)
                    {
                        resultName = String.Concat(resultName, nameList[i] + spaces[i]);
                    }
                    else
                    {
                        resultName = String.Concat(resultName, nameList[i]);
                    }
                }

                result.Add(resultName);
            }

            return result.ToArray();
        }

        public void DecodeBase64String(string input)
        {
            Console.WriteLine(Encoding.UTF8.GetString(Convert.FromBase64String(input)));
        }
    }
}
