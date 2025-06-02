using AutoMapper;
using Microsoft.EntityFrameworkCore.InMemory.Storage.Internal;
using StudentManagement.Application.Common.Filters;
using StudentManagement.Application.Common.Responses;
using StudentManagement.Application.DTOs.Students;
using StudentManagement.Application.Interfaces;
using StudentManagement.Domain.Models;
using StudentManagement.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly StudentManagement.Infrastructure.InMemoryDatabase _db;
        private readonly IMapper _mapper;

        public StudentService(StudentManagement.Infrastructure.InMemoryDatabase db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<ApiResponse<StudentDto>> CreateStudentAsync(CreateStudentDto dto)
        {
            var student = _mapper.Map<Student>(dto);
            student.Id = _db.Students.Any() ? _db.Students.Max(s => s.Id) + 1 : 1;
            _db.Students.Add(student);
            var result = _mapper.Map<StudentDto>(student);
            return new ApiResponse<StudentDto>(result);
        }

        public async Task<ApiResponse<IEnumerable<StudentDto>>> GetAllStudentsAsync(StudentSearchFilter filter)
        {
            var query = _db.Students.AsQueryable();

            if (!string.IsNullOrEmpty(filter.Name))
            {
                query = query.Where(s => s.FirstName.Contains(filter.Name) || s.LastName.Contains(filter.Name));
            }

            if (filter.Age.HasValue)
            {
                query = query.Where(s => s.Age == filter.Age.Value);
            }

            var students = query
                .Skip(filter.Skip)
                .Take(filter.PageSize)
                .ToList();

            var result = _mapper.Map<IEnumerable<StudentDto>>(students);
            return new ApiResponse<IEnumerable<StudentDto>>(result);
        }

        public async Task<ApiResponse<StudentDto>> UpdateStudentAsync(int id, UpdateStudentDto dto)
        {
            var student = _db.Students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return new ApiResponse<StudentDto>("Student not found.");
            }

            student.FirstName = dto.FirstName;
            student.LastName = dto.LastName;
            student.Age = dto.Age;

            var result = _mapper.Map<StudentDto>(student);
            return new ApiResponse<StudentDto>(result);
        }

        public async Task<ApiResponse<bool>> DeleteStudentAsync(int id)
        {
            var student = _db.Students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return new ApiResponse<bool>("Student not found.");
            }

            _db.Students.Remove(student);
            return new ApiResponse<bool>(true);
        }

        public async Task<ApiResponse<StudentReportDto>> GetStudentReportAsync(int studentId)
        {
            var student = _db.Students.FirstOrDefault(s => s.Id == studentId);
            if (student == null)
            {
                return new ApiResponse<StudentReportDto>("Student not found.");
            }

            var enrollments = _db.Enrollments.Where(e => e.StudentId == studentId).ToList();
            var classMarks = new List<StudentClassMarkDto>();

            foreach (var enrollment in enrollments)
            {
                var classInfo = _db.Classes.FirstOrDefault(c => c.Id == enrollment.ClassId);
                var mark = _db.Marks.FirstOrDefault(m => m.StudentId == studentId && m.ClassId == enrollment.ClassId);

                if (classInfo != null && mark != null)
                {
                    classMarks.Add(new StudentClassMarkDto
                    {
                        ClassId = classInfo.Id,
                        ClassName = classInfo.Name,
                        ExamMark = mark.ExamMark,
                        AssignmentMark = mark.AssignmentMark
                    });
                }
            }

            var overallAverage = classMarks.Any() ? classMarks.Average(cm => cm.TotalMark) : 0;

            var report = new StudentReportDto
            {
                StudentId = student.Id,
                FullName = $"{student.FirstName} {student.LastName}",
                ClassMarks = classMarks,
                OverallAverageMark = overallAverage
            };

            return new ApiResponse<StudentReportDto>(report);
        }
    }
}
