using GenericApi.Bl.Dto;
using GenericApi.Model.Entities;
using GenericApi.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericApi.Controllers
{
    public class StudentController : BaseController<Student, StudentDto>
    {
        public StudentController(IStudentService studentController) : base(studentController)
        {

        }
    }
}
