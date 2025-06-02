using StudentManagement.Application.DTOs.Marks;
using StudentManagement.Domain.Models;
using StudentManagement.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Application.Interfaces
{
    public interface IMarkService
    {
        Task<ApiResponse<Mark>> RecordMarkAsync(MarkDto markDto);
    }
}
