using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
    public class User : DbEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }
    }
}
