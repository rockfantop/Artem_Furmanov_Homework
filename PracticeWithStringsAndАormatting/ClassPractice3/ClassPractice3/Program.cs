using System;

namespace ClassPractice3
{
    class Program
    {
        static void Main(string[] args)
        {
            var tasks = new Tasks();

            tasks.GetDividedNumber(125, 13);

            tasks.ReadExponentialNumber();

            tasks.GetCurrentDate();

            Console.WriteLine(tasks.ParseDate("2016 21-07"));

            tasks.GetSumOfNumbersInString(Console.ReadLine());

            tasks.FindSubString("asdfsadfasdf123213 asdasdasfasdfsad21324343543sdsdfsdfdf343453453");

            tasks.ValidatePassword("vasta");

            tasks.ReplacePhoneNumbers("+380-98-123-45-67 vasya +380-95-381-00-49");

            string[] names = { "vasya petin", "petro kvitka-jolud" };

            names = tasks.NamesToUpper(names);

            tasks.DecodeBase64String("0JXRgdC70Lgg0YLRiyDRh9C40YLQsNC10YjRjCDRjdGC0L7RgiDRgtC10LrRgdGCLCDQt9C90LDRh9C40YIg0LfQsNC00LDQvdC40LUg0LLRi9C/0L7Qu9C90LXQvdC+INCy0LXRgNC90L4gOik=");

            double[] numbers = { 1.2, 2.3, 1, 0.3, 5};
            
            var quickSort = new QuickSort<double>();

            quickSort.quickSort(numbers, 0, numbers.Length - 1);

            foreach(var numb in numbers)
            {
                Console.WriteLine(numb);
            }
        }
    }
}
