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
    public interface ITeacherService : IBaseService<Teacher, Bl.Dto.TeacherDto>
    {

    }
    public class TeacherService : BaseService<Teacher, Bl.Dto.TeacherDto>, ITeacherService
    {
        public TeacherService(ITeacherRepository teacherRepository, IMapper mapper, IValidator<TeacherDto> validator) :base(teacherRepository, mapper, validator)
        {

        }
    }
}
