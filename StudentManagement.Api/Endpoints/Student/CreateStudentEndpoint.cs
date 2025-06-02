using FastEndpoints;
using StudentManagement.Application.DTOs.Students;
using StudentManagement.Application.Interfaces;
using StudentManagement.Shared.DTOs;

namespace StudentManagement.Api.Endpoints.Student
{
    public class CreateStudentEndpoint : Endpoint<CreateStudentRequest, ApiResponse<StudentDto>>
    {
        private readonly IStudentService _studentService;

        public CreateStudentEndpoint(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public override void Configure()
        {
            Verbs(Http.POST);
            Routes("/students");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CreateStudentRequest req, CancellationToken ct)
        {
            var response = await _studentService.CreateStudentAsync(req.Dto);
            await SendAsync(response);
        }
    }
}
