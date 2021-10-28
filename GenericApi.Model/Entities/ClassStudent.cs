using GenericApi.Core.BaseModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenericApi.Model.Entities
{
    public class ClassStudent : BaseEntityDto  
    {
        public int ClassId { get; set; }
        public int StudentId { get; set; }
    }
}
