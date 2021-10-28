using GenericApi.Core.BaseModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenericApi.Bl.Dto
{
    public class TeacherDto : BaseEntityDto
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Dni { get; set; }
        public virtual ClassDto Class { get; set; }
    }
}
