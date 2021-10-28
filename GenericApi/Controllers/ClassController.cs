using GenericApi.Bl.Dto;
using GenericApi.Model.Entities;
using GenericApi.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericApi.Controllers
{
    public class ClassController : BaseController<Class, ClassDto>
    {
        public ClassController(IClassService classService) : base(classService)
        {

        }
    }
}
