using PracticeWorkWithFiles.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeWorkWithFiles.Commands
{
    class PreviousDirectoryCommand : IFileCommand
    {
        private readonly IFileDisplayer fileDisplayer;

        public PreviousDirectoryCommand(IFileDisplayer displayer)
        {
            this.fileDisplayer = displayer;
        }

        public string Name => "cd ..";

        public void Do(string name = null)
        {
            if (this.fileDisplayer.Path != "C:\\")
            {
                List<string> list = new List<string>();

                list.AddRange(this.fileDisplayer.Path.Split("\\", StringSplitOptions.RemoveEmptyEntries));

                list.RemoveAt(list.Count - 1);

                this.fileDisplayer.Path = String.Join("\\", list.ToArray());

                this.fileDisplayer.Path = String.Concat(this.fileDisplayer.Path, "\\");

                this.fileDisplayer.DisplayFiles();
            }
            else
            {
                Console.WriteLine("Parent directory doesn`t exist");
            }
        }
    }
}
