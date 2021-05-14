using System;

namespace ClassPractice3
{
    class Program
    {
        static void Main(string[] args)
        {
            var tasks = new Tasks();

            tasks.GetDividedNumber(125, 13);

            //tasks.ReadExponentialNumber();  

            //tasks.GetCurrentDate();

            //Console.WriteLine(tasks.ParseDate("2016 21-07"));

            //tasks.GetSumOfNumbersInString(Console.ReadLine());

            //tasks.FindSubString("asdfsadfasdf123213 asdasdasfasdfsad21324343543sdsdfsdfdf343453453");

            tasks.ValidatePassword("vasta");
        }
    }
}
