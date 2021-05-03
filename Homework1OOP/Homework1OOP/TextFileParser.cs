using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Homework1OOP
{
    class TextFileParser : IParser<File>
    {
        private string pattern = @"\:(.*)\.|\)|\(|\;([^.]*)$";

        public string FileType { get => "Text"; }

        public File Parse(string input) 
        {
            string[] data = Regex.Split(input, pattern);

            TextFile textFile = new TextFile
            (
                data[1],
                data[2],
                data[3],
                data[5]
            );

            return textFile;
        }
    }
}
