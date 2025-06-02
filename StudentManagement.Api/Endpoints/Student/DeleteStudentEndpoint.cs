using FastEndpoints;
using StudentManagement.Application.DTOs.Students;
using StudentManagement.Application.Interfaces;
using StudentManagement.Shared.DTOs;

namespace StudentManagement.Api.Endpoints.Student
{
    public class DeleteStudentEndpoint : Endpoint<DeleteStudentRequest, bool>
    {
        private readonly IStudentService _studentService;

        public DeleteStudentEndpoint(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public override void Configure()
        {
            Verbs(Http.DELETE);
            Routes("/students/{Id}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(DeleteStudentRequest req, CancellationToken ct)
        {
            var response = await _studentService.DeleteStudentAsync(req.Id);
            await SendAsync(response);
        }
    }
}
