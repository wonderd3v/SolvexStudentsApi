using GenericApi.Core.BaseModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenericApi.Bl.Dto
{
    public class ClassDto : BaseEntityDto
    {
        public string Name { get; set; }
        public int? TeacherId { get; set; }
        public virtual TeacherDto Teacher { get; set; }
        public virtual ICollection<ClassStudentDto> ClassStudent { get; set; }
    }
}
