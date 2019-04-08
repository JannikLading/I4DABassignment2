using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlackboardReplacement.Models
{
    public class Enrollments
    {
        [Key]
        public int EnrollmentId { get; set; }
        public bool Status { get; set; }
        public int Grade { get; set; }
        public Courses Course { get; set; }
        public int CourseId { get; set; }

        public Student Student { get; set; }
        public int AUID { get; set; }

    }
}
