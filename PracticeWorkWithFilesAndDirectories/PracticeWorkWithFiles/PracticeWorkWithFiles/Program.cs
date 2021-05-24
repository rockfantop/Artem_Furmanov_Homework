using PracticeWorkWithFiles.Commands;
using System;
using System.IO;

namespace PracticeWorkWithFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileDisplayer = new FileDisplayer();

            var exitCommand = new ExitCommand();
            var openDirectoryCommand = new OpenDirectoryCommand(fileDisplayer);
            var previousCommand = new PreviousDirectoryCommand(fileDisplayer);
            var openFileCommand = new OpenFileCommand(fileDisplayer);

            var commandHandler = new CommandHandler();

            commandHandler.AddCommands(openFileCommand);
            commandHandler.AddCommands(openDirectoryCommand);
            commandHandler.AddCommands(previousCommand);
            commandHandler.AddCommands(exitCommand);

            var fileManager = new FileManager(commandHandler);

            fileManager.StartManaging();
        }
    }
}
