using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project
{
    public class Exam
    {
        public int Id { get; set; }
        public int SubjectId { get; set; }
        public Subject? Subject { get; set; }
        public DateTime Date { get; set; }
        public int Term { get; set; }
        public ICollection<StudentMark> StudentMarks { get; set; } = new List<StudentMark>();
    }
}
