using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlackboardReplacement.Models
{
   public class CoursesTeachers
   {
       [Key]
       public int CoursesTeachersId { get; set; }

       public Teachers Teachers { get; set; }
       public int TeachersId { get; set; }

       public Courses Courses{ get; set; }
       public int CoursesId { get; set; }
    }
}
