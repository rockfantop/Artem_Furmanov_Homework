using System;
using System.Collections.Generic;
using System.Text;

namespace Homework1OOP
{
    internal class TextFile : File, IComparable<File>
    {
        public TextFile(string name, string extension, string size, string content) : base(name, extension, size)
        {
            this.Content = content;
        }

        public string Content { get; private set; }

        public override string ToString()
        {
            return base.ToString() + $"\t\tContent: {Content}\n";
        }
    }
}
