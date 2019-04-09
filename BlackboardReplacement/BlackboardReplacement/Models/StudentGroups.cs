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

        public int AUId { get; set; }
        public Student Student { get; set; }

        public int GroupsId { get; set; }

        public Groups Groups { get; set; }

    }
}
