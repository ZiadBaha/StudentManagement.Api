using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Domain.Models
{
    public class Class
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Teacher { get; set; } = null!;
        public string Description { get; set; } = null!;
    }
}
