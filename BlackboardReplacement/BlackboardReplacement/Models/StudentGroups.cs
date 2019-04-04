using System;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;
namespace BlackboardReplacement.Models
{
    public class StudentGroups
    {
        [Key]
        public int StudentGroupsId { get; set; }

        public int AUID { get; set; }

        public Student Student { get; set; }

        public int GroupId { get; set; }

        public Groups Group { get; set; }

    }
}
