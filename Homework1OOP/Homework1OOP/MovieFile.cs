using System;
using System.Collections.Generic;
using System.Text;

namespace Homework1OOP
{
    internal class MovieFile : File, IComparable<File>
    {
        public MovieFile()
        {
            
        }

        public MovieFile(string name, string extension, string size, string resolution, string duration) : base(name, extension, size)
        {
            this.Resolution = resolution;
            this.Duration = duration;
        }

        public string Resolution { get; set; }

        public string Duration { get; set; }

        public override string ToString()
        {
            return base.ToString() + 
                $"\t\tResolution: {Resolution}\n" +
                $"\t\tDuration: {Duration}\n";
        }
    }
}
