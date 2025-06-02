using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Application.DTOs.Classes
{
    public class CreateClassDto
    {
        public string Name { get; set; } = null!;
        public string Teacher { get; set; } = null!;
        public string Description { get; set; } = null!;
    }

}
