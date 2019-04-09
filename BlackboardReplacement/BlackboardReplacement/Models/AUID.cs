using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlackboardReplacement.Models
{
    public class AU
    {
        [Key]
        public int AUId { get; set; }

        private List<Teachers> Teachers { get; set; }
        private List<Student> Student { get; set; }
    }
}