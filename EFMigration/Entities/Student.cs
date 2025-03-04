using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFMigration.Entities
{
    public class Student
    {
        public int Id { get; set; }

        public string? FName { get; set; }

        public string? LName { get; set; }
        public ICollection<Section> Sections { get; set; }
    }
}
