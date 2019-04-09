        using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;

namespace BlackboardReplacement.Models
{
    public class Teachers
    {
        [Required]
        public string name { get; set; }

        [Required]
        public DateTime Birthday { get; set; }

        [Key]
        public int AUId { get; set; }
        public AU AU { get; set; }
       

        public List<CoursesTeachers> CoursesTeacherses { get; set; }
    }
}
