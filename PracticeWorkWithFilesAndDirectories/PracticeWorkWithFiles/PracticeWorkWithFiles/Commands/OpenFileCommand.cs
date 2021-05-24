using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PracticeWorkWithFiles.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace PracticeWorkWithFiles.Commands
{
    class OpenFileCommand : IFileCommand
    {
        private readonly IFileDisplayer fileDisplayer;

        public OpenFileCommand(IFileDisplayer displayer)
        {
            this.fileDisplayer = displayer;
        }

        public string Name => ".";

        private void JsonDisplayer(string name)
        {
            using (StreamReader file = File.OpenText(String.Concat(this.fileDisplayer.Path, "\\", name)))
            {
                using (JsonTextReader reader = new JsonTextReader(file))
                {
                    JObject o2 = (JObject)JToken.ReadFrom(reader);
                    Console.WriteLine(o2.ToString());
                }
            }
            Console.WriteLine();
        }

        private void XmlDisplayer(string name)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(String.Concat(this.fileDisplayer.Path, "\\", name));

            xmlDocument.Save(Console.Out);

            Console.WriteLine();
            Console.WriteLine();
        }

        private void TxtDisplayer(string name)
        {
            Console.WriteLine(File.ReadAllText(String.Concat(this.fileDisplayer.Path, "\\", name)));

            Console.WriteLine();
        }

        private void FileDisplayBinary(string name)
        {
            byte[] fileBytes = File.ReadAllBytes(String.Concat(this.fileDisplayer.Path, "\\", name));

            foreach (var fileByte in fileBytes)
            {
                Console.Write(fileByte.ToString());
            }

            Console.WriteLine();
            Console.WriteLine();
        }

        public void Do(string name = null)
        {
            if (File.Exists(String.Concat(this.fileDisplayer.Path, "\\", name)))
            {
                var format = name.Split(".");

                switch (format[format.Length - 1])
                {
                    case "xml":
                        XmlDisplayer(name);
                        break;
                    case "json":
                        JsonDisplayer(name);
                        break;
                    case "txt":
                        TxtDisplayer(name);
                        break;
                    default:
                        FileDisplayBinary(name);
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input");

                Console.WriteLine();
            }
        }
    }
}
