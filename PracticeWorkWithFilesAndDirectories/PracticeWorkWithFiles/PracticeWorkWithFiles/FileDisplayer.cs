using PracticeWorkWithFiles.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PracticeWorkWithFiles
{
    class FileDisplayer : IFileDisplayer
    {
        public FileDisplayer()
        {
            DisplayFiles();
        }

        public string Path { get; set; } = @"C:\";

        public void DisplayFiles()
        {
            List<string> directories = default;
            List<string> files = default;

            try
            {
                directories = new List<string>(Directory.GetDirectories(Path));
                files = new List<string>(Directory.GetFiles(Path));
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine($"Cannot get access to this folder - caused by {ex.Message}");
            }

            foreach (var directory in directories)
            {
                Console.WriteLine(directory);
            }

            foreach (var file in files)
            {
                Console.WriteLine(file);
            }

            Console.WriteLine();
        }
    }
}
