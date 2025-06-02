using StudentManagement.Application.Common.Filters;
using StudentManagement.Application.Common.Responses;
using StudentManagement.Application.DTOs.Students;
using StudentManagement.Domain.Models;
using StudentManagement.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Application.Interfaces
{
    public interface IStudentService
    {
        Task<ApiResponse<StudentDto>> CreateStudentAsync(CreateStudentDto dto);
        Task<ApiResponse<IEnumerable<StudentDto>>> GetAllStudentsAsync(StudentSearchFilter filter);
        Task<ApiResponse<StudentDto>> UpdateStudentAsync(int id, UpdateStudentDto dto);
        Task<ApiResponse<bool>> DeleteStudentAsync(int id);
        Task<ApiResponse<StudentReportDto>> GetStudentReportAsync(int studentId);
    }
}
