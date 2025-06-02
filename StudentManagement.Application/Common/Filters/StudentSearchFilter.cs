using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Application.Common.Filters
{
    public class StudentSearchFilter : SearchFilter
    {
        public string? Name { get; set; }
        public int? Age { get; set; }
    }
}
