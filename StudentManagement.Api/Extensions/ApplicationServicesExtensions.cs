using Microsoft.EntityFrameworkCore.InMemory.Storage.Internal;
using StudentManagement.Application.Common.Mapping;
using StudentManagement.Application.Interfaces;
using StudentManagement.Application.Services;

namespace StudentManagement.Api.Extensions
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient();

            services.AddAutoMapper(typeof(MappingProfile));

            services.AddSingleton<InMemoryDatabase>();



            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IClassService, ClassService>();
            services.AddScoped<IEnrollmentService, EnrollmentService>();
            services.AddScoped<IMarkService, MarkService>();

            return services;
        }

    }
}
