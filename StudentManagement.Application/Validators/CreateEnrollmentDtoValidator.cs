using FluentValidation;
using StudentManagement.Application.DTOs.Enrollments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Application.Validators
{
    public class CreateEnrollmentDtoValidator : AbstractValidator<CreateEnrollmentDto>
    {
        public CreateEnrollmentDtoValidator()
        {
            RuleFor(x => x.StudentId)
                .GreaterThan(0).WithMessage("StudentId must be greater than 0.");

            RuleFor(x => x.ClassId)
                .GreaterThan(0).WithMessage("ClassId must be greater than 0.");
        }
    }
}
