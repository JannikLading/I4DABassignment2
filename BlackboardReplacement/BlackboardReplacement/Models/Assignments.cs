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

        public Teachers Teachers { get; set; }
        public int TeachersId { get; set; }
        public Courses Courses { get; set; }
        public int CoursesId { get; set; }

        public List<Groups> groups { get; set; }


    }
}
