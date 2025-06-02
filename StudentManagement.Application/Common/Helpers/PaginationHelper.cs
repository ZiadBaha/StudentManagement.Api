using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using StudentManagement.Application.Common.Filters;
using StudentManagement.Application.Common.Responses;

namespace StudentManagement.Application.Common.Helpers
{
    public static class PaginationHelper
    {
        public static async Task<PaginatedResponse<TDto>> CreatePaginatedResponse<TEntity, TDto>(
            IQueryable<TEntity> query,
            PaginationFilter filter,
            IConfigurationProvider configuration,
            CancellationToken cancellationToken = default)
        {
            var totalRecords = await query.CountAsync(cancellationToken);

            var data = await query
                .Skip(filter.Skip)
                .Take(filter.PageSize)
                .ProjectTo<TDto>(configuration) 
                .ToListAsync(cancellationToken);

            return new PaginatedResponse<TDto>(data, totalRecords, filter.Page, filter.PageSize);
        }
    }
}
