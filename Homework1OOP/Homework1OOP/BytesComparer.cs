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

        private long ByteParser(string value)
        {
            return (long)Convert.ToInt32(Regex.Split(value, @"[A-Z]")[0]) * (long)Math.Pow(1024,
                (int)Enum.Parse(typeof(ByteTypes), Regex.Split(value, @"\d+(.*)$")[1]));
        }

        public int Compare(string first, string second)
        {
            long firstArgument = ByteParser(first);

            long secondArgument = ByteParser(second);

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
