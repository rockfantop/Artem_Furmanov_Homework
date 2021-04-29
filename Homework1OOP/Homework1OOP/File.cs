using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Homework1OOP
{
    internal abstract class File : IComparable<File>
    {
        public File()
        {
                
        }

        public File(string name, string extension, string size)
        {
            this.Name = name;
            this.Extension = extension;
            this.Size = size;
        }

        public string Name { get; set; }

        public string Extension { get; set; }

        public string Size { get; set; }

        public int CompareTo([AllowNull] File other)
        {
            if (other != null)
            {
                BytesComparer comparer = new BytesComparer();
                return comparer.Compare(this.Size, other.Size);
            }
            else
            {
            throw new NotImplementedException();
            }
        }

        public override string ToString()
        {
            return $"\t{Name}.{Extension}\n" +
                $"\t\tExtension: {Extension}\n" +
                $"\t\tSize: {Size}\n";
        }
    }
}
