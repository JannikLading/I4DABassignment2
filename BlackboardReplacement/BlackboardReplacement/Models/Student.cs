using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;


namespace BlackboardReplacement.Models
{
    public class Student
    {
        //public int ÍD { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime Birthday { get; set; }

        [Required]
        public DateTime EnrolledDate { get; set; }

        [Required]
        public DateTime GraduationDate { get; set; }

        [Key]
        public int AUId { get; set; }
        public AU Au { get; set; }

        public List<Enrollments> Enrollments { get; set; }
        public List<StudentGroups> StudentGroups { get; set; }

    }
}