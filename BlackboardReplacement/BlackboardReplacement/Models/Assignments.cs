using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlackboardReplacement.Models
{
    public class Assignments
    {
        [Key]
        public int AssignmentId { get; set; }
        public int Grade { get; set; }
        public int Attempt { get; set; }

        public Teachers Teacher { get; set; }
        public int TeacherId { get; set; }
        public List<Groups> group { get; set; }
        public Courses Course { get; set; }
        public int CourseId { get; set; }



    }
}
