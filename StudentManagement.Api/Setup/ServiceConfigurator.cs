using StudentManagement.Api.Extensions;
using StudentManagement.Api.Filters;

namespace StudentManagement.Api.Setup
{
    public static class ServiceConfigurator
    {
        public static void Configure(IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers(options =>
            {
                options.Filters.Add<ValidationFilter>();
            });

            services.AddEndpointsApiExplorer();
            services.AddSwaggerDocumentation();
            services.AddApplicationServices(configuration);
            services.AddFluentValidationServices();



        }
    }
}
