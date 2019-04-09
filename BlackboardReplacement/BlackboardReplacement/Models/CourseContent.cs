using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BlackboardReplacement.Models
{
    public class CourseContent
    {
        [Key]
        public int CourseContentId { get; set; }
        public string Audio { get; set; }
        public string Video { get; set; }
        public string TextBlock { get; set; }
        public string Folder { get; set; }

        //[Required]
        public int CoursesId { get; set; }
        public Courses Courses { get; set; }

    }
}
