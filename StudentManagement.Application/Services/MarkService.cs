using AutoMapper;
using StudentManagement.Application.DTOs.Marks;
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
    public class MarkService : IMarkService
    {
        private readonly StudentManagement.Infrastructure.InMemoryDatabase _db;
        private readonly IMapper _mapper;

        public MarkService(StudentManagement.Infrastructure.InMemoryDatabase db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<ApiResponse<Mark>> RecordMarkAsync(MarkDto markDto)
        {
            var mark = _mapper.Map<Mark>(markDto);
            mark.Id = _db.Marks.Any() ? _db.Marks.Max(m => m.Id) + 1 : 1;
            _db.Marks.Add(mark);

            return new ApiResponse<Mark>(mark);
        }
    }
}
