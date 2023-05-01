using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring (DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Data Source=(localdb)\ProjectModels;Initial Catalog=tcc_project;Integrated Security=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasIndex(s => new { s.Email, s.Phone ,s.UserName })
                .IsUnique(true);
        }
        public DbSet<Student>? students { get; set; }
        public DbSet<Department>? departments { get; set; }
        public DbSet<SubjectLecture>? SubjectLectures { get; set; }
        public DbSet<Subject>? Subjects { get; set; }
        public DbSet<Exam>? Exams { get; set; }
        public DbSet<StudentMark>? StudentMarks { get; set; }
    }
}
