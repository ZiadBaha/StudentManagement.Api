using AutoMapper;
using StudentManagement.Application.DTOs.Enrollments;
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
    public class EnrollmentService : IEnrollmentService
    {
        private readonly StudentManagement.Infrastructure.InMemoryDatabase _db;
        private readonly IMapper _mapper;

        public EnrollmentService(StudentManagement.Infrastructure.InMemoryDatabase db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<ApiResponse<Enrollment>> EnrollStudentAsync(EnrollmentDto enrollmentDto)
        {
            var enrollment = _mapper.Map<Enrollment>(enrollmentDto);
            enrollment.Id = _db.Enrollments.Any() ? _db.Enrollments.Max(e => e.Id) + 1 : 1;
            _db.Enrollments.Add(enrollment);

            return new ApiResponse<Enrollment>(enrollment);
        }
    }
}
