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
        [Key]
        public int auID { get; set; }

        public int courseID { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        public DateTime Birthday { get; set; }

        public Courses courses { get; set; }

    }
}
