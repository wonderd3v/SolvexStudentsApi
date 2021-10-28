using GenericApi.Model.Contexts;
using GenericApi.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenericApi.Model.Repositories
{
    public interface IStudentRepository : IBaseRepository<Student>
    {

    }
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        public StudentRepository(StudentsContex studentsContex) : base(studentsContex)
        {

        }
    }
}
