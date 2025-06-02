using FastEndpoints;
using StudentManagement.Application.DTOs.Students;
using StudentManagement.Application.Interfaces;
using StudentManagement.Shared.DTOs;

namespace StudentManagement.Api.Endpoints.Student
{
    public class CreateStudentEndpoint : Endpoint<CreateStudentDto, ApiResponse<StudentDto>>
    {
        private readonly IStudentService _studentService;

        public CreateStudentEndpoint(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public override async Task HandleAsync(CreateStudentDto req, CancellationToken ct)
        {
            var response = await _studentService.CreateStudentAsync(req);
            await SendAsync(response, cancellation: ct);
        }
    }
}
