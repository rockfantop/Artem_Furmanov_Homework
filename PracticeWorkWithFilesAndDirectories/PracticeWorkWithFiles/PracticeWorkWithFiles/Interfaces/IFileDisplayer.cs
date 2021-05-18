using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeWorkWithFiles.Interfaces
{
    interface IFileDisplayer
    {
        string Path { get; set; } 

        void DisplayFiles();
    }
}
