using FastEndpoints;
using StudentManagement.Application.DTOs.Students;
using StudentManagement.Application.Interfaces;
using StudentManagement.Shared.DTOs;

namespace StudentManagement.Api.Endpoints.Student
{
    public class GetStudentReportEndpoint : Endpoint<int, ApiResponse<StudentReportDto>>
    {
        private readonly IStudentService _studentService;

        public GetStudentReportEndpoint(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public override async Task HandleAsync(int req, CancellationToken ct)
        {
            var response = await _studentService.GetStudentReportAsync(req);
            await SendAsync(response, cancellation: ct);
        }
    }
}
