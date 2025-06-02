using AutoMapper;
using StudentManagement.Application.Common.Filters;
using StudentManagement.Application.DTOs.Classes;
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
    public class ClassService : IClassService
    {
        private readonly StudentManagement.Infrastructure.InMemoryDatabase _db;
        private readonly IMapper _mapper;

        public ClassService(StudentManagement.Infrastructure.InMemoryDatabase db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<ApiResponse<Class>> CreateClassAsync(CreateClassDto classDto)
        {
            var classEntity = _mapper.Map<Class>(classDto);
            classEntity.Id = _db.Classes.Any() ? _db.Classes.Max(c => c.Id) + 1 : 1;
            _db.Classes.Add(classEntity);

            return new ApiResponse<Class>(classEntity);
        }

        public async Task<ApiResponse<IEnumerable<Class>>> GetAllClassesAsync(ClassSearchFilter filter)
        {
            var query = _db.Classes.AsQueryable();

            if (!string.IsNullOrWhiteSpace(filter.Name))
                query = query.Where(c => c.Name.Contains(filter.Name));

            var result = query
                .Skip(filter.Skip)
                .Take(filter.PageSize)
                .ToList();

            return new ApiResponse<IEnumerable<Class>>(result);
        }

        public async Task<ApiResponse<bool>> DeleteClassAsync(int id)
        {
            var classEntity = _db.Classes.FirstOrDefault(c => c.Id == id);
            if (classEntity == null)
                return new ApiResponse<bool>("Class not found.");

            _db.Classes.Remove(classEntity);
            return new ApiResponse<bool>(true);
        }

        public async Task<ApiResponse<double?>> GetAverageMarksAsync(int classId)
        {
            var marks = _db.Marks.Where(m => m.ClassId == classId).ToList();
            if (!marks.Any())
                return new ApiResponse<double?>(null);

            var average = marks.Average(m => m.TotalMark);
            return new ApiResponse<double?>((double)average);
        }
    }
}
