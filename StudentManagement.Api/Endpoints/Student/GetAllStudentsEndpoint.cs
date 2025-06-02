using FastEndpoints;
using StudentManagement.Application.Common.Filters;
using StudentManagement.Application.Common.Responses;
using StudentManagement.Application.DTOs.Students;
using StudentManagement.Application.Interfaces;
using StudentManagement.Shared.DTOs;

namespace StudentManagement.Api.Endpoints.Student
{
    public class GetAllStudentsEndpoint : Endpoint<GetAllStudentsRequest, ApiResponse<PaginatedResponse<StudentDto>>>
    {
        private readonly IStudentService _studentService;

        public GetAllStudentsEndpoint(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public override void Configure()
        {
            Verbs(Http.GET);
            Routes("/students");
            AllowAnonymous();
        }

        public override async Task HandleAsync(GetAllStudentsRequest req, CancellationToken ct)
        {
            var response = await _studentService.GetAllStudentsAsync(req);
            await SendAsync(response);
        }
    }

}
