using FluentValidation;
using GenericApi.Bl.Dto;

namespace GenericApi.Bl.Validations
{
    public class TeacherValidator : AbstractValidator<TeacherDto>
    {
        public TeacherValidator()
        {

            RuleFor(x => x.Dni)
                .NotEmpty()
                .WithMessage("Dni is required");

        }
    }
}
