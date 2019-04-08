using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlackboardReplacement.Models
{
    public class CourseContent
    {
        [Key]
        public int id { get; set; }

        public string Audio { get; set; }
        public string Video { get; set; }
        public string TextBlock { get; set; }
        public string Folder { get; set; }

        public Courses Course { get; set; }

        [Required]
        public int courseID { get; set; }
        
    }
}
