using AutoMapper;
using GenericApi.Bl.Dto;
using GenericApi.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenericApi.Bl.Mapper
{
    public class MainMapperProfile : Profile
    {
        public MainMapperProfile()
        {
            #region Teacher
            CreateMap<Teacher, TeacherDto>();
            CreateMap<TeacherDto, Teacher>();
            #endregion

            #region Students

            CreateMap<Student, StudentDto>();
            CreateMap<StudentDto, Student>();

            #endregion

            #region Class

            CreateMap<Class, ClassDto>();
            CreateMap<ClassDto, Class>();

            #endregion

            #region ClassStudent

            CreateMap<ClassStudent, ClassStudentDto>();
            CreateMap<ClassStudentDto, ClassStudent>();

            #endregion

        }
    }
}
