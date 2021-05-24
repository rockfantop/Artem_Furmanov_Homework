using PracticeWorkWithFiles.Commands;
using PracticeWorkWithFiles.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeWorkWithFiles
{
    class CommandHandler : ICommandHandler
    {
        private Dictionary<string, IFileCommand> commands = new Dictionary<string, IFileCommand>();

        public void AddCommands(IFileCommand command)
        {
            this.commands.Add(command.Name, command);
        }

        public void Execute(string command)
        {
            string dictionaryCommand = "";

            foreach(var cmd in this.commands.Keys)
            {
                if (command.Contains(cmd))
                {
                    dictionaryCommand = cmd;
                }
            }

            try
            {
                this.commands[dictionaryCommand].Do(command);
            }
            catch (Exception)
            {
                Console.WriteLine("Wrong input, try again.");
            }
        }
    }
}
