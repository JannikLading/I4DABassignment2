using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BlackboardReplacement.Models
{
    public class Courses
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; } 

        [Required]
        public string Name { get; set; }

        public Calendar Calendar { get; set; }

        public int CalendarId { get; set; }

        public CourseContent CourseContent { get; set; }

        public int CourseContentId { get; set; }

        public List<Enrollments> Enrollments { get; set; }

        public List<Assignments> Assignments{ get; set; }

        public List<CoursesTeachers> CoursesTeachers { get; set; }

    }
}
