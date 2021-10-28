using GenericApi.Model.Contexts;
using GenericApi.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenericApi.Model.Repositories
{
    public interface IClassRepository : IBaseRepository<Class>
    {

    }
    public class ClassRepository : BaseRepository<Class>, IClassRepository
    {
        public ClassRepository(StudentsContex studentsContex) : base(studentsContex)
        {
        }
    }
}
