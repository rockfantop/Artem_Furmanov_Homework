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
                (
                    data[1],
                    data[2],
                    data[3],
                    data[5]
                );

                return imageFile;
        }
    }
}
