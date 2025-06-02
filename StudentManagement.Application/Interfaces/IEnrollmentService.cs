using StudentManagement.Application.DTOs.Enrollments;
using StudentManagement.Domain.Models;
using StudentManagement.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Application.Interfaces
{
    public interface IEnrollmentService
    {
        Task<ApiResponse<Enrollment>> EnrollStudentAsync(EnrollmentDto enrollmentDto);
    }
}
