using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Homework1OOP
{
    class ImageFileParser : IParser<File>
    {
        private string pattern = @"\:(.*)\.|\)|\(|\;([^.]*)$";

        public string FileType { get => "Image"; }

        public File Parse(string input)
        {
            string[] data = Regex.Split(input, pattern);

                ImageFile imageFile = new ImageFile
                {
                    Name = data[1],
                    Extension = data[2],
                    Size = data[3],
                    Resolution = data[5]
                };

                return imageFile;
        }
    }
}
