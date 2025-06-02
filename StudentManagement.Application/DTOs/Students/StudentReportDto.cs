using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Application.DTOs.Students
{
    public class StudentReportDto
    {
        public int StudentId { get; set; }
        public string FullName { get; set; } = null!;
        public List<StudentClassMarkDto> ClassMarks { get; set; } = new();
        public decimal OverallAverageMark { get; set; }
    }
}
