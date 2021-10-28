using GenericApi.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenericApi.Model.Contexts
{
    public class StudentsContex : BaseDbContext
    {
        public StudentsContex(DbContextOptions<StudentsContex> options) : base(options)
        {
        }

        DbSet<Class> Classes { get; set; }
        DbSet<Student> Students { get; set; }
        DbSet<Teacher> Teachers { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
