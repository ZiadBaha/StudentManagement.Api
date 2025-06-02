using StudentManagement.Api.Extensions;
using StudentManagement.Api.Middlewares;

namespace StudentManagement.Api.Setup
{
    public static class MiddlewareConfigurator
    {
        public static void Configure(WebApplication app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwaggerDocumentation();
            }

            app.UseHttpsRedirection();
            app.UseMiddleware<GlobalExceptionMiddleware>();
            app.UseAuthorization();
            app.UseCustomMiddlewares();
            app.MapControllers();
        }
    }
}
