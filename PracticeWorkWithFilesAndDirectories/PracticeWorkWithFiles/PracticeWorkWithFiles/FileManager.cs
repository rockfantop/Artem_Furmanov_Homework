using PracticeWorkWithFiles.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeWorkWithFiles
{
    class FileManager
    {
        private readonly ICommandHandler commandHandler;

        public FileManager(ICommandHandler handler)
        {
            this.commandHandler = handler;
        }

        public void StartManaging()
        {
            string input;
            while (true)
            {
                input = Console.ReadLine();

                Console.WriteLine();

                commandHandler.Execute(input);
            }
        }
    }
}
