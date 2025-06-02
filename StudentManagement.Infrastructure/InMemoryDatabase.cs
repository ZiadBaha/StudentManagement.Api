using StudentManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Infrastructure
{
    public class InMemoryDatabase
    {
        public List<Student> Students { get; set; } = new List<Student>();
        public List<Class> Classes { get; set; } = new List<Class>();
        public List<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
        public List<Mark> Marks { get; set; } = new List<Mark>();
    }

}
