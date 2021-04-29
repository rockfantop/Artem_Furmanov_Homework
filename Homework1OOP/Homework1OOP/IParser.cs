using System;
using System.Collections.Generic;
using System.Text;

namespace Homework1OOP
{
    interface IParser<T>
        where T : File
    {
        string FileType { get; }

        T Parse(string input);
    }
}
