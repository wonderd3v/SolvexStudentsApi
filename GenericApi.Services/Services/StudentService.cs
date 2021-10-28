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
    public interface IStudentService : IBaseService<Student, StudentDto>
    {

    }
    public class StudentService : BaseService<Student, StudentDto>, IStudentService
    {
        public StudentService(IStudentRepository studentRepository, IMapper mapper, IValidator<StudentDto> validator) : base(studentRepository, mapper, validator)
        {

        }
    }
}
