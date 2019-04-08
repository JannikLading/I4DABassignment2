using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlackboardReplacement.Models
{
    public class Groups
    {

        [Key]
        public int GroupId { get; set; }

        public int maxSize { get; set; }

        public Assignments assignment { get; set; }
        public int AssignmentId { get; set; }

    }
}
