using StudentManagement.Application.Common.Mapping;

namespace StudentManagement.Api.Extensions
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient();

            services.AddAutoMapper(typeof(MappingProfile));


            return services;
        }

    }
}
