using FluentValidation;
using GenericApi.Bl.Dto;

namespace GenericApi.Bl.Validations
{
    public class ClassValidator : AbstractValidator<ClassDto>
    {
        public ClassValidator()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .WithMessage("Name is required");
         
                
        }
    }
}
