using FastEndpoints;
using StudentManagement.Application.Interfaces;
using StudentManagement.Shared.DTOs;

namespace StudentManagement.Api.Endpoints.Student
{
    public class DeleteStudentEndpoint : Endpoint<int, ApiResponse<bool>>
    {
        private readonly IStudentService _studentService;

        public DeleteStudentEndpoint(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public override async Task HandleAsync(int req, CancellationToken ct)
        {
            var response = await _studentService.DeleteStudentAsync(req);
            await SendAsync(response, cancellation: ct);
        }
    }
}
