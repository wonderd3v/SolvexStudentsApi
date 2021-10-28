using GenericApi.Core.BaseModel;
using System.Collections.Generic;

namespace GenericApi.Model.Entities
{
    public class Student : BaseEntity
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public virtual ICollection<ClassStudent> ClassStudent { get; set; }
    }
}
