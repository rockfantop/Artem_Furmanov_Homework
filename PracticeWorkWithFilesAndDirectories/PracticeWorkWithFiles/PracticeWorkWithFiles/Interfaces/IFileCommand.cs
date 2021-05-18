using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeWorkWithFiles.Interfaces
{
    interface IFileCommand
    {
        string Name { get; }

        void Do(string name = null);
    }
}
