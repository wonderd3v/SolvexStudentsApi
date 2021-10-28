using AutoMapper;
using FluentValidation;
using GenericApi.Bl.Dto;
using GenericApi.Model.Entities;
using GenericApi.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenericApi.Services.Services
{
    public interface IClassService : IBaseService<Class, ClassDto>
    {

    }
    public class ClassService : BaseService<Class, ClassDto>, IClassService
    {
        public ClassService(IClassRepository classRepository, IMapper mapper, IValidator<ClassDto> validator) : base(classRepository, mapper, validator)
        {

        }
    }
}
