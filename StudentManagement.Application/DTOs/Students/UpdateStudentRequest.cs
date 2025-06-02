using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Application.DTOs.Students
{
    public class UpdateStudentRequest
    {
        public int Id { get; set; }
        public UpdateStudentDto Dto { get; set; }
    }
}
