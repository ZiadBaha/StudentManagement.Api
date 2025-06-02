using FastEndpoints;
using StudentManagement.Application.DTOs.Students;
using StudentManagement.Application.Interfaces;
using StudentManagement.Shared.DTOs;

namespace StudentManagement.Api.Endpoints.Student
{
    public class UpdateStudentEndpoint : Endpoint<UpdateStudentRequest, ApiResponse<StudentDto>>
    {
        private readonly IStudentService _studentService;

        public UpdateStudentEndpoint(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public override async Task HandleAsync(UpdateStudentRequest req, CancellationToken ct)
        {
            var response = await _studentService.UpdateStudentAsync(req.Id, req.Dto);
            await SendAsync(response, cancellation: ct);
        }
    }

}
