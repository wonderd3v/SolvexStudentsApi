using GenericApi.Bl.Dto;
using GenericApi.Model.Entities;
using GenericApi.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericApi.Controllers
{
    public class TeacherController : BaseController<Teacher, TeacherDto>
    {
        public TeacherController(ITeacherService teacherService) : base(teacherService)
        {

        }
    }
}
