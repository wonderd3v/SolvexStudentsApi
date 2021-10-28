using FluentValidation;
using GenericApi.Bl.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenericApi.Bl.Validations
{
    public class StudentValidator : AbstractValidator<StudentDto>
    {
		public StudentValidator()
		{
			RuleFor(x => x.Name)
				.NotEmpty()
				.WithMessage("Name is required");
		}
	}
}
