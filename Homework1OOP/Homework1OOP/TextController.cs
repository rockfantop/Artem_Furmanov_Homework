using System;
using System.Collections.Generic;
using System.Text;

namespace Homework1OOP
{
    class TextController
    {
        public void PrintFiles(Dictionary<string, List<File>> filesDictionary)
        {
            foreach(var element in filesDictionary)
            {
                Console.WriteLine(element.Key);

                File[] files = element.Value.ToArray();

                Array.Sort(files);

                foreach(var file in files)
                {
                    Console.WriteLine(file.ToString());
                }
            }
        }
    }
}
