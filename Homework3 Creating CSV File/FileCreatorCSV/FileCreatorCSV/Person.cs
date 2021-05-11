﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FileCreatorCSV
{
    public class Person : IEntity
    {
        public int Age { get; set; }

        public string EyeColor { get; set; }

        public string Name { get; set; }

        public string Gender { get; set; }

        public string Company { get; set; }

        public string Address { get; set; }

        public decimal? Salary { get; set; }
    }

}
