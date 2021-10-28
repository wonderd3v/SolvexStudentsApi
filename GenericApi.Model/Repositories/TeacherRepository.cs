using GenericApi.Model.Contexts;
using GenericApi.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenericApi.Model.Repositories
{
    public interface ITeacherRepository :IBaseRepository<Teacher>
    {

    }
    public class TeacherRepository : BaseRepository<Teacher>, ITeacherRepository 
    {
        public TeacherRepository(StudentsContex studentsContex) : base(studentsContex)
        { 
        }
    }
}
