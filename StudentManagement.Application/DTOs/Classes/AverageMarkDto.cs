using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Application.DTOs.Classes
{
    public class AverageMarkDto
    {
        public int ClassId { get; set; }
        public string ClassName { get; set; } = null!;
        public decimal AverageMark { get; set; }
    }

}
