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
            {
                Name = data[1],
                Extension = data[2],
                Size = data[3],
                Content = data[5]
            };

            return textFile;
        }
    }
}
