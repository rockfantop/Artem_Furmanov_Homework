using BLL.Abstractions.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.ModelsDTO
{
    public class UserDTO : IDTOModel
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }
    }
}
