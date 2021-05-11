using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace FileCreatorCSV
{
    class FileGeneratorCSV
    {
        private List<string> inputProperties = new List<string>();

        private Type fileType;

        private IEnumerable<IEntity> data;


        public void SetFileType(Type type)
        {
            this.fileType = type;
        }

        public void SetData(IEnumerable<IEntity> data)
        {
            this.data = data;
        }

        public void SetProperties()
        {
            string[] properties = Console.ReadLine().Split(",", StringSplitOptions.RemoveEmptyEntries);
            
            foreach (var property in properties)
            {
                if (fileType.GetProperty(property.Trim()) != null)
                {
                    this.inputProperties.Add(property.Trim());
                }
            }
        }

        public void CreateFile()
        {
            try
            {
                using (StreamWriter streamWriter = new StreamWriter("..//..//..//file.csv", false, System.Text.Encoding.Default))
                {
                    foreach(var property in inputProperties)
                    {
                        streamWriter.Write(property + ",");
                    }

                    foreach (var entity in data)
                    {
                        streamWriter.WriteLine();

                        foreach (var property in inputProperties)
                        {
                            var temp = entity.GetType().GetProperty(property).GetValue(entity, null);
                            if (temp is decimal d)
                            {
                                streamWriter.Write(d.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + ",");
                            }
                            else if (temp == null ? false : temp.ToString().Contains(','))
                            {
                                streamWriter.Write($"\"{temp.ToString()}\"" + ",");
                            }
                            else
                            {
                                streamWriter.Write(temp + ",");
                            }
                        }
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
