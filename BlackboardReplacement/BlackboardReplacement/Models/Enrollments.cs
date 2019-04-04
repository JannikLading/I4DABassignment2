using System;
using System.Collections.Generic;
using System.Text;

namespace BlackboardReplacement.Models
{
    public class Enrollments
    {
        public bool Status { get; set; }

        public Courses Course { get; set; }
        public int CourseId { get; set; }

        public Student Student { get; set; }
        public int AUID { get; set; }

    }
}
