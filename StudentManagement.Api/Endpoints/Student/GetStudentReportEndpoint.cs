using FastEndpoints;
using StudentManagement.Application.DTOs.Students;
using StudentManagement.Application.Interfaces;
using StudentManagement.Shared.DTOs;

namespace StudentManagement.Api.Endpoints.Student
{
    public class GetStudentReportEndpoint : Endpoint<GetStudentReportRequest, ApiResponse<StudentReportDto>>
    {
        private readonly IStudentService _studentService;

        public GetStudentReportEndpoint(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public override void Configure()
        {
            Verbs(Http.GET);
            Routes("/students/{StudentId}/report");
            AllowAnonymous();
        }

        public override async Task HandleAsync(GetStudentReportRequest req, CancellationToken ct)
        {
            var response = await _studentService.GetStudentReportAsync(req.StudentId);
            await SendAsync(response);
        }
    }
}
