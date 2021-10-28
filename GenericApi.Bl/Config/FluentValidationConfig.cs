using FluentValidation.AspNetCore;
using GenericApi.Bl.Dto;
using GenericApi.Model.Entities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenericApi.Bl.Config
{
    public static class FluentValidationConfig
    {
        public static IMvcBuilder ConfigFluentValidation(this IMvcBuilder builder)
        {
            builder.AddFluentValidation(x =>
            {
                x.AutomaticValidationEnabled = false;
                x.RegisterValidatorsFromAssemblyContaining<TeacherDto>();
            });
            return builder;
        }
    }
}
