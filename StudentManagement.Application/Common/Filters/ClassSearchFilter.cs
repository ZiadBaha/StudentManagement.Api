using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Application.Common.Filters
{
    public class ClassSearchFilter : SearchFilter
    {
        public string? Name { get; set; }
        public string? Teacher { get; set; }
    }
}
