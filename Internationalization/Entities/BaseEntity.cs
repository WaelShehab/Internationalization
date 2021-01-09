using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Internationalization
{
    public class BaseEntity
    {
        public string Id { get; set; }
        public Guid RowId { get; set; }

        public string Name { get; set; }
        public string NameSecondLanguage { get; set; }
    }
}
