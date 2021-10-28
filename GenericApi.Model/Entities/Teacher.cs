using GenericApi.Core.BaseModel;
using System.Collections.Generic;

namespace GenericApi.Model.Entities
{
    public class Teacher : BaseEntity
    {
        public string Name{ get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Dni { get; set; }
        public virtual Class Class { get; set; }
    }
}
