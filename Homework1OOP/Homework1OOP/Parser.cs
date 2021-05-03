using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Homework1OOP
{
    internal class Parser
    {
        private Dictionary<string, IParser<File>> parsersDictionary = new Dictionary<string, IParser<File>>();

        private Dictionary<string, List<File>> filesDictionary = new Dictionary<string, List<File>>();

        public Parser()
        {

        }

        public void AddFileParser(IParser<File> parser)
        {
            parsersDictionary.Add(parser.FileType, parser);
            filesDictionary.Add(parser.FileType, new List<File>());
        }

        public Dictionary<string, List<File>> ParseFileText(string input)
        {
            foreach(var data in ValidateData(input))
            {
                string fileType = data.Split(':')[0];
                if (this.parsersDictionary.ContainsKey(fileType))
                {
                    filesDictionary[fileType].Add(this.parsersDictionary[fileType].Parse(data));
                }
                else
                {
                    throw new ArgumentException();
                }
            }

            return filesDictionary;
        }

        private string[] ValidateData(string input)
        {
            string pattern = String.Concat(@"((Text)|(Image)|(Movie)):(.*)",
                @"\.([a-z])+\(\d+(B|MB|GB|TB)\)",
                @"((\;(\d+)x(\d+))|(\;([a-zA-Z]|\ )+)|(\;\d+х\d+\;(\d+(h|m))+))");

            return Regex.Matches(input, pattern).Cast<Match>().Select(match => match.Value).ToArray();
        }
    }
}
