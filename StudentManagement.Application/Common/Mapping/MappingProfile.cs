using AutoMapper;
using StudentManagement.Application.DTOs.Classes;
using StudentManagement.Application.DTOs.Enrollments;
using StudentManagement.Application.DTOs.Marks;
using StudentManagement.Application.DTOs.Students;
using StudentManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Application.Common.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Students
            CreateMap<Student, StudentDto>().ReverseMap();
            CreateMap<Student, CreateStudentDto>().ReverseMap();
            CreateMap<Student, UpdateStudentDto>().ReverseMap();

            // Classes
            CreateMap<Class, ClassDto>().ReverseMap();
            CreateMap<Class, CreateClassDto>().ReverseMap();

            // Enrollment
            CreateMap<Enrollment, EnrollmentDto>().ReverseMap();
            CreateMap<Enrollment, CreateEnrollmentDto>().ReverseMap();

            // Marks
            CreateMap<Mark, MarkDto>().ReverseMap();
            CreateMap<Mark, CreateMarkDto>().ReverseMap();

            // StudentClassMarkDto and AverageMarkDto
        }
    }
}
