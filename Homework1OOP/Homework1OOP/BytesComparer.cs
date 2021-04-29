using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Homework1OOP
{
    internal class BytesComparer
    {
        enum ByteTypes
        {
            B = 0,
            MB = 2,
            GB = 3
        }

        public int Compare(string first, string second)
        {
            long firstArgument = (long)Convert.ToInt32(Regex.Split(first, @"[A-Z]")[0]) * (long)Math.Pow(1024,
                (int)Enum.Parse(typeof(ByteTypes), Regex.Split(first, @"\d+(.*)$")[1]));

            long secondArgument = (long)Convert.ToInt32(Regex.Split(second, @"[A-Z]")[0]) * (long)Math.Pow(1024,
                (int)Enum.Parse(typeof(ByteTypes), Regex.Split(second, @"\d+(.*)$")[1]));

            if (firstArgument > secondArgument)
            {
                return 1;
            }
            if (firstArgument < secondArgument)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
}
