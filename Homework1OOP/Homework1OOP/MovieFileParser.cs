using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Homework1OOP
{
    class MovieFileParser : IParser<File>
    {
        private string pattern = @"\:(.*)\.|\)|\(|\;|\;([^.]*)$";

        public string FileType { get => "Movie"; }

        public File Parse(string input)
        {
            string[] data = Regex.Split(input, pattern);

            MovieFile movieFile = new MovieFile
            {
                Name = data[1],
                Extension = data[2],
                Size = data[3],
                Resolution = data[5],
                Duration = data[6]
            };

            return movieFile;
        }
    }
}
