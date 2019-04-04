using System;
using System.Collections.Generic;
using System.Text;

namespace BlackboardReplacement.Models
{
   public class CoursesTeachers
   {
       public int CoursesTeachersId { get; set; }

       public Teachers Teachers { get; set; }
       public int AuId { get; set; }

       public Courses Courses{ get; set; }
       public int CourseId { get; set; }
    }
}
