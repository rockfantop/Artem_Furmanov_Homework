using PracticeWorkWithFiles.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PracticeWorkWithFiles.Commands
{
    class OpenDirectoryCommand : IFileCommand
    {
        private readonly IFileDisplayer fileDisplayer;

        public OpenDirectoryCommand(IFileDisplayer displayer)
        {
            this.fileDisplayer = displayer;
        }

        public string Name => "cd";

        public void Do(string name = null)
        {
            List<string> list = new List<string>();

            list.AddRange(name.Split(" "));

            list.RemoveAt(0);

            string newPath = String.Concat(this.fileDisplayer.Path, String.Join(" ", list.ToArray()), "\\");

            if (Directory.Exists(newPath))
            {
                this.fileDisplayer.Path = newPath;
                this.fileDisplayer.DisplayFiles();
            }
            else
            {
                Console.WriteLine("No such Directory!");
                Console.WriteLine();
            }
        }
    }
}
