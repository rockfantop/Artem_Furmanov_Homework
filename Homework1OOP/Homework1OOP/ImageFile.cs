using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Homework1OOP
{
    internal class ImageFile : File, IComparable<File>
    {
        public ImageFile()
        {

        }

        public ImageFile(string name, string extension, string size, string resolution) : base(name, extension, size)
        {
            this.Resolution = resolution;
        }

        public string Resolution { get; set; }

        public override string ToString()
        {
            return base.ToString() + $"\t\tResolution: {Resolution}\n";
        }
    }
}
