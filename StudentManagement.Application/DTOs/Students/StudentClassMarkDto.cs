using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Application.DTOs.Students
{
    public class StudentClassMarkDto
    {
        public int ClassId { get; set; }
        public string ClassName { get; set; } = null!;
        public decimal ExamMark { get; set; }
        public decimal AssignmentMark { get; set; }
        public decimal TotalMark => ExamMark + AssignmentMark;
    }
}
