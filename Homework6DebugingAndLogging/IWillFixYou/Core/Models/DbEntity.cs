using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
    public abstract class DbEntity
    {
        public Guid Id { get; set; }
    }
}
