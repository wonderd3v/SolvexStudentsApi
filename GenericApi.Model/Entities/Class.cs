using GenericApi.Core.BaseModel;
using System.Collections.Generic;

namespace GenericApi.Model.Entities
{
    public class Class : BaseEntity
    {
        public string Name { get; set; }
        public int? TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }
        public virtual ICollection<ClassStudent> ClassStudent { get; set; }
    }
}
