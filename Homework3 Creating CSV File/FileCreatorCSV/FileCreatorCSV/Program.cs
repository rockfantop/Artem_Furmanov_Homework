using System;

namespace FileCreatorCSV
{
    class Program
    {
        static void Main(string[] args)
        {
            var personList = PersonList.GetListPerson();

            var fileGeneratorCSV = new FileGeneratorCSV();

            fileGeneratorCSV.SetFileType(typeof(Person));
            fileGeneratorCSV.SetData(personList);
            fileGeneratorCSV.SetProperties();

            fileGeneratorCSV.CreateFile();
        }
    }
}
