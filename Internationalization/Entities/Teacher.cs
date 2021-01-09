using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Internationalization
{
    public class Teacher : BaseEntity
    {
        public int Age { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
