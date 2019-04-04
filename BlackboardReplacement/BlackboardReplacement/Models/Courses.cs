﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlackboardReplacement.Models
{
    public class Courses
    {
        [Key]
        public int id { get; set; } 
        public string Name { get; set; }

        public Calendar Calendar { get; set; }
        public int CalenderId { get; set; }
        public CourseContent CourseContent { get; set; }
        public List<Enrollments> Enrollments { get; set; }
        public List<Assignments> Assignments{ get; set; }
        //public List<Teachers> Teachers { get; set; }


    }
}
