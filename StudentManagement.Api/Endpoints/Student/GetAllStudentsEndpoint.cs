using FastEndpoints;
using StudentManagement.Application.Common.Filters;
using StudentManagement.Application.DTOs.Students;
using StudentManagement.Application.Interfaces;
using StudentManagement.Shared.DTOs;

namespace StudentManagement.Api.Endpoints.Student
{
    public class GetAllStudentsEndpoint : Endpoint<StudentSearchFilter, ApiResponse<IEnumerable<StudentDto>>>
    {
        private readonly IStudentService _studentService;

        public GetAllStudentsEndpoint(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public override async Task HandleAsync(StudentSearchFilter req, CancellationToken ct)
        {
            var response = await _studentService.GetAllStudentsAsync(req);
            await SendAsync(response, cancellation: ct);
        }
    }
}
