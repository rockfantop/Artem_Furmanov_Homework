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
            (
                data[1],
                data[2],
                data[3],
                data[5],
                data[6]
            );

            return movieFile;
        }
    }
}
