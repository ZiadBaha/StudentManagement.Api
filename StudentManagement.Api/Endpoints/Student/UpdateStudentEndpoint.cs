using FastEndpoints;
using StudentManagement.Application.DTOs.Students;
using StudentManagement.Application.Interfaces;
using StudentManagement.Shared.DTOs;

namespace StudentManagement.Api.Endpoints.Student
{
    public class UpdateStudentEndpoint : Endpoint<UpdateStudentRequest, StudentDto>
    {
        private readonly IStudentService _studentService;

        public UpdateStudentEndpoint(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public override void Configure()
        {
            Verbs(Http.PUT);
            Routes("/students/{Id}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(UpdateStudentRequest req, CancellationToken ct)
        {
            var response = await _studentService.UpdateStudentAsync(req.Id, req.Dto);
            await SendAsync(response);
        }
    }

}
