using StudentManagement.Application.Common.Filters;
using StudentManagement.Application.Common.Responses;
using StudentManagement.Application.DTOs.Classes;
using StudentManagement.Domain.Models;
using StudentManagement.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Application.Interfaces
{
    public interface IClassService
    {
        Task<ApiResponse<Class>> CreateClassAsync(CreateClassDto classDto);
        Task<ApiResponse<IEnumerable<Class>>> GetAllClassesAsync(ClassSearchFilter classSearchFilter);
        Task<ApiResponse<bool>> DeleteClassAsync(int id);
        Task<ApiResponse<double?>> GetAverageMarksAsync(int classId);
    }

}
