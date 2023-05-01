using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class SubjectLecture
    {
        public int Id { get; set; }
        public int SubjectId { get; set; }
        public Subject? Subject { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }

    }
}
