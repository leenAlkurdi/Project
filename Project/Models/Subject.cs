using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class Subject
    {
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }
        public string? Name { get; set; }
        public int MinimumDegree { get; set; }
        public int Term { get; set; }
        public int Year { get; set; }
        public ICollection<Exam> Exams { get; set; } = new List<Exam>();
        public ICollection<SubjectLecture> SubjectLectures { get; set; } = new List<SubjectLecture>();
    }
}
