using PracticeWorkWithFiles.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace PracticeWorkWithFiles.Commands
{
    class ExitCommand : IFileCommand
    {
        public string Name => "exit";

        public void Do(string name = null)
        {
            Environment.Exit(0);
        }
    }
}
